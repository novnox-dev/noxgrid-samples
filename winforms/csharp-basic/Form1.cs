// Copyright © 2026 Nox. All rights reserved.

using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Nox.Grid;
using Nox.Grid.WinForms;

namespace NoxGrid.Sample.CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnTable_Click(this, EventArgs.Empty);
        }

        /// <summary>Bound mode: assign a DataTable and a column is created for each field (int → number, DateTime → date, bool → check box)</summary>
        private void btnTable_Click(object sender, EventArgs e)
        {
            var table = new DataTable("Result");
            table.Columns.Add("SpecimenNo", typeof(string));
            table.Columns.Add("TestCode", typeof(string));
            table.Columns.Add("Value", typeof(decimal));
            table.Columns.Add("Received", typeof(DateTime));
            table.Columns.Add("Verified", typeof(bool));
            var random = new Random(7);
            for (var i = 0; i < 10000; i++)
            {
                table.Rows.Add("S" + (i + 1).ToString("00000"), "T" + random.Next(1, 40).ToString("000"),
                    Math.Round((decimal)(random.NextDouble() * 200), 2), DateTime.Today.AddMinutes(-i * 7), random.Next(3) == 0);
            }
            noxGrid1.DataSource = null;
            noxGrid1.Columns.Clear();
            noxGrid1.DataSource = table;
            noxGrid1.Columns["SpecimenNo"].Frozen = true;
            noxGrid1.Columns["Value"].Format = "0.00";
            noxGrid1.Columns["Received"].Format = "yyyy-MM-dd HH:mm";
            noxGrid1.Columns["Received"].Width = 130;
            lblInfo.Text = "DataTable " + table.Rows.Count.ToString("#,##0", CultureInfo.CurrentCulture) + " rows - click a header to sort the DataView";
        }

        /// <summary>Virtual mode: only the cells on screen are requested</summary>
        private void btnVirtual_Click(object sender, EventArgs e)
        {
            noxGrid1.DataSource = null;
            noxGrid1.Columns.Clear();
            var columns = new NoxGridColumn[300];
            for (var c = 0; c < columns.Length; c++)
            {
                columns[c] = c % 2 == 0 ? new NoxGridColumn("F" + c, "Field " + c) : new NoxGridNumberColumn("F" + c, "Value " + c) { Format = "#,##0" };
            }
            noxGrid1.Columns.AddRange(columns);
            noxGrid1.Columns[0].Frozen = true;
            var source = new BigSource(100000);
            noxGrid1.DataSource = source;
            lblInfo.Text = "Virtual 100,000 rows × 300 columns (30 million cells) - values are computed only for visible cells";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            noxGrid1.DataSource = null;
            lblInfo.Text = "Disconnected (columns kept)";
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            // Save dialog → .xlsx or .csv (visible rows, colors, merges and frozen panes included)
            var path = noxGrid1.ShowExportDialog();
            if (path != null)
            {
                lblInfo.Text = "Saved: " + path;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            noxGrid1.PrintSettings.Title = "NoxGrid C# Sample";
            noxGrid1.PrintSettings.FitToPageWidth = noxGrid1.ColumnCount <= 20;
            noxGrid1.PrintPreview();
        }

        private void noxGrid1_CellClick(object sender, NoxGridCellEventArgs e)
        {
            Text = $"NoxGrid C# Sample - row {e.RowIndex + 1} [{e.Column.HeaderText}] {noxGrid1.Cells[e.RowIndex, e.ColumnIndex].FormattedValue}";
        }

        /// <summary>Example virtual data source: computes values on demand and stores only edited values</summary>
        private sealed class BigSource : INoxVirtualDataSource
        {
            private readonly int _rows;
            private readonly System.Collections.Generic.Dictionary<(int, string), object> _edits = new System.Collections.Generic.Dictionary<(int, string), object>();

            public BigSource(int rows)
            {
                _rows = rows;
            }

            public int RowCount => _rows;

            public event EventHandler DataChanged;

            public object GetValue(int rowIndex, string fieldName)
            {
                if (_edits.TryGetValue((rowIndex, fieldName), out var v))
                {
                    return v;
                }
                var c = int.Parse(fieldName.Substring(1), CultureInfo.InvariantCulture);
                return c % 2 == 0 ? (object)("R" + rowIndex + "C" + c) : (decimal)(rowIndex * 13 + c);
            }

            public void SetValue(int rowIndex, string fieldName, object value)
            {
                _edits[(rowIndex, fieldName)] = value;
                DataChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
