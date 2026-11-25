// Copyright © 2026 Nox. All rights reserved.

using NoxGrid.Sample.Blazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Nothing NoxGrid-specific is needed here: the grid is loaded by wwwroot/noxGridInterop.js.
// NoxGridView streams large results from the grid to C#, so the default 32 KB SignalR receive limit is fine.
// (If you return big objects from JS with plain InvokeAsync<T>, raise it instead:
//  .AddInteractiveServerComponents().AddHubOptions(o => o.MaximumReceiveMessageSize = 1024 * 1024);)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
