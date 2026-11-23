// Copyright © 2026 Nox. All rights reserved.

namespace NoxGrid.Sample.CSharp
{
    partial class Form1
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTable = new System.Windows.Forms.Button();
            this.btnVirtual = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.noxGrid1 = new Nox.Grid.WinForms.NoxGrid();
            this.toolPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noxGrid1)).BeginInit();
            this.SuspendLayout();
            //
            // toolPanel
            //
            this.toolPanel.AutoSize = true;
            this.toolPanel.Controls.Add(this.btnTable);
            this.toolPanel.Controls.Add(this.btnVirtual);
            this.toolPanel.Controls.Add(this.btnClear);
            this.toolPanel.Controls.Add(this.btnExcel);
            this.toolPanel.Controls.Add(this.btnPreview);
            this.toolPanel.Controls.Add(this.lblInfo);
            this.toolPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolPanel.Location = new System.Drawing.Point(0, 0);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Padding = new System.Windows.Forms.Padding(4);
            this.toolPanel.Size = new System.Drawing.Size(884, 39);
            this.toolPanel.TabIndex = 0;
            //
            // btnTable
            //
            this.btnTable.AutoSize = true;
            this.btnTable.Name = "btnTable";
            this.btnTable.TabIndex = 0;
            this.btnTable.Text = "DataTable 10K rows";
            this.btnTable.Click += new System.EventHandler(this.btnTable_Click);
            //
            // btnVirtual
            //
            this.btnVirtual.AutoSize = true;
            this.btnVirtual.Name = "btnVirtual";
            this.btnVirtual.TabIndex = 1;
            this.btnVirtual.Text = "Virtual 100K × 300 cols";
            this.btnVirtual.Click += new System.EventHandler(this.btnVirtual_Click);
            //
            // btnClear
            //
            this.btnClear.AutoSize = true;
            this.btnClear.Name = "btnClear";
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Disconnect";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // btnExcel
            // 
            this.btnExcel.AutoSize = true;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Text = "Save Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.AutoSize = true;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "Print Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblInfo
            //
            this.lblInfo.AutoSize = true;
            this.lblInfo.Margin = new System.Windows.Forms.Padding(8, 8, 3, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.TabIndex = 3;
            this.lblInfo.Text = "";
            //
            // noxGrid1
            //
            this.noxGrid1.AllowFiltering = true;
            this.noxGrid1.AllowUserToOrderColumns = true;
            this.noxGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noxGrid1.Location = new System.Drawing.Point(0, 39);
            this.noxGrid1.Name = "noxGrid1";
            this.noxGrid1.RowHeadersVisible = true;
            this.noxGrid1.Size = new System.Drawing.Size(884, 522);
            this.noxGrid1.TabIndex = 1;
            this.noxGrid1.CellClick += new System.EventHandler<Nox.Grid.WinForms.NoxGridCellEventArgs>(this.noxGrid1_CellClick);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.noxGrid1);
            this.Controls.Add(this.toolPanel);
            this.Name = "Form1";
            this.Text = "NoxGrid C# Sample (bound / virtual)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolPanel.ResumeLayout(false);
            this.toolPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noxGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel toolPanel;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.Button btnVirtual;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblInfo;
        private Nox.Grid.WinForms.NoxGrid noxGrid1;
    }
}
