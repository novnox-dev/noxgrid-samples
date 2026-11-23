' Copyright © 2026 Nox. All rights reserved.

Imports Nox.Grid.WinForms

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboScheme.Items.AddRange([Enum].GetNames(GetType(NoxGridColorScheme)))
        cboScheme.SelectedIndex = 0

        ' Bulk loads go between BeginUpdate and EndUpdate (painting is suspended, so it is fast)
        Dim kinds = colKind.Items
        NoxGrid1.BeginUpdate()
        For r = 0 To 9999
            ' Rows.Add(values...) : in Columns order
            NoxGrid1.Rows.Add("S" & (r + 1).ToString("00000"),
                              "Patient " & (r + 1).ToString(),
                              Date.Today.AddDays(-(r \ 5)),
                              CDec((r * 37 Mod 500) * 100),
                              If(r Mod 7 = 0, "Y", "N"),
                              kinds(r Mod kinds.Count))
        Next
        ' Cell and row formatting
        NoxGrid1.Cells(0, "colName").BackColor = Color.Gold
        NoxGrid1.Cells(0, "colName").Bold = True
        NoxGrid1.Rows(2).BackColor = Color.FromArgb(232, 245, 233)
        NoxGrid1.Rows(4).Height = 40
        NoxGrid1.EndUpdate()

        NoxGrid1.PrintSettings.Title = "Specimens"
        NoxGrid1.PrintSettings.Footer = "NoxGrid Sample"
        NoxGrid1.PrintSettings.Landscape = True
    End Sub

    ' Conditional formatting: urgent (Y) rows in bold red
    Private Sub NoxGrid1_CellFormatting(sender As Object, e As NoxGridCellFormattingEventArgs) Handles NoxGrid1.CellFormatting
        If e.Column Is colName AndAlso Equals(NoxGrid1(e.RowIndex, "colUrgent"), "Y") Then
            e.ForeColor = Color.Firebrick
            e.Bold = True
        End If
    End Sub

    Private Sub NoxGrid1_CellButtonClick(sender As Object, e As NoxGridCellEventArgs) Handles NoxGrid1.CellButtonClick
        MessageBox.Show(Me, $"{NoxGrid1(e.RowIndex, "colSpecimen")} / {NoxGrid1(e.RowIndex, "colName")}", "View")
    End Sub

    Private Sub NoxGrid1_SelectionChanged(sender As Object, e As EventArgs) Handles NoxGrid1.SelectionChanged, NoxGrid1.FilterChanged
        StatusLabel.Text = $"Row {NoxGrid1.CurrentRowIndex + 1} · {NoxGrid1.SelectedCellCount} cell(s) selected · visible rows {NoxGrid1.VisibleRowCount:#,##0} / {NoxGrid1.RowCount:#,##0}"
    End Sub

    Private Sub NoxGrid1_DataError(sender As Object, e As NoxGridDataErrorEventArgs) Handles NoxGrid1.DataError
        StatusLabel.Text = $"Input error ({e.Column.HeaderText}): {e.Exception.Message}"
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Using dlg As New SaveFileDialog With {.Filter = "Excel Workbook (*.xlsx)|*.xlsx", .FileName = "Specimens.xlsx"}
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                NoxGrid1.ExportToExcel(dlg.FileName, New NoxExportOptions With {.SheetName = "Specimens"})
                Process.Start(dlg.FileName)
            End If
        End Using
    End Sub

    Private Sub btnCsv_Click(sender As Object, e As EventArgs) Handles btnCsv.Click
        Using dlg As New SaveFileDialog With {.Filter = "CSV (*.csv)|*.csv", .FileName = "Specimens.csv"}
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                NoxGrid1.ExportToCsv(dlg.FileName)
            End If
        End Using
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        NoxGrid1.PrintPreview()
    End Sub

    Private Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        Dim i = NoxGrid1.Rows.Add("S" & (NoxGrid1.RowCount + 1).ToString("00000"), "New patient", Date.Today, 0D, "N", "Routine")
        NoxGrid1.SetCurrentCell(i, NoxGrid1.Columns("colName").Index)
        NoxGrid1.Focus()
    End Sub

    Private Sub btnDeleteRows_Click(sender As Object, e As EventArgs) Handles btnDeleteRows.Click
        Dim n = NoxGrid1.RemoveSelectedRows()
        StatusLabel.Text = $"{n} row(s) deleted"
    End Sub

    Private Sub btnMerge_Click(sender As Object, e As EventArgs) Handles btnMerge.Click
        Dim rows = NoxGrid1.GetSelectedRows()
        If rows.Length = 0 Then Return
        ' Merge the Patient and Received columns of the selected rows into one cell
        Dim c = NoxGrid1.Columns("colName").Index
        NoxGrid1.Cells(rows.First(), c, rows.Last(), c + 1).Merge()
    End Sub

    Private Sub btnClearFilter_Click(sender As Object, e As EventArgs) Handles btnClearFilter.Click
        NoxGrid1.ClearFilters()
    End Sub

    Private Sub cboScheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboScheme.SelectedIndexChanged
        NoxGrid1.ColorScheme = CType([Enum].Parse(GetType(NoxGridColorScheme), CStr(cboScheme.SelectedItem)), NoxGridColorScheme)
    End Sub

End Class
