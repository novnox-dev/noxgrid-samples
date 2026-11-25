// Copyright © 2026 Nox. All rights reserved.

using System.Text.Json;

namespace NoxGrid.Sample.Blazor.Models;

/// <summary>One order. Blazor sends the properties camelCase (Id → "id"); those names are the grid's column fields.</summary>
public class Order
{
    public string Id { get; set; } = "";
    public string Customer { get; set; } = "";
    public string Item { get; set; } = "";
    public int Qty { get; set; }
    public decimal Price { get; set; }
    /// <summary>Goes to the grid as "2026-06-06T00:00:00"; a date column reads ISO strings.</summary>
    public DateTime Due { get; set; }
    public string Status { get; set; } = "";
    public bool Invoiced { get; set; }

    public static readonly string[] Customers = ["Customer A", "Customer B", "Customer C", "Customer D", "Customer E"];
    public static readonly string[] States = ["Received", "In production", "Shipping", "Completed"];

    public static List<Order> Sample(int count = 500)
    {
        string[] items = ["Steel bracket A", "Bearing 6204", "Hydraulic hose", "Control panel", "LED module"];
        decimal[] prices = [4m, 7m, 18m, 420m, 12.5m];
        // DateTime.Today is DateTimeKind.Local and would be sent with the server's offset ("...T00:00:00+09:00").
        // An Unspecified date is sent as a plain "2026-06-06T00:00:00", the same form the grid sends back.
        var today = DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Unspecified);
        var random = new Random(7);
        var list = new List<Order>(count);
        for (var i = 0; i < count; i++)
        {
            var item = random.Next(items.Length);
            list.Add(new Order
            {
                Id = "SO-" + (260001 + i),
                Customer = Customers[random.Next(Customers.Length)],
                Item = items[item],
                Qty = item == 3 ? random.Next(1, 4) : 10 * random.Next(1, 30),
                Price = prices[item],
                Due = today.AddDays(random.Next(-10, 40)),
                Status = States[random.Next(States.Length)],
                Invoiced = random.Next(3) == 0,
            });
        }
        return list;
    }
}

/// <summary>One edited cell, sent from the grid's cellValueChanged event (see wwwroot/noxGridInterop.js).</summary>
public record CellChange(int Row, string? Id, string? Field, JsonElement OldValue, JsonElement NewValue);
