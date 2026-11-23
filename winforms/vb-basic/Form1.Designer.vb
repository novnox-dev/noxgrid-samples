<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.NoxGrid1 = New Nox.Grid.WinForms.NoxGrid()
        Me.colSpecimen = New Nox.Grid.WinForms.NoxGridColumn()
        Me.colName = New Nox.Grid.WinForms.NoxGridColumn()
        Me.colDate = New Nox.Grid.WinForms.NoxGridDateColumn()
        Me.colAmount = New Nox.Grid.WinForms.NoxGridNumberColumn()
        Me.colUrgent = New Nox.Grid.WinForms.NoxGridCheckBoxColumn()
        Me.colKind = New Nox.Grid.WinForms.NoxGridComboBoxColumn()
        Me.colAction = New Nox.Grid.WinForms.NoxGridButtonColumn()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.ToolPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnCsv = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnAddRow = New System.Windows.Forms.Button()
        Me.btnDeleteRows = New System.Windows.Forms.Button()
        Me.btnClearFilter = New System.Windows.Forms.Button()
        Me.btnMerge = New System.Windows.Forms.Button()
        Me.cboScheme = New System.Windows.Forms.ComboBox()
        CType(Me.NoxGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'NoxGrid1
        '
        Me.NoxGrid1.AllowFiltering = True
        Me.NoxGrid1.AllowUserToOrderColumns = True
        Me.NoxGrid1.Columns.AddRange(New Nox.Grid.WinForms.NoxGridColumn() {Me.colSpecimen, Me.colName, Me.colDate, Me.colAmount, Me.colUrgent, Me.colKind, Me.colAction})
        Me.NoxGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NoxGrid1.Location = New System.Drawing.Point(0, 36)
        Me.NoxGrid1.Name = "NoxGrid1"
        Me.NoxGrid1.RowHeadersVisible = True
        Me.NoxGrid1.Size = New System.Drawing.Size(884, 501)
        Me.NoxGrid1.TabIndex = 1
        '
        'colSpecimen
        '
        Me.colSpecimen.DataPropertyName = "SpecimenNo"
        Me.colSpecimen.Frozen = True
        Me.colSpecimen.HeaderText = "Specimen No."
        Me.colSpecimen.Name = "colSpecimen"
        Me.colSpecimen.ReadOnly = True
        Me.colSpecimen.Width = 110
        '
        'colName
        '
        Me.colName.HeaderText = "Patient"
        Me.colName.Name = "colName"
        '
        'colDate
        '
        Me.colDate.HeaderText = "Received"
        Me.colDate.MergeMode = Nox.Grid.WinForms.NoxMergeMode.Always
        Me.colDate.Name = "colDate"
        '
        'colAmount
        '
        Me.colAmount.Format = "#,##0"
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        '
        'colUrgent
        '
        Me.colUrgent.FalseValue = "N"
        Me.colUrgent.HeaderText = "Urgent"
        Me.colUrgent.Name = "colUrgent"
        Me.colUrgent.TrueValue = "Y"
        '
        'colKind
        '
        Me.colKind.HeaderText = "Type"
        Me.colKind.Items.AddRange(New String() {"Routine", "Retest", "External"})
        Me.colKind.Name = "colKind"
        '
        'colAction
        '
        Me.colAction.HeaderText = "Action"
        Me.colAction.Name = "colAction"
        Me.colAction.Text = "View"
        Me.colAction.UseColumnTextForButtonValue = True
        '
        'StatusLabel
        '
        Me.StatusLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusLabel.Location = New System.Drawing.Point(0, 537)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.StatusLabel.Size = New System.Drawing.Size(884, 24)
        Me.StatusLabel.TabIndex = 2
        Me.StatusLabel.Text = "F2 or type: edit / Ctrl+C, Ctrl+V: copy, paste / header ▼: filter"
        Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolPanel
        '
        Me.ToolPanel.AutoSize = True
        Me.ToolPanel.Controls.Add(Me.btnExcel)
        Me.ToolPanel.Controls.Add(Me.btnCsv)
        Me.ToolPanel.Controls.Add(Me.btnPreview)
        Me.ToolPanel.Controls.Add(Me.btnAddRow)
        Me.ToolPanel.Controls.Add(Me.btnDeleteRows)
        Me.ToolPanel.Controls.Add(Me.btnMerge)
        Me.ToolPanel.Controls.Add(Me.btnClearFilter)
        Me.ToolPanel.Controls.Add(Me.cboScheme)
        Me.ToolPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolPanel.Location = New System.Drawing.Point(0, 0)
        Me.ToolPanel.Name = "ToolPanel"
        Me.ToolPanel.Padding = New System.Windows.Forms.Padding(4)
        Me.ToolPanel.Size = New System.Drawing.Size(884, 36)
        Me.ToolPanel.TabIndex = 0
        '
        'btnExcel
        '
        Me.btnExcel.AutoSize = True
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.TabIndex = 0
        Me.btnExcel.Text = "Save Excel"
        '
        'btnCsv
        '
        Me.btnCsv.AutoSize = True
        Me.btnCsv.Name = "btnCsv"
        Me.btnCsv.TabIndex = 1
        Me.btnCsv.Text = "Save CSV"
        '
        'btnPreview
        '
        Me.btnPreview.AutoSize = True
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.TabIndex = 2
        Me.btnPreview.Text = "Print Preview"
        '
        'btnAddRow
        '
        Me.btnAddRow.AutoSize = True
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.TabIndex = 3
        Me.btnAddRow.Text = "Add Row"
        '
        'btnDeleteRows
        '
        Me.btnDeleteRows.AutoSize = True
        Me.btnDeleteRows.Name = "btnDeleteRows"
        Me.btnDeleteRows.TabIndex = 4
        Me.btnDeleteRows.Text = "Delete Rows"
        '
        'btnMerge
        '
        Me.btnMerge.AutoSize = True
        Me.btnMerge.Name = "btnMerge"
        Me.btnMerge.TabIndex = 5
        Me.btnMerge.Text = "Merge Selection"
        '
        'btnClearFilter
        '
        Me.btnClearFilter.AutoSize = True
        Me.btnClearFilter.Name = "btnClearFilter"
        Me.btnClearFilter.TabIndex = 6
        Me.btnClearFilter.Text = "Clear Filter"
        '
        'cboScheme
        '
        Me.cboScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScheme.Margin = New System.Windows.Forms.Padding(12, 4, 3, 3)
        Me.cboScheme.Name = "cboScheme"
        Me.cboScheme.Size = New System.Drawing.Size(110, 20)
        Me.cboScheme.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.NoxGrid1)
        Me.Controls.Add(Me.ToolPanel)
        Me.Controls.Add(Me.StatusLabel)
        Me.Name = "Form1"
        Me.Text = "NoxGrid VB Sample"
        CType(Me.NoxGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolPanel.ResumeLayout(False)
        Me.ToolPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NoxGrid1 As Nox.Grid.WinForms.NoxGrid
    Friend WithEvents colSpecimen As Nox.Grid.WinForms.NoxGridColumn
    Friend WithEvents colName As Nox.Grid.WinForms.NoxGridColumn
    Friend WithEvents colDate As Nox.Grid.WinForms.NoxGridDateColumn
    Friend WithEvents colAmount As Nox.Grid.WinForms.NoxGridNumberColumn
    Friend WithEvents colUrgent As Nox.Grid.WinForms.NoxGridCheckBoxColumn
    Friend WithEvents colKind As Nox.Grid.WinForms.NoxGridComboBoxColumn
    Friend WithEvents colAction As Nox.Grid.WinForms.NoxGridButtonColumn
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents ToolPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnCsv As System.Windows.Forms.Button
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnAddRow As System.Windows.Forms.Button
    Friend WithEvents btnDeleteRows As System.Windows.Forms.Button
    Friend WithEvents btnMerge As System.Windows.Forms.Button
    Friend WithEvents btnClearFilter As System.Windows.Forms.Button
    Friend WithEvents cboScheme As System.Windows.Forms.ComboBox
End Class
