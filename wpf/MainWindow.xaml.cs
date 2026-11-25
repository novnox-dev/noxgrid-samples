// Copyright © 2026 Nox. All rights reserved.

using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Nox.Grid.WinForms;

namespace NoxGrid.Sample.Wpf
{
    /// <summary>
    /// The WinForms Edition of NoxGrid in a WPF window (WindowsFormsHost, .NET Framework 4.7.2).
    /// WPF controls and the grid share one DataTable; grid events update WPF text.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataTable orders = SampleOrders();

        public MainWindow()
        {
            InitializeComponent();

            Grid.AutoGenerateColumns = false;
            Grid.ColorScheme = NoxGridColorScheme.Modern;
            Grid.AllowFiltering = true;
            var customer = new NoxGridComboBoxColumn("Customer", "Customer") { DataPropertyName = "Customer", Width = 130 };
            customer.Items.AddRange("Customer A", "Customer B", "Customer C", "Customer D", "Customer E");
            Grid.Columns.Add(new NoxGridColumn("Id", "Order #") { DataPropertyName = "Id", Width = 100, ReadOnly = true, Frozen = true });
            Grid.Columns.Add(customer);
            Grid.Columns.Add(new NoxGridColumn("Item", "Item") { DataPropertyName = "Item", Width = 150 });
            Grid.Columns.Add(new NoxGridNumberColumn("Qty", "Qty") { DataPropertyName = "Qty", Format = "#,##0", Width = 70 });
            Grid.Columns.Add(new NoxGridNumberColumn("Price", "Unit price") { DataPropertyName = "Price", Format = "#,##0.00", Width = 90 });
            Grid.Columns.Add(new NoxGridDateColumn("Due", "Due date") { DataPropertyName = "Due", Width = 100 });
            Grid.Columns.Add(new NoxGridCheckBoxColumn("Invoiced", "Invoiced") { DataPropertyName = "Invoiced", Width = 80 });
            Grid.DataSource = orders.DefaultView;

            // Grid → WPF: the event runs on the UI thread, so WPF controls can be updated directly
            Grid.CellValueChanged += (s, e) =>
            {
                if (e.IsNested) return;
                LastEdit.Text = $"{Grid[e.RowIndex, "Id"]} {Grid.Columns[e.ColumnIndex].HeaderText}: {Grid[e.RowIndex, e.ColumnIndex]} ({e.Reason})";
                ShowStatus();
            };
            Closed += (s, e) => Grid.Dispose();
            ShowStatus();
        }

        // WPF → grid: filter the bound DataView (the grid follows it)
        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            var text = Find.Text.Trim().Replace("'", "''");
            orders.DefaultView.RowFilter = text.Length == 0 ? "" : $"Customer LIKE '%{text}%'";
            ShowStatus();
        }

        private void Find_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Filter_Click(sender, e);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var next = 260001 + orders.Rows.Count;
            orders.Rows.Add("SO-" + next, "Customer A", "Bearing 6204", 1, 7m, DateTime.Today.AddDays(14), false);
            Grid.Focus();
            ShowStatus();
        }

        // The edits are already in the DataTable: save it to your database here
        private void Read_Click(object sender, RoutedEventArgs e)
        {
            var changed = orders.GetChanges();
            var total = orders.Rows.Cast<DataRow>().Sum(r => (int)r["Qty"] * (decimal)r["Price"]);
            MessageBox.Show(this, $"{orders.Rows.Count} orders, total {total:#,##0.00}\nChanged or added rows: {changed?.Rows.Count ?? 0}", Title);
        }

        private void ShowStatus()
        {
            Status.Text = $"{orders.DefaultView.Count:#,##0} of {orders.Rows.Count:#,##0} orders";
        }

        private static DataTable SampleOrders()
        {
            var t = new DataTable("Orders");
            t.Columns.Add("Id", typeof(string));
            t.Columns.Add("Customer", typeof(string));
            t.Columns.Add("Item", typeof(string));
            t.Columns.Add("Qty", typeof(int));
            t.Columns.Add("Price", typeof(decimal));
            t.Columns.Add("Due", typeof(DateTime));
            t.Columns.Add("Invoiced", typeof(bool));
            string[] customers = { "Customer A", "Customer B", "Customer C", "Customer D", "Customer E" };
            string[] items = { "Steel bracket A", "Bearing 6204", "Hydraulic hose", "Control panel", "LED module" };
            decimal[] prices = { 4, 7, 18, 420, 12 };
            var random = new Random(7);
            for (var i = 0; i < 1000; i++)
            {
                var item = random.Next(items.Length);
                t.Rows.Add("SO-" + (260001 + i), customers[random.Next(customers.Length)], items[item],
                    item == 3 ? random.Next(1, 4) : 10 * random.Next(1, 30), prices[item],
                    DateTime.Today.AddDays(random.Next(-10, 40)), random.Next(3) == 0);
            }
            t.AcceptChanges();
            return t;
        }
    }
}
