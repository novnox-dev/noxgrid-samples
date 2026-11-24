// Copyright © 2026 Nox. All rights reserved.

using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Nox.Grid.Server;

var builder = WebApplication.CreateBuilder(args);

// Grid data JSON: omit nulls, keep non-ASCII text unescaped
builder.Services.ConfigureHttpJsonOptions(o =>
{
    o.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    o.SerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
});
builder.WebHost.UseUrls(Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? "http://localhost:5099");

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

// Sample data: a visit list built on the server (with formulas)
app.MapGet("/api/sample", () =>
{
    string[] depts = ["Internal Medicine", "Surgery", "Pediatrics", "Orthopedics", "Ophthalmology"];
    string[] names = ["Alex Morgan", "Sam Lee", "Jordan Park", "Taylor Reed", "Casey Brooks", "Riley Chen", "Morgan Diaz", "Jamie Fox"];
    var rows = Enumerable.Range(0, 40).Select(i => new Visit
    {
        No = "R" + (10001 + i),
        Name = names[i % names.Length],
        Dept = depts[(i * 3) % depts.Length],
        Date = new DateTime(2026, 11, 1).AddDays(i % 20),
        Fee = 80 + (i * 1370 % 90),
        Paid = i % 3 != 0,
    }).ToList();
    var sheet = NoxSheetData.FromObjects(rows, "Visits", new Dictionary<string, string>
    {
        ["No"] = "Visit No.", ["Name"] = "Patient", ["Dept"] = "Department", ["Date"] = "Date", ["Fee"] = "Fee", ["Paid"] = "Paid",
    });
    sheet.Columns.Add(new NoxColumnData { Index = 2, Width = 130 });
    sheet.Columns.Add(new NoxColumnData { Index = 3, Width = 110, Format = "yyyy-MM-dd" });
    sheet.Columns.Add(new NoxColumnData { Index = 4, Format = "#,##0.00" });
    var total = rows.Count + 1;
    sheet.SetValue(total, 1, "Total").Style = new NoxCellStyleData { Bold = true };
    sheet.SetFormula(total, 4, $"=SUM(E2:E{total})").Style = new NoxCellStyleData { Bold = true, BackColor = "#FFF2CC", Format = "#,##0.00" };
    sheet.SetFormula(total, 5, $"=COUNTIF(F2:F{total},TRUE)").Style = new NoxCellStyleData { Bold = true };
    return new NoxWorkbookData { Sheets = { sheet } };
});

// File upload → grid data (Excel or CSV)
app.MapPost("/api/import", async (IFormFile file) =>
{
    await using var stream = file.OpenReadStream();
    if (file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) || file.FileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
    {
        var sheet = NoxCsv.Read(stream, sheetName: Path.GetFileNameWithoutExtension(file.FileName));
        return Results.Ok(new NoxWorkbookData { Sheets = { sheet } });
    }
    try
    {
        return Results.Ok(NoxExcel.Read(stream));
    }
    catch (InvalidDataException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
}).DisableAntiforgery();

// Grid data → Excel download
app.MapPost("/api/export", (NoxWorkbookData book) =>
    Results.File(NoxExcel.ToBytes(book), NoxExcel.ContentType, "noxgrid.xlsx"));

// Grid data → CSV download (UTF-8 BOM)
app.MapPost("/api/export/csv", (NoxWorkbookData book) =>
    Results.File(NoxCsv.ToBytes(book.Sheets.FirstOrDefault() ?? new NoxSheetData()), "text/csv; charset=utf-8", "noxgrid.csv"));

app.Run();

internal sealed class Visit
{
    public string No { get; set; } = "";

    public string Name { get; set; } = "";

    public string Dept { get; set; } = "";

    public DateTime Date { get; set; }

    public double Fee { get; set; }

    public bool Paid { get; set; }
}
