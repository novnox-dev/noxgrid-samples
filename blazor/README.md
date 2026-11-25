# NoxGrid web in Blazor (C#)

Shows the **NoxGrid web edition** (npm `@novnox/grid`, a Canvas grid) in a Blazor app through JS interop:
C# sends a `List<Order>` to the grid, every edited cell comes back to C# as an event, and "Read edits" pulls all rows (with the edits) back into C#.
The grid is wrapped in one reusable component, `NoxGridView<TItem>`.

| | |
|---|---|
| Project | Blazor Web App, Interactive Server render mode, .NET 10 (`net10.0`) |
| Packages | None. The grid is loaded from the jsDelivr CDN by `wwwroot/noxGridInterop.js` |
| Also works in | Blazor WebAssembly (see below) |

## Run

`dotnet run` in this folder, then open the URL it prints (`http://localhost:5224`). Or open `NoxGrid.Sample.Blazor.csproj` in a Visual Studio version with .NET 10 support and press **F5**.

| On the page | What happens |
|---|---|
| Orders grid | C# makes 500 `Order` objects; the component sends them to the grid with `grid.setData(rows)` |
| Edit a cell | The grid's `cellValueChanged` event calls a `[JSInvokable]` method; the page adds the change to "Edited cells" |
| Read edits (grid → C#) | Reads `grid.data` (the bound rows with every edit) back into a `List<Order>` and totals it. This is where you would save to your database |
| Reload orders (C# → grid) | Binds a fresh list |
| About | Leave the page and come back: the grid is destroyed and created again |

## How it works

| File | Role |
|---|---|
| `Components/NoxGridView.razor` | Component: a host `<div>` with a height; creates the grid in `OnAfterRenderAsync(firstRender)`; `ReadDataAsync()`, `SetDataAsync()`; destroys the grid in `DisposeAsync()` |
| `wwwroot/noxGridInterop.js` | JS module: imports `NoxGrid`, and has `create`, `setData`, `getDataJson`, `destroy` |
| `Components/Pages/Home.razor` | The orders page: column definitions, the edit log, the buttons |
| `Models/Order.cs` | The `Order` rows and the `CellChange` event record |

| Direction | How |
|---|---|
| Load the module | `JS.InvokeAsync<IJSObjectReference>("import", "./noxGridInterop.js")` |
| C# → grid | `module.InvokeAsync<IJSObjectReference>("create", hostElementRef, options, items, DotNetObjectReference.Create(this))`. C# keeps the returned grid reference and passes it to the other functions |
| grid → C#, events | `grid.on('cellValueChanged', e => dotNetRef.invokeMethodAsync('OnCellValueChanged', {...}))` calls a `[JSInvokable]` method |
| grid → C#, all rows | `getDataJson(grid)` returns a `Uint8Array`; C# receives an `IJSStreamReference` and deserializes the stream |
| Cleanup | `destroy(grid)`, then dispose the grid reference, the module and the `DotNetObjectReference` |

Usage:

```razor
<NoxGridView @ref="view" TItem="Order" Items="orders" Columns="columns" OnCellChanged="OnCellChanged" Height="420px" />

var rows = await view.ReadDataAsync();   // List<Order> with the edits
```

## Gotchas

- **32 KB limit on Blazor Server.** Sending data from C# to the grid has no practical limit, but a value returned from JS to C# is one SignalR message, and the default `MaximumReceiveMessageSize` is 32 KB (about 200 orders here). Returning `grid.data` with `InvokeAsync<List<Order>>` past that closes the circuit (the log says *"The maximum message size of 32768B was exceeded"*). This sample returns the rows as a `Uint8Array`, which arrives as an `IJSStreamReference` and is streamed. The alternative is to raise the limit in `Program.cs`: `.AddInteractiveServerComponents().AddHubOptions(o => o.MaximumReceiveMessageSize = 1024 * 1024)`.
- **Dates and time zones.** A `DateTime` goes to the grid as an ISO string (`"2026-06-06T00:00:00"`), which a `date` column reads as a date. A date the user types becomes a JS `Date` at local midnight, and JSON would write it in UTC (`"2026-03-14T15:00:00.000Z"` in UTC+9: the previous day in C#). `noxGridInterop.js` sends local wall-clock time without an offset instead, so C# gets the date that was typed (`DateTimeKind.Unspecified`). Also avoid sending `DateTime.Now`/`DateTime.Today` as they are: they are `DateTimeKind.Local` and go out with the server's offset (`+09:00`).
- **Formats.** The ISO strings include a time, so give date columns `format = "yyyy-MM-dd"`. Decimals show as plain numbers (`12.5`) unless the column has a format (`"#,##0.00"`).
- **Field names are camelCase.** Blazor serializes `Order.Due` as `due`, so column `field`s are `"id"`, `"qty"`, `"due"`, ...
- **Prerendering.** The page is rendered on the server first, when there is no browser to call. Create the grid in `OnAfterRenderAsync(firstRender)`, never in `OnInitialized`.
- **Disposal.** Leaving the page disposes the component: call `destroy()` and dispose the JS references and the `DotNetObjectReference`. On Blazor Server, catch `JSDisconnectedException` when the browser is already gone (tab closed, reload). `NoxGridView` also handles the page being left while the module is still loading.
- **Use `@novnox/grid` 1.0.1 or later.** Blazor's enhanced navigation rebuilds `<head>`, which removed the grid's `<style data-nox-grid>`; with 1.0.0 a grid created after navigating sized its canvas to all rows and looked blank. 1.0.1 adds the style again when it is missing.
- **Height.** The grid fills its host element, so the host needs a height (`Height` parameter, default `420px`).

## Blazor WebAssembly

The same `NoxGridView.razor`, `noxGridInterop.js` and `Order.cs` work unchanged in a standalone Blazor WebAssembly app (tested with the `blazorwasm` template, .NET 10). The differences:

- No `@rendermode InteractiveServer` on the page (standalone WebAssembly is always interactive and does not support `@rendermode`).
- Head tags such as `<link rel="icon" href="data:," />` go in `wwwroot/index.html` instead of `Components/App.razor`.
- There is no SignalR, so the 32 KB limit and `JSDisconnectedException` do not apply; the stream read still works.
- There is no prerendering and no enhanced navigation, so those two gotchas do not apply either.

## Serving the grid yourself

The interop module imports the grid from jsDelivr:

```js
import { NoxGrid } from 'https://cdn.jsdelivr.net/npm/@novnox/grid@1.0.1/dist/nox-grid.min.js';
```

To serve your own copy (offline, intranet, a strict Content Security Policy):

1. `npm install @novnox/grid`
2. Copy `node_modules/@novnox/grid/dist/nox-grid.min.js` to `wwwroot/lib/nox-grid/nox-grid.min.js`.
3. Change the import to `import { NoxGrid } from './lib/nox-grid/nox-grid.min.js';`

## License key

Not needed in this sample: the grid shows no reminder on development addresses such as `localhost`.
When the app runs on a real domain, call `setLicenseKey('NOX1...')` before creating the grid, e.g. in `noxGridInterop.js`:
`import { NoxGrid, setLicenseKey } from '...'; setLicenseKey('NOX1...');`. Free key: https://novnox.dev/license/
