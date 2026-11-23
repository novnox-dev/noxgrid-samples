<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnAddRow = New System.Windows.Forms.ToolStripButton()
        Me.btnDeleteRows = New System.Windows.Forms.ToolStripButton()
        Me.sep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnUndo = New System.Windows.Forms.ToolStripButton()
        Me.btnRedo = New System.Windows.Forms.ToolStripButton()
        Me.sep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnSubtotal = New System.Windows.Forms.ToolStripButton()
        Me.btnLate = New System.Windows.Forms.ToolStripButton()
        Me.sep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblFind = New System.Windows.Forms.ToolStripLabel()
        Me.txtFind = New System.Windows.Forms.ToolStripTextBox()
        Me.btnClearFilter = New System.Windows.Forms.ToolStripButton()
        Me.sep4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnImport = New System.Windows.Forms.ToolStripButton()
        Me.btnExcel = New System.Windows.Forms.ToolStripButton()
        Me.btnCsv = New System.Windows.Forms.ToolStripButton()
        Me.btnPreview = New System.Windows.Forms.ToolStripButton()
        Me.btnPreviewAll = New System.Windows.Forms.ToolStripButton()
        Me.sep5 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblScheme = New System.Windows.Forms.ToolStripLabel()
        Me.cboScheme = New System.Windows.Forms.ToolStripComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUndo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.NoxGridBook1 = New Nox.Grid.WinForms.NoxGridBook()
        Me.sheetBoard = New Nox.Grid.WinForms.NoxGridSheet()
        Me.gridBoard = New Nox.Grid.WinForms.NoxGrid()
        Me.colBStatus = New Nox.Grid.WinForms.NoxGridImageColumn()
        Me.colBOrder = New Nox.Grid.WinForms.NoxGridLabelColumn()
        Me.colBCustomer = New Nox.Grid.WinForms.NoxGridLabelColumn()
        Me.colBRep = New Nox.Grid.WinForms.NoxGridColumn()
        Me.colBQty = New Nox.Grid.WinForms.NoxGridNumberColumn()
        Me.colBProgress = New Nox.Grid.WinForms.NoxGridProgressColumn()
        Me.colBDue = New Nox.Grid.WinForms.NoxGridDateColumn()
        Me.colBMemo = New Nox.Grid.WinForms.NoxGridColumn()
        Me.imgStatus = New System.Windows.Forms.ImageList(Me.components)
        Me.sheetOrders = New Nox.Grid.WinForms.NoxGridSheet()
        Me.gridOrders = New Nox.Grid.WinForms.NoxGrid()
        Me.colNo = New Nox.Grid.WinForms.NoxGridColumn()
        Me.colCustomer = New Nox.Grid.WinForms.NoxGridComboBoxColumn()
        Me.colItem = New Nox.Grid.WinForms.NoxGridComboBoxColumn()
        Me.colQty = New Nox.Grid.WinForms.NoxGridNumberColumn()
        Me.colPrice = New Nox.Grid.WinForms.NoxGridNumberColumn()
        Me.colAmount = New Nox.Grid.WinForms.NoxGridNumberColumn()
        Me.colOrdered = New Nox.Grid.WinForms.NoxGridDateColumn()
        Me.colDue = New Nox.Grid.WinForms.NoxGridDateColumn()
        Me.colUrgent = New Nox.Grid.WinForms.NoxGridCheckBoxColumn()
        Me.colStatus = New Nox.Grid.WinForms.NoxGridComboBoxColumn()
        Me.colMemo = New Nox.Grid.WinForms.NoxGridColumn()
        Me.colShip = New Nox.Grid.WinForms.NoxGridButtonColumn()
        Me.sheetShip = New Nox.Grid.WinForms.NoxGridSheet()
        Me.gridShip = New Nox.Grid.WinForms.NoxGrid()
        Me.colSOrder = New Nox.Grid.WinForms.NoxGridColumn()
        Me.colSCustomer = New Nox.Grid.WinForms.NoxGridColumn()
        Me.colSDate = New Nox.Grid.WinForms.NoxGridDateColumn()
        Me.colSItem = New Nox.Grid.WinForms.NoxGridColumn()
        Me.colSOrderQty = New Nox.Grid.WinForms.NoxGridNumberColumn()
        Me.colSShipQty = New Nox.Grid.WinForms.NoxGridNumberColumn()
        Me.colSRemain = New Nox.Grid.WinForms.NoxGridNumberColumn()
        Me.colSCarrier = New Nox.Grid.WinForms.NoxGridColumn()
        Me.colSInvoice = New Nox.Grid.WinForms.NoxGridColumn()
        Me.colSState = New Nox.Grid.WinForms.NoxGridColumn()
        Me.sheetStats = New Nox.Grid.WinForms.NoxGridSheet()
        Me.gridStats = New Nox.Grid.WinForms.NoxGrid()
        Me.colTKey = New Nox.Grid.WinForms.NoxGridColumn()
        Me.colTCount = New Nox.Grid.WinForms.NoxGridNumberColumn()
        Me.colTUrgent = New Nox.Grid.WinForms.NoxGridNumberColumn()
        Me.colTAmount = New Nox.Grid.WinForms.NoxGridNumberColumn()
        Me.colTShare = New Nox.Grid.WinForms.NoxGridNumberColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.NoxGridBook1.SuspendLayout()
        Me.sheetBoard.SuspendLayout()
        CType(Me.gridBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sheetOrders.SuspendLayout()
        CType(Me.gridOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sheetShip.SuspendLayout()
        CType(Me.gridShip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sheetStats.SuspendLayout()
        CType(Me.gridStats, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAddRow, Me.btnDeleteRows, Me.sep1, Me.btnUndo, Me.btnRedo, Me.sep2, Me.btnSubtotal, Me.btnLate, Me.sep3, Me.lblFind, Me.txtFind, Me.btnClearFilter, Me.sep4, Me.btnImport, Me.btnExcel, Me.btnCsv, Me.btnPreview, Me.btnPreviewAll, Me.sep5, Me.lblScheme, Me.cboScheme})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.ToolStrip1.Size = New System.Drawing.Size(1184, 29)
        Me.ToolStrip1.TabIndex = 0
        '
        'btnAddRow
        '
        Me.btnAddRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Text = "Add Order"
        Me.btnAddRow.ToolTipText = "Add a new order at the end of Sales Orders"
        '
        'btnDeleteRows
        '
        Me.btnDeleteRows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnDeleteRows.Name = "btnDeleteRows"
        Me.btnDeleteRows.Text = "Delete Rows"
        '
        'sep1
        '
        Me.sep1.Name = "sep1"
        '
        'btnUndo
        '
        Me.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnUndo.Enabled = False
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Text = "↶ Undo"
        Me.btnUndo.ToolTipText = "Undo (Ctrl+Z)"
        '
        'btnRedo
        '
        Me.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnRedo.Enabled = False
        Me.btnRedo.Name = "btnRedo"
        Me.btnRedo.Text = "↷ Redo"
        Me.btnRedo.ToolTipText = "Redo (Ctrl+Y)"
        '
        'sep2
        '
        Me.sep2.Name = "sep2"
        '
        'btnSubtotal
        '
        Me.btnSubtotal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnSubtotal.Name = "btnSubtotal"
        Me.btnSubtotal.Text = "Subtotals"
        Me.btnSubtotal.ToolTipText = "Group Sales Orders by customer and add / remove quantity and amount subtotals (collapse with [-] [+] on the left)"
        '
        'btnLate
        '
        Me.btnLate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnLate.Name = "btnLate"
        Me.btnLate.Text = "Past Due"
        Me.btnLate.ToolTipText = "Show only open orders past their due date"
        '
        'sep3
        '
        Me.sep3.Name = "sep3"
        '
        'lblFind
        '
        Me.lblFind.Name = "lblFind"
        Me.lblFind.Text = "Find customer"
        '
        'txtFind
        '
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(100, 25)
        '
        'btnClearFilter
        '
        Me.btnClearFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.Text = "Clear Filter"
        '
        'sep4
        '
        Me.sep4.Name = "sep4"
        '
        'btnImport
        '
        Me.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Text = "Open Excel"
        Me.btnImport.ToolTipText = "Import an Excel (.xlsx) or CSV file into a new sheet"
        '
        'btnExcel
        '
        Me.btnExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Text = "Save Excel"
        Me.btnExcel.ToolTipText = "Save all sheets to one Excel file"
        '
        'btnCsv
        '
        Me.btnCsv.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnCsv.Name = "btnCsv"
        Me.btnCsv.Text = "Save CSV"
        Me.btnCsv.ToolTipText = "Save the current sheet as CSV"
        '
        'btnPreview
        '
        Me.btnPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Text = "Preview"
        '
        'btnPreviewAll
        '
        Me.btnPreviewAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnPreviewAll.Name = "btnPreviewAll"
        Me.btnPreviewAll.Text = "Preview All"
        Me.btnPreviewAll.ToolTipText = "Print preview of every sheet in turn"
        '
        'sep5
        '
        Me.sep5.Name = "sep5"
        '
        'lblScheme
        '
        Me.lblScheme.Name = "lblScheme"
        Me.lblScheme.Text = "Color scheme"
        '
        'cboScheme
        '
        Me.cboScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScheme.Name = "cboScheme"
        Me.cboScheme.Size = New System.Drawing.Size(90, 25)
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.lblUndo})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 639)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1184, 22)
        Me.StatusStrip1.TabIndex = 2
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Spring = True
        Me.lblStatus.Text = "Ready"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUndo
        '
        Me.lblUndo.Name = "lblUndo"
        Me.lblUndo.Text = ""
        '
        'NoxGridBook1
        '
        Me.NoxGridBook1.Controls.Add(Me.sheetBoard)
        Me.NoxGridBook1.Controls.Add(Me.sheetOrders)
        Me.NoxGridBook1.Controls.Add(Me.sheetShip)
        Me.NoxGridBook1.Controls.Add(Me.sheetStats)
        Me.NoxGridBook1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NoxGridBook1.Location = New System.Drawing.Point(0, 29)
        Me.NoxGridBook1.Name = "NoxGridBook1"
        Me.NoxGridBook1.Size = New System.Drawing.Size(1184, 610)
        Me.NoxGridBook1.TabIndex = 1
        '
        'sheetBoard
        '
        Me.sheetBoard.Controls.Add(Me.gridBoard)
        Me.sheetBoard.Location = New System.Drawing.Point(0, 0)
        Me.sheetBoard.Name = "sheetBoard"
        Me.sheetBoard.Size = New System.Drawing.Size(1184, 584)
        Me.sheetBoard.TabIndex = 0
        Me.sheetBoard.Text = "Shipping Board"
        '
        'gridBoard (Modern color scheme: bold headers, horizontal lines only, read-only cell color)
        '
        Me.gridBoard.AccentColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.gridBoard.AllowFiltering = True
        Me.gridBoard.AlternatingRowBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.gridBoard.BackColor = System.Drawing.Color.White
        Me.gridBoard.Columns.AddRange(New Nox.Grid.WinForms.NoxGridColumn() {Me.colBStatus, Me.colBOrder, Me.colBCustomer, Me.colBRep, Me.colBQty, Me.colBProgress, Me.colBDue, Me.colBMemo})
        Me.gridBoard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridBoard.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.gridBoard.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.gridBoard.HeaderBackColor = System.Drawing.Color.White
        Me.gridBoard.HeaderBold = True
        Me.gridBoard.HeaderForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.gridBoard.HeaderHeight = 38
        Me.gridBoard.Location = New System.Drawing.Point(0, 0)
        Me.gridBoard.Name = "gridBoard"
        Me.gridBoard.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.gridBoard.ReadOnlyForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.gridBoard.RowHeight = 34
        Me.gridBoard.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gridBoard.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.gridBoard.SelectionMode = Nox.Grid.WinForms.NoxGridSelectionMode.FullRowSelect
        Me.gridBoard.Size = New System.Drawing.Size(1184, 584)
        Me.gridBoard.TabIndex = 0
        Me.gridBoard.VerticalGridLines = False
        '
        'colBStatus
        '
        Me.colBStatus.Alignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.colBStatus.HeaderText = "Status"
        Me.colBStatus.ImageList = Me.imgStatus
        Me.colBStatus.Name = "colBStatus"
        Me.colBStatus.ShowText = True
        Me.colBStatus.Width = 90
        '
        'colBOrder
        '
        Me.colBOrder.HeaderText = "Order No."
        Me.colBOrder.Name = "colBOrder"
        Me.colBOrder.Width = 110
        '
        'colBCustomer
        '
        Me.colBCustomer.HeaderText = "Customer"
        Me.colBCustomer.Name = "colBCustomer"
        Me.colBCustomer.Width = 140
        '
        'colBRep
        '
        Me.colBRep.HeaderText = "Sales Rep"
        Me.colBRep.MergeMode = Nox.Grid.WinForms.NoxMergeMode.Always
        Me.colBRep.Name = "colBRep"
        Me.colBRep.Width = 120
        '
        'colBQty
        '
        Me.colBQty.Format = "#,##0"
        Me.colBQty.HeaderText = "Qty"
        Me.colBQty.Name = "colBQty"
        Me.colBQty.Width = 70
        '
        'colBProgress
        '
        Me.colBProgress.HeaderText = "Shipped"
        Me.colBProgress.Name = "colBProgress"
        Me.colBProgress.Width = 200
        '
        'colBDue
        '
        Me.colBDue.Format = "yyyy-MM-dd"
        Me.colBDue.HeaderText = "Due"
        Me.colBDue.Name = "colBDue"
        Me.colBDue.Width = 100
        '
        'colBMemo
        '
        Me.colBMemo.HeaderText = "Memo (editable)"
        Me.colBMemo.MaxLength = 40
        Me.colBMemo.Name = "colBMemo"
        Me.colBMemo.Width = 220
        '
        'imgStatus
        '
        Me.imgStatus.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imgStatus.ImageSize = New System.Drawing.Size(14, 14)
        Me.imgStatus.TransparentColor = System.Drawing.Color.Transparent
        '
        'sheetOrders
        '
        Me.sheetOrders.Controls.Add(Me.gridOrders)
        Me.sheetOrders.Location = New System.Drawing.Point(0, 0)
        Me.sheetOrders.Name = "sheetOrders"
        Me.sheetOrders.Size = New System.Drawing.Size(1184, 584)
        Me.sheetOrders.TabIndex = 1
        Me.sheetOrders.Text = "Sales Orders"
        '
        'gridOrders
        '
        Me.gridOrders.AllowFiltering = True
        Me.gridOrders.AllowUserToOrderColumns = True
        Me.gridOrders.AllowUserFormulas = True
        Me.gridOrders.Columns.AddRange(New Nox.Grid.WinForms.NoxGridColumn() {Me.colNo, Me.colCustomer, Me.colItem, Me.colQty, Me.colPrice, Me.colAmount, Me.colOrdered, Me.colDue, Me.colUrgent, Me.colStatus, Me.colMemo, Me.colShip})
        Me.gridOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridOrders.Location = New System.Drawing.Point(0, 0)
        Me.gridOrders.Name = "gridOrders"
        Me.gridOrders.RowHeadersVisible = True
        Me.gridOrders.Size = New System.Drawing.Size(1184, 584)
        Me.gridOrders.TabIndex = 0
        '
        'colNo
        '
        Me.colNo.Frozen = True
        Me.colNo.HeaderText = "Order No."
        Me.colNo.Name = "colNo"
        Me.colNo.ReadOnly = True
        Me.colNo.Width = 100
        '
        'colCustomer
        '
        Me.colCustomer.HeaderText = "Customer"
        Me.colCustomer.Items.AddRange(New String() {"Customer A", "Customer B", "Customer C", "Customer D", "Customer E", "Customer F", "Customer G", "Customer H"})
        Me.colCustomer.Name = "colCustomer"
        Me.colCustomer.Required = True
        Me.colCustomer.Width = 150
        '
        'colItem
        '
        Me.colItem.HeaderText = "Item"
        Me.colItem.Items.AddRange(New String() {"Steel Bracket A", "Bearing 6204", "Hydraulic Hose", "Control Panel", "LED Module", "Gear Motor 0.4kW", "Sensor Kit", "Shipping Box L"})
        Me.colItem.Name = "colItem"
        Me.colItem.Required = True
        Me.colItem.Width = 140
        '
        'colQty
        '
        Me.colQty.Format = "#,##0"
        Me.colQty.HeaderText = "Qty"
        Me.colQty.MinimumValue = "1"
        Me.colQty.Name = "colQty"
        Me.colQty.ValueType = GetType(Integer)
        Me.colQty.Width = 70
        '
        'colPrice
        '
        Me.colPrice.Format = "#,##0.00"
        Me.colPrice.HeaderText = "Unit Price"
        Me.colPrice.MinimumValue = "0"
        Me.colPrice.Name = "colPrice"
        Me.colPrice.Width = 90
        '
        'colAmount
        '
        Me.colAmount.Format = "#,##0.00"
        Me.colAmount.HeaderText = "Amount (formula)"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 140
        '
        'colOrdered
        '
        Me.colOrdered.Format = "yyyy-MM-dd"
        Me.colOrdered.HeaderText = "Ordered"
        Me.colOrdered.Name = "colOrdered"
        '
        'colDue
        '
        Me.colDue.Format = "yyyy-MM-dd"
        Me.colDue.HeaderText = "Due"
        Me.colDue.Name = "colDue"
        '
        'colUrgent
        '
        Me.colUrgent.HeaderText = "Urgent"
        Me.colUrgent.Name = "colUrgent"
        Me.colUrgent.Width = 72
        '
        'colStatus
        '
        Me.colStatus.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.Items.AddRange(New String() {"Received", "In production", "Shipping", "Completed", "On hold"})
        Me.colStatus.Name = "colStatus"
        Me.colStatus.Width = 100
        '
        'colMemo
        '
        Me.colMemo.HeaderText = "Notes"
        Me.colMemo.Name = "colMemo"
        Me.colMemo.Width = 180
        '
        'colShip
        '
        Me.colShip.HeaderText = "Shipping"
        Me.colShip.Name = "colShip"
        Me.colShip.Text = "Shipments"
        Me.colShip.UseColumnTextForButtonValue = True
        '
        'sheetShip
        '
        Me.sheetShip.Controls.Add(Me.gridShip)
        Me.sheetShip.Location = New System.Drawing.Point(0, 0)
        Me.sheetShip.Name = "sheetShip"
        Me.sheetShip.Size = New System.Drawing.Size(1184, 584)
        Me.sheetShip.TabIndex = 2
        Me.sheetShip.Text = "Shipments"
        '
        'gridShip
        '
        Me.gridShip.AllowFiltering = True
        Me.gridShip.Columns.AddRange(New Nox.Grid.WinForms.NoxGridColumn() {Me.colSOrder, Me.colSCustomer, Me.colSDate, Me.colSItem, Me.colSOrderQty, Me.colSShipQty, Me.colSRemain, Me.colSCarrier, Me.colSInvoice, Me.colSState})
        Me.gridShip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridShip.Location = New System.Drawing.Point(0, 0)
        Me.gridShip.Name = "gridShip"
        Me.gridShip.Size = New System.Drawing.Size(1184, 584)
        Me.gridShip.TabIndex = 0
        '
        'colSOrder
        '
        Me.colSOrder.DataPropertyName = "OrderNo"
        Me.colSOrder.Frozen = True
        Me.colSOrder.HeaderText = "Order No."
        Me.colSOrder.MergeMode = Nox.Grid.WinForms.NoxMergeMode.Always
        Me.colSOrder.Name = "colSOrder"
        Me.colSOrder.ReadOnly = True
        Me.colSOrder.Width = 100
        '
        'colSCustomer
        '
        Me.colSCustomer.DataPropertyName = "Customer"
        Me.colSCustomer.HeaderText = "Customer"
        Me.colSCustomer.MergeMode = Nox.Grid.WinForms.NoxMergeMode.Restricted
        Me.colSCustomer.Name = "colSCustomer"
        Me.colSCustomer.ReadOnly = True
        Me.colSCustomer.Width = 140
        '
        'colSDate
        '
        Me.colSDate.DataPropertyName = "Shipped"
        Me.colSDate.Format = "yyyy-MM-dd"
        Me.colSDate.HeaderText = "Shipped"
        Me.colSDate.Name = "colSDate"
        '
        'colSItem
        '
        Me.colSItem.DataPropertyName = "ItemName"
        Me.colSItem.HeaderText = "Item"
        Me.colSItem.Name = "colSItem"
        Me.colSItem.ReadOnly = True
        Me.colSItem.Width = 140
        '
        'colSOrderQty
        '
        Me.colSOrderQty.DataPropertyName = "OrderQty"
        Me.colSOrderQty.Format = "#,##0"
        Me.colSOrderQty.HeaderText = "Order Qty"
        Me.colSOrderQty.Name = "colSOrderQty"
        Me.colSOrderQty.ReadOnly = True
        Me.colSOrderQty.Width = 92
        '
        'colSShipQty
        '
        Me.colSShipQty.DataPropertyName = "ShipQty"
        Me.colSShipQty.Format = "#,##0"
        Me.colSShipQty.HeaderText = "Ship Qty"
        Me.colSShipQty.MinimumValue = "0"
        Me.colSShipQty.Name = "colSShipQty"
        Me.colSShipQty.Width = 92
        '
        'colSRemain
        '
        Me.colSRemain.DataPropertyName = "Remaining"
        Me.colSRemain.Format = "#,##0"
        Me.colSRemain.HeaderText = "Remaining"
        Me.colSRemain.Name = "colSRemain"
        Me.colSRemain.ReadOnly = True
        Me.colSRemain.Width = 100
        '
        'colSCarrier
        '
        Me.colSCarrier.DataPropertyName = "Carrier"
        Me.colSCarrier.HeaderText = "Carrier"
        Me.colSCarrier.Name = "colSCarrier"
        Me.colSCarrier.Width = 130
        '
        'colSInvoice
        '
        Me.colSInvoice.DataPropertyName = "Invoice"
        Me.colSInvoice.HeaderText = "Tracking No."
        Me.colSInvoice.Name = "colSInvoice"
        Me.colSInvoice.ReadOnly = True
        Me.colSInvoice.Width = 110
        '
        'colSState
        '
        Me.colSState.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.colSState.DataPropertyName = "State"
        Me.colSState.HeaderText = "Delivery"
        Me.colSState.Name = "colSState"
        Me.colSState.Width = 90
        '
        'sheetStats
        '
        Me.sheetStats.Controls.Add(Me.gridStats)
        Me.sheetStats.Location = New System.Drawing.Point(0, 0)
        Me.sheetStats.Name = "sheetStats"
        Me.sheetStats.Size = New System.Drawing.Size(1184, 584)
        Me.sheetStats.TabIndex = 3
        Me.sheetStats.Text = "By Customer"
        '
        'gridStats
        '
        Me.gridStats.AllowUserFormulas = True
        Me.gridStats.Columns.AddRange(New Nox.Grid.WinForms.NoxGridColumn() {Me.colTKey, Me.colTCount, Me.colTUrgent, Me.colTAmount, Me.colTShare})
        Me.gridStats.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridStats.Location = New System.Drawing.Point(0, 0)
        Me.gridStats.Name = "gridStats"
        Me.gridStats.RowHeight = 28
        Me.gridStats.Size = New System.Drawing.Size(1184, 584)
        Me.gridStats.TabIndex = 0
        '
        'colTKey
        '
        Me.colTKey.HeaderText = "Customer"
        Me.colTKey.Name = "colTKey"
        Me.colTKey.SortMode = Nox.Grid.WinForms.NoxGridColumnSortMode.NotSortable
        Me.colTKey.Width = 200
        '
        'colTCount
        '
        Me.colTCount.Format = "#,##0"
        Me.colTCount.HeaderText = "Orders"
        Me.colTCount.Name = "colTCount"
        '
        'colTUrgent
        '
        Me.colTUrgent.Format = "#,##0"
        Me.colTUrgent.HeaderText = "Urgent"
        Me.colTUrgent.Name = "colTUrgent"
        '
        'colTAmount
        '
        Me.colTAmount.Format = "#,##0.00"
        Me.colTAmount.HeaderText = "Order Amount"
        Me.colTAmount.Name = "colTAmount"
        Me.colTAmount.Width = 140
        '
        'colTShare
        '
        Me.colTShare.Format = "0.0%"
        Me.colTShare.HeaderText = "Share"
        Me.colTShare.Name = "colTShare"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 661)
        Me.Controls.Add(Me.NoxGridBook1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NoxGrid Demo - Sales Orders"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.NoxGridBook1.ResumeLayout(False)
        Me.sheetBoard.ResumeLayout(False)
        CType(Me.gridBoard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sheetOrders.ResumeLayout(False)
        CType(Me.gridOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sheetShip.ResumeLayout(False)
        CType(Me.gridShip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sheetStats.ResumeLayout(False)
        CType(Me.gridStats, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAddRow As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnDeleteRows As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnUndo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRedo As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnSubtotal As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnLate As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblFind As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtFind As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents btnClearFilter As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCsv As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPreview As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPreviewAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblScheme As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboScheme As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblUndo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NoxGridBook1 As Nox.Grid.WinForms.NoxGridBook
    Friend WithEvents sheetBoard As Nox.Grid.WinForms.NoxGridSheet
    Friend WithEvents gridBoard As Nox.Grid.WinForms.NoxGrid
    Friend WithEvents colBStatus As Nox.Grid.WinForms.NoxGridImageColumn
    Friend WithEvents colBOrder As Nox.Grid.WinForms.NoxGridLabelColumn
    Friend WithEvents colBCustomer As Nox.Grid.WinForms.NoxGridLabelColumn
    Friend WithEvents colBRep As Nox.Grid.WinForms.NoxGridColumn
    Friend WithEvents colBQty As Nox.Grid.WinForms.NoxGridNumberColumn
    Friend WithEvents colBProgress As Nox.Grid.WinForms.NoxGridProgressColumn
    Friend WithEvents colBDue As Nox.Grid.WinForms.NoxGridDateColumn
    Friend WithEvents colBMemo As Nox.Grid.WinForms.NoxGridColumn
    Friend WithEvents imgStatus As System.Windows.Forms.ImageList
    Friend WithEvents sheetOrders As Nox.Grid.WinForms.NoxGridSheet
    Friend WithEvents gridOrders As Nox.Grid.WinForms.NoxGrid
    Friend WithEvents colNo As Nox.Grid.WinForms.NoxGridColumn
    Friend WithEvents colCustomer As Nox.Grid.WinForms.NoxGridComboBoxColumn
    Friend WithEvents colItem As Nox.Grid.WinForms.NoxGridComboBoxColumn
    Friend WithEvents colQty As Nox.Grid.WinForms.NoxGridNumberColumn
    Friend WithEvents colPrice As Nox.Grid.WinForms.NoxGridNumberColumn
    Friend WithEvents colAmount As Nox.Grid.WinForms.NoxGridNumberColumn
    Friend WithEvents colOrdered As Nox.Grid.WinForms.NoxGridDateColumn
    Friend WithEvents colDue As Nox.Grid.WinForms.NoxGridDateColumn
    Friend WithEvents colUrgent As Nox.Grid.WinForms.NoxGridCheckBoxColumn
    Friend WithEvents colStatus As Nox.Grid.WinForms.NoxGridComboBoxColumn
    Friend WithEvents colMemo As Nox.Grid.WinForms.NoxGridColumn
    Friend WithEvents colShip As Nox.Grid.WinForms.NoxGridButtonColumn
    Friend WithEvents sheetShip As Nox.Grid.WinForms.NoxGridSheet
    Friend WithEvents gridShip As Nox.Grid.WinForms.NoxGrid
    Friend WithEvents colSOrder As Nox.Grid.WinForms.NoxGridColumn
    Friend WithEvents colSCustomer As Nox.Grid.WinForms.NoxGridColumn
    Friend WithEvents colSDate As Nox.Grid.WinForms.NoxGridDateColumn
    Friend WithEvents colSItem As Nox.Grid.WinForms.NoxGridColumn
    Friend WithEvents colSOrderQty As Nox.Grid.WinForms.NoxGridNumberColumn
    Friend WithEvents colSShipQty As Nox.Grid.WinForms.NoxGridNumberColumn
    Friend WithEvents colSRemain As Nox.Grid.WinForms.NoxGridNumberColumn
    Friend WithEvents colSCarrier As Nox.Grid.WinForms.NoxGridColumn
    Friend WithEvents colSInvoice As Nox.Grid.WinForms.NoxGridColumn
    Friend WithEvents colSState As Nox.Grid.WinForms.NoxGridColumn
    Friend WithEvents sheetStats As Nox.Grid.WinForms.NoxGridSheet
    Friend WithEvents gridStats As Nox.Grid.WinForms.NoxGrid
    Friend WithEvents colTKey As Nox.Grid.WinForms.NoxGridColumn
    Friend WithEvents colTCount As Nox.Grid.WinForms.NoxGridNumberColumn
    Friend WithEvents colTUrgent As Nox.Grid.WinForms.NoxGridNumberColumn
    Friend WithEvents colTAmount As Nox.Grid.WinForms.NoxGridNumberColumn
    Friend WithEvents colTShare As Nox.Grid.WinForms.NoxGridNumberColumn
End Class
