' Copyright © 2026 Nox. All rights reserved.

Imports Nox.Grid.WinForms

''' <summary>
''' NoxGrid demo (sales orders), four sheets: Shipping Board (styled view) · Sales Orders (unbound + formulas) ·
''' Shipments (DataTable binding) · By Customer (formulas that summarize another sheet).
''' The layout and all columns were built in the designer (MainForm.Designer.vb).
''' </summary>
Public Class MainForm

    Private _orders As List(Of SampleData.Order)
    Private _shipments As DataTable
    Private _loading As Boolean

    ' ================================================================ Startup

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboScheme.Items.AddRange([Enum].GetNames(GetType(NoxGridColorScheme)))
        cboScheme.SelectedIndex = 0

        _orders = SampleData.CreateOrders(300)
        _shipments = SampleData.CreateShipments(_orders)

        _loading = True
        LoadOrders()
        gridShip.DataSource = _shipments      ' columns are bound with DataPropertyName in the designer
        BuildStatistics()
        LoadBoard()
        _loading = False

        ' Print settings
        For Each sheet In NoxGridBook1.Sheets
            sheet.Grid.PrintSettings.Title = sheet.Text
            sheet.Grid.PrintSettings.Footer = "NoxGrid Demo - Sales Orders"
            sheet.Grid.PrintSettings.Landscape = True
        Next
        UpdateStatus()
    End Sub

    ''' <summary>
    ''' Unbound: filled with Rows.Add(values...), and the Amount cell is a formula (=Qty*Price).
    ''' Formula addresses work like Excel: A1 = first row, first column (header excluded). Change Qty (D) or Price (E) and Amount (F) recalculates at once.
    ''' </summary>
    Private Sub LoadOrders()
        gridOrders.BeginUpdate()
        Try
            For Each o In _orders
                Dim i = gridOrders.Rows.Add(o.OrderNo, o.Customer, o.ItemName, o.Quantity, o.Price, Nothing, o.Ordered, o.Due, o.Urgent, o.Status, "")
                gridOrders.SetFormula(i, colAmount.Index, "=D" & (i + 1) & "*E" & (i + 1))
                If o.Urgent Then gridOrders.Rows(i).BackColor = Color.FromArgb(255, 238, 238)
            Next
            gridOrders(0, "colMemo") = "Sample data (randomly generated)"
            gridOrders.Cells(0, "colMemo").Bold = True
        Finally
            gridOrders.EndUpdate()
        End Try
        gridOrders.ClearUndo()   ' loaded data is not part of the undo history
    End Sub

    ''' <summary>
    ''' By Customer: formulas that read another sheet ('Sales Orders'!B:B). Edit Sales Orders and this sheet updates at once.
    ''' </summary>
    Private Sub BuildStatistics()
        Const src As String = "'Sales Orders'!"
        gridStats.BeginUpdate()
        Try
            gridStats.Rows.Clear()
            ' Title row: 5 merged cells
            Dim title = gridStats.Rows.Add("Orders by customer (as of " & SampleData.Today.ToString("yyyy-MM-dd") & ")")
            gridStats.Cells(title, 0, title, 4).Merge()
            gridStats.Rows(title).Height = 36
            gridStats.Rows(title).Bold = True
            gridStats.Rows(title).BackColor = Color.FromArgb(221, 235, 247)
            gridStats.Rows(title).ReadOnly = True

            Dim first = gridStats.RowCount + 1           ' formula row number of the first customer (1-based)
            Dim last = first + SampleData.Customers.Length - 1
            Dim totalRow = last + 1
            For Each customer In SampleData.Customers
                Dim r = gridStats.Rows.Add(customer)
                Dim n = r + 1
                gridStats.SetFormula(r, 1, "=COUNTIF(" & src & "B:B,A" & n & ")")
                gridStats.SetFormula(r, 2, "=COUNTIFS(" & src & "B:B,A" & n & "," & src & "I:I,TRUE)")
                gridStats.SetFormula(r, 3, "=SUMIF(" & src & "B:B,A" & n & "," & src & "F:F)")
            Next

            Dim total = gridStats.Rows.Add("Total")
            ' Share = customer amount / total amount (set after the total row exists)
            For n = first To last
                gridStats.SetFormula(n - 1, 4, "=IFERROR(D" & n & "/D$" & totalRow & ",0)")
            Next
            For c = 1 To 3
                Dim letter = Chr(AscW("A"c) + c)
                gridStats.SetFormula(total, c, "=SUM(" & letter & first & ":" & letter & last & ")")
            Next
            gridStats.SetFormula(total, 4, "=SUM(E" & first & ":E" & last & ")")
            gridStats.Rows(total).Bold = True
            gridStats.Rows(total).BackColor = Color.FromArgb(242, 242, 242)

            Dim avg = gridStats.Rows.Add("Average amount per order")
            gridStats.SetFormula(avg, 3, "=IFERROR(D" & (total + 1) & "/B" & (total + 1) & ",0)")
        Finally
            gridStats.EndUpdate()
        End Try
        gridStats.ClearUndo()
    End Sub

    ''' <summary>
    ''' Shipping Board (styled view): status icon + text (image column), label column (read-only color), progress bar column,
    ''' Modern color scheme (set in the designer), merged cells for the same sales rep, multi-column sort (rep → shipped %).
    ''' </summary>
    Private Sub LoadBoard()
        ' Status icons: dots drawn in code (in a real app, add image files to the ImageList in the designer)
        imgStatus.Images.Add("Done", MakeDot(Color.FromArgb(34, 197, 94)))
        imgStatus.Images.Add("Active", MakeDot(Color.FromArgb(59, 130, 246)))
        imgStatus.Images.Add("Waiting", MakeDot(Color.FromArgb(148, 163, 184)))
        imgStatus.Images.Add("Late", MakeDot(Color.FromArgb(239, 68, 68)))

        Dim shipped = _shipments.AsEnumerable().
            GroupBy(Function(row) CStr(row("OrderNo"))).
            ToDictionary(Function(gr) gr.Key, Function(gr) gr.Sum(Function(row) CInt(row("ShipQty"))))
        gridBoard.BeginUpdate()
        Try
            For Each o In _orders
                Dim qty = If(shipped.ContainsKey(o.OrderNo), shipped(o.OrderNo), 0)
                Dim percent = If(o.Quantity = 0, 0D, Math.Min(100D, CDec(qty) * 100D / o.Quantity))
                Dim status As String
                If percent >= 100D Then
                    status = "Done"
                ElseIf o.Due < SampleData.Today AndAlso o.Status <> "On hold" Then
                    status = "Late"
                ElseIf o.Status = "Received" OrElse o.Status = "On hold" Then
                    status = "Waiting"
                Else
                    status = "Active"
                End If
                gridBoard.Rows.Add(status, o.OrderNo, o.Customer, o.SalesRep, o.Quantity, percent, o.Due)
            Next
            ' Conditional format: shipped below 30% in bold red (also editable in the Properties window: ConditionalFormats)
            Dim slow = gridBoard.ConditionalFormats.Add("colBProgress", NoxConditionOperator.LessThan, "30", Color.Empty)
            slow.ForeColor = Color.Firebrick
            slow.Bold = True
            ' By sales rep, then highest shipped % first (Shift+click headers to sort by several columns)
            gridBoard.Sort({colBRep, colBProgress}, {NoxSortOrder.Ascending, NoxSortOrder.Descending})
        Finally
            gridBoard.EndUpdate()
        End Try
        gridBoard.ClearUndo()
    End Sub

    Private Shared Function MakeDot(c As Color) As Image
        Dim bmp As New Bitmap(14, 14)
        Using g = Graphics.FromImage(bmp)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Using b As New SolidBrush(c)
                g.FillEllipse(b, 2, 2, 10, 10)
            End Using
        End Using
        Return bmp
    End Function

    Private Shared Function IsOpen(status As Object) As Boolean
        Dim s = TryCast(status, String)
        Return s <> "Completed" AndAlso s <> "On hold"
    End Function

    ' ================================================================ Grid events

    ''' <summary>Sales Orders: red due date for open orders past due, gray text for orders on hold</summary>
    Private Sub gridOrders_CellFormatting(sender As Object, e As NoxGridCellFormattingEventArgs) Handles gridOrders.CellFormatting
        If gridOrders.IsSubtotalRow(e.RowIndex) Then Return
        Dim status = gridOrders(e.RowIndex, "colStatus")
        If CStr(status) = "On hold" Then
            e.ForeColor = Color.Gray
        ElseIf e.Column Is colDue Then
            Dim due = gridOrders(e.RowIndex, "colDue")
            If TypeOf due Is Date AndAlso CDate(due) < SampleData.Today AndAlso IsOpen(status) Then
                e.ForeColor = Color.Firebrick
                e.Bold = True
            End If
        ElseIf e.Column Is colStatus AndAlso CStr(status) = "Completed" Then
            e.ForeColor = Color.ForestGreen
        End If
    End Sub

    ''' <summary>Picking an item fills in the unit price (Amount is a formula, so it follows)</summary>
    Private Sub gridOrders_CellValueChanged(sender As Object, e As NoxGridCellEventArgs) Handles gridOrders.CellValueChanged
        If _loading OrElse e.Column IsNot colItem Then Return
        Dim name = TryCast(gridOrders(e.RowIndex, "colItem"), String)
        Dim item = SampleData.Items.FirstOrDefault(Function(x) x.Name = name)
        If item.Name IsNot Nothing Then gridOrders(e.RowIndex, "colPrice") = item.Price
    End Sub

    ''' <summary>Shipments: returned in red, in transit in blue</summary>
    Private Sub gridShip_CellFormatting(sender As Object, e As NoxGridCellFormattingEventArgs) Handles gridShip.CellFormatting
        If e.Column Is colSState OrElse e.Column Is colSShipQty Then
            Dim state = TryCast(gridShip(e.RowIndex, "colSState"), String)
            If state = "Returned" Then
                e.ForeColor = Color.Firebrick
                e.Bold = True
            ElseIf state = "In transit" Then
                e.ForeColor = Color.RoyalBlue
                e.Bold = True
            End If
        End If
    End Sub

    ''' <summary>Editing a shipped quantity recalculates the remaining quantity of that order (written through to the bound DataTable)</summary>
    Private Sub gridShip_CellValueChanged(sender As Object, e As NoxGridCellEventArgs) Handles gridShip.CellValueChanged
        If _loading OrElse e.Column IsNot colSShipQty Then Return
        Dim order = CStr(gridShip(e.RowIndex, "colSOrder"))
        Dim left = 0
        Dim firstRow = True
        For r = 0 To gridShip.RowCount - 1
            If CStr(gridShip(r, "colSOrder")) <> order Then Continue For
            If firstRow Then
                left = CInt(gridShip(r, "colSOrderQty"))
                firstRow = False
            End If
            left -= CInt(If(gridShip(r, "colSShipQty"), 0))
            gridShip(r, "colSRemain") = left
        Next
    End Sub

    ''' <summary>[Shipments] button in Sales Orders → go to the Shipments sheet filtered to that order</summary>
    Private Sub gridOrders_CellButtonClick(sender As Object, e As NoxGridCellEventArgs) Handles gridOrders.CellButtonClick
        Dim order = CStr(gridOrders(e.RowIndex, "colNo"))
        gridShip.SetFilter(colSOrder, {order})
        NoxGridBook1.ActiveSheet = sheetShip
        lblStatus.Text = order & ": " & gridShip.VisibleRowCount & " shipment(s)" & If(gridShip.VisibleRowCount = 0, " (nothing shipped yet)", "") & " · Clear Filter to show all"
    End Sub

    Private Sub Grid_StateChanged(sender As Object, e As EventArgs) Handles gridOrders.UndoStateChanged, gridShip.UndoStateChanged, gridStats.UndoStateChanged, gridBoard.UndoStateChanged, gridBoard.SelectionChanged,
                                                                          gridOrders.SelectionChanged, gridShip.SelectionChanged, gridStats.SelectionChanged,
                                                                          gridOrders.FilterChanged, gridShip.FilterChanged, gridBoard.FilterChanged, NoxGridBook1.ActiveSheetChanged
        UpdateStatus()
    End Sub

    Private Sub UpdateStatus()
        Dim g = NoxGridBook1.ActiveGrid
        If g Is Nothing Then Return
        btnUndo.Enabled = g.CanUndo
        btnRedo.Enabled = g.CanRedo
        btnUndo.ToolTipText = If(g.CanUndo, "Undo: " & g.UndoActionName & " (Ctrl+Z)", "Undo (Ctrl+Z)")
        btnRedo.ToolTipText = If(g.CanRedo, "Redo: " & g.RedoActionName & " (Ctrl+Y)", "Redo (Ctrl+Y)")
        lblUndo.Text = If(g.CanUndo, "Last action: " & g.UndoActionName, "")
        btnAddRow.Enabled = g Is gridOrders
        btnDeleteRows.Enabled = g IsNot gridStats
        Dim text = String.Format("[{0}]  Rows {1:#,##0}  ·  Visible {2:#,##0}  ·  Selected {3:#,##0} cells",
                                 NoxGridBook1.ActiveSheet.Text, g.RowCount, g.VisibleRowCount, g.SelectedCellCount)
        If g Is gridOrders Then
            ' total amount of the visible orders (subtotal rows excluded)
            Dim sum = 0D
            For r = 0 To gridOrders.RowCount - 1
                If gridOrders.IsSubtotalRow(r) OrElse Not gridOrders.IsRowVisible(r) Then Continue For
                Dim v = gridOrders(r, "colAmount")
                If TypeOf v Is Double OrElse TypeOf v Is Decimal Then sum += Convert.ToDecimal(v)
            Next
            text &= String.Format("  ·  Total amount ${0:#,##0.00}", sum)
        End If
        lblStatus.Text = text
    End Sub

    ' ================================================================ Toolbar

    Private Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        ' Changes made in code can be undone in one step when wrapped in BeginUndoAction ... EndUndoAction
        gridOrders.BeginUndoAction("Add order")
        Dim i = gridOrders.Rows.Add("SO-" & (260001 + gridOrders.RowCount).ToString(), Nothing, Nothing, 1, Nothing, Nothing,
                                    SampleData.Today, SampleData.Today.AddDays(14), False, "Received", "")
        gridOrders.SetFormula(i, colAmount.Index, "=D" & (i + 1) & "*E" & (i + 1))
        gridOrders.EndUndoAction()
        gridOrders.SetCurrentCell(i, colCustomer.Index)
        gridOrders.Focus()
    End Sub

    Private Sub btnDeleteRows_Click(sender As Object, e As EventArgs) Handles btnDeleteRows.Click
        Dim g = NoxGridBook1.ActiveGrid
        Dim rows = g.GetSelectedRows()
        If rows.Length = 0 Then Return
        If MessageBox.Show(Me, "Delete " & rows.Length & " row(s)? (You can undo this.)", "Delete Rows", MessageBoxButtons.OKCancel) = DialogResult.OK Then
            g.RemoveSelectedRows()
        End If
    End Sub

    Private Sub btnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        NoxGridBook1.ActiveGrid.Undo()
    End Sub

    Private Sub btnRedo_Click(sender As Object, e As EventArgs) Handles btnRedo.Click
        NoxGridBook1.ActiveGrid.Redo()
    End Sub

    ''' <summary>Sales Orders: add/remove quantity and amount subtotals per customer (sort → AddSubtotals, undoable)</summary>
    Private Sub btnSubtotal_Click(sender As Object, e As EventArgs) Handles btnSubtotal.Click
        NoxGridBook1.ActiveSheet = sheetOrders
        If gridOrders.RowGroups.Count > 0 Then
            gridOrders.RemoveSubtotals()
            btnSubtotal.Checked = False
            Return
        End If
        gridOrders.BeginUndoAction("Subtotals by customer")
        gridOrders.Sort(colCustomer, NoxSortOrder.Ascending)
        gridOrders.AddSubtotals(colCustomer, NoxSubtotalFunction.Sum, colQty, colAmount)
        gridOrders.EndUndoAction()
        gridOrders.ShowOutlineLevel(2)       ' collapse to customer subtotals (expand with [+] on the left)
        btnSubtotal.Checked = True
    End Sub

    ''' <summary>Sales Orders: only open orders past their due date (two-column filter: a predicate on the date, a value list on the status)</summary>
    Private Sub btnLate_Click(sender As Object, e As EventArgs) Handles btnLate.Click
        NoxGridBook1.ActiveSheet = sheetOrders
        gridOrders.SetFilter(colDue, Function(v) TypeOf v Is Date AndAlso CDate(v) < SampleData.Today)
        gridOrders.SetFilter(colStatus, {"Received", "In production", "Shipping"})
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs) Handles txtFind.TextChanged
        ' filter the board, orders and shipments sheets by customer text
        gridBoard.SetFilterContains(colBCustomer, txtFind.Text)
        gridOrders.SetFilterContains(colCustomer, txtFind.Text)
        gridShip.SetFilterContains(colSCustomer, txtFind.Text)
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        txtFind.Text = ""
        For Each sheet In NoxGridBook1.Sheets
            sheet.Grid.ClearFilters()
        Next
    End Sub

    ''' <summary>Imports an Excel (.xlsx) or CSV file into a new sheet (values, formulas, colors, merges, column widths)</summary>
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Using dlg As New OpenFileDialog With {.Filter = "Excel Workbook (*.xlsx)|*.xlsx|CSV / Text (*.csv;*.txt)|*.csv;*.txt"}
            If dlg.ShowDialog(Me) <> DialogResult.OK Then Return
            Dim sheet = NoxGridBook1.Sheets.Add(IO.Path.GetFileNameWithoutExtension(dlg.FileName))
            Dim g = sheet.Grid
            Try
                If dlg.FileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase) Then
                    ' First sheet only. To import every sheet as its own sheet use NoxGridBook1.ImportFromExcel(path) (replaces the existing sheets)
                    g.ImportFromExcel(dlg.FileName)
                Else
                    g.ImportFromCsv(dlg.FileName)
                End If
            Catch ex As Exception When TypeOf ex Is IO.IOException OrElse TypeOf ex Is NotSupportedException OrElse TypeOf ex Is IO.InvalidDataException
                NoxGridBook1.Sheets.Remove(sheet)
                MessageBox.Show(Me, ex.Message, "Import", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End Try
            g.AllowUserFormulas = True
            g.PrintSettings.Title = sheet.Text
            g.PrintSettings.Landscape = True
            AddHandler g.UndoStateChanged, AddressOf Grid_StateChanged
            AddHandler g.SelectionChanged, AddressOf Grid_StateChanged
            AddHandler g.FilterChanged, AddressOf Grid_StateChanged
            NoxGridBook1.ActiveSheet = sheet
            UpdateStatus()
        End Using
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Using dlg As New SaveFileDialog With {.Filter = "Excel Workbook (*.xlsx)|*.xlsx", .FileName = "Sales Orders " & Date.Today.ToString("yyyyMMdd") & ".xlsx"}
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                ' All sheets → one file (one Excel sheet per sheet, with formulas, colors, merges, filters and frozen panes)
                NoxGridBook1.ExportToExcel(dlg.FileName)
                If MessageBox.Show(Me, "Saved. Open it now?", "Save to Excel", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Process.Start(dlg.FileName)
                End If
            End If
        End Using
    End Sub

    Private Sub btnCsv_Click(sender As Object, e As EventArgs) Handles btnCsv.Click
        Using dlg As New SaveFileDialog With {.Filter = "CSV (*.csv)|*.csv", .FileName = NoxGridBook1.ActiveSheet.Text & ".csv"}
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                NoxGridBook1.ActiveGrid.ExportToCsv(dlg.FileName)
            End If
        End Using
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        NoxGridBook1.PrintPreview()
    End Sub

    Private Sub btnPreviewAll_Click(sender As Object, e As EventArgs) Handles btnPreviewAll.Click
        ' every sheet in turn (orientation and title per sheet)
        NoxGridBook1.PrintPreviewAll()
    End Sub

    Private Sub cboScheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboScheme.SelectedIndexChanged
        Dim scheme = CType([Enum].Parse(GetType(NoxGridColorScheme), CStr(cboScheme.SelectedItem)), NoxGridColorScheme)
        For Each sheet In NoxGridBook1.Sheets
            sheet.Grid.ColorScheme = scheme
        Next
    End Sub

End Class
