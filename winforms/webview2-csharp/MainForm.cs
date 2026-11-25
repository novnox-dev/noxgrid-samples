// Copyright © 2026 Nox. All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace NoxGrid.Sample.WebView2
{
    /// <summary>
    /// The NoxGrid web edition inside a WinForms form (WebView2).
    /// C# sends data and commands to the page with PostWebMessageAsJson; the page answers with chrome.webview.postMessage.
    /// </summary>
    public class MainForm : Form
    {
        // The page is served from the app folder under this name (https://app.local/index.html).
        // Hosts ending in .local count as development addresses, so no license key is needed (see the README).
        private const string HostName = "app.local";

        private readonly Microsoft.Web.WebView2.WinForms.WebView2 web = new Microsoft.Web.WebView2.WinForms.WebView2 { Dock = DockStyle.Fill };
        private readonly ListBox log = new ListBox { Dock = DockStyle.Bottom, Height = 120, IntegralHeight = false };
        private readonly ToolStripLabel status = new ToolStripLabel();
        private readonly ToolStripButton dark = new ToolStripButton("Dark") { CheckOnClick = true };
        private readonly JavaScriptSerializer json = new JavaScriptSerializer();
        private List<Order> orders = new List<Order>();

        public MainForm()
        {
            Text = "NoxGrid web in WinForms (WebView2)";
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            Font = new Font("Segoe UI", 9F);
            Size = new Size(1040, 680);
            StartPosition = FormStartPosition.CenterScreen;

            var bar = new ToolStrip { GripStyle = ToolStripGripStyle.Hidden, Padding = new Padding(6, 2, 6, 2) };
            bar.Items.Add(new ToolStripButton("Load orders (C# → grid)", null, (s, e) => SendOrders()));
            bar.Items.Add(new ToolStripButton("Add order", null, (s, e) => AddOrder()));
            bar.Items.Add(new ToolStripButton("Read edits (grid → C#)", null, (s, e) => Post(new { type = "getData" })));
            bar.Items.Add(new ToolStripSeparator());
            bar.Items.Add(dark);
            bar.Items.Add(new ToolStripSeparator());
            bar.Items.Add(status);
            dark.CheckedChanged += (s, e) => Post(new { type = "theme", dark = dark.Checked });

            Controls.Add(web);
            Controls.Add(log);
            Controls.Add(bar);
            Load += async (s, e) => await StartAsync();
        }

        private async System.Threading.Tasks.Task StartAsync()
        {
            try
            {
                // Browser data (cache, storage) goes to %LOCALAPPDATA%, not next to the .exe (Program Files is read-only)
                var dataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NoxGrid.Sample.WebView2");
                var env = await CoreWebView2Environment.CreateAsync(null, dataFolder);
                await web.EnsureCoreWebView2Async(env);
            }
            catch (WebView2RuntimeNotFoundException)
            {
                MessageBox.Show(this, "The WebView2 Runtime is not installed.\nhttps://developer.microsoft.com/microsoft-edge/webview2/", Text);
                return;
            }

            var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");
            web.CoreWebView2.SetVirtualHostNameToFolderMapping(HostName, root, CoreWebView2HostResourceAccessKind.DenyCors);
            web.CoreWebView2.WebMessageReceived += OnWebMessage;
            web.CoreWebView2.Navigate("https://" + HostName + "/index.html");
        }

        /// <summary>Sends an object to the page as JSON (the page receives it in chrome.webview's message event).</summary>
        private void Post(object message)
        {
            if (web.CoreWebView2 != null) web.CoreWebView2.PostWebMessageAsJson(json.Serialize(message));
        }

        private void SendOrders()
        {
            orders = SampleOrders();
            Post(new { type = "load", rows = orders });
            Log("C# → grid: " + orders.Count + " orders");
        }

        private void AddOrder()
        {
            var o = new Order { Id = "SO-" + (260001 + orders.Count), Customer = "Customer A", Item = "Bearing 6204", Qty = 1, Price = 7, Due = DateTime.Today.AddDays(14).ToString("yyyy-MM-dd"), Status = "Received" };
            orders.Add(o);
            Post(new { type = "add", row = o });
            Log("C# → grid: added " + o.Id);
        }

        /// <summary>Messages from the page: { type: 'ready' | 'cellChanged' | 'data' | 'status', ... }</summary>
        private void OnWebMessage(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            var m = json.Deserialize<Dictionary<string, object>>(e.WebMessageAsJson);
            switch (m["type"] as string)
            {
                case "ready":
                    Log("grid → C#: ready (NoxGrid web " + m["version"] + ")");
                    SendOrders();
                    break;
                case "cellChanged":
                    Log(string.Format("grid → C#: {0} {1}: {2} → {3}", m["id"], m["field"], Show(m["oldValue"]), Show(m["newValue"])));
                    break;
                case "status":
                    status.Text = m["text"] as string;
                    break;
                case "data":
                    // The rows as the grid has them now (edits, added and deleted rows). Here you would save them to your database.
                    var rows = ((ArrayList)m["rows"]).Cast<Dictionary<string, object>>().ToList();
                    var total = rows.Sum(r => Convert.ToDecimal(r["Qty"]) * Convert.ToDecimal(r["Price"]));
                    Log(string.Format("grid → C#: {0} rows, total {1:#,##0}", rows.Count, total));
                    MessageBox.Show(this, string.Format("{0} rows read from the grid.\nTotal amount: {1:#,##0}\n\nFirst row: {2}", rows.Count, total,
                        rows.Count > 0 ? string.Join(", ", rows[0].Select(kv => kv.Key + "=" + kv.Value)) : "-"), Text);
                    break;
            }
        }

        private static string Show(object value)
        {
            return value == null ? "(empty)" : value.ToString();
        }

        private void Log(string text)
        {
            log.Items.Add(DateTime.Now.ToString("HH:mm:ss") + "  " + text);
            log.TopIndex = log.Items.Count - 1;
        }

        private static List<Order> SampleOrders()
        {
            string[] customers = { "Customer A", "Customer B", "Customer C", "Customer D", "Customer E" };
            string[] items = { "Steel bracket A", "Bearing 6204", "Hydraulic hose", "Control panel", "LED module" };
            decimal[] prices = { 4, 7, 18, 420, 12 };
            string[] states = { "Received", "In production", "Shipping", "Completed" };
            var random = new Random(7);
            var list = new List<Order>();
            for (var i = 0; i < 500; i++)
            {
                var item = random.Next(items.Length);
                list.Add(new Order
                {
                    Id = "SO-" + (260001 + i),
                    Customer = customers[random.Next(customers.Length)],
                    Item = items[item],
                    Qty = item == 3 ? random.Next(1, 4) : 10 * random.Next(1, 30),
                    Price = prices[item],
                    Due = DateTime.Today.AddDays(random.Next(-10, 40)).ToString("yyyy-MM-dd"),
                    Status = states[random.Next(states.Length)],
                    Invoiced = random.Next(3) == 0,
                });
            }
            return list;
        }
    }

    /// <summary>One order. Property names are the grid's column fields (see wwwroot/index.html).</summary>
    public class Order
    {
        public string Id { get; set; }
        public string Customer { get; set; }
        public string Item { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        /// <summary>yyyy-MM-dd: a date column shows and sorts ISO date strings as dates</summary>
        public string Due { get; set; }
        public string Status { get; set; }
        public bool Invoiced { get; set; }
    }
}
