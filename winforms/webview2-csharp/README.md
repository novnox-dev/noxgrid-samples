# NoxGrid web in a WinForms form (WebView2, C#)

Shows the **NoxGrid web edition** inside a Windows Forms app with WebView2, and how C# and the page talk to each other.
Use this when part of your desktop app is already an HTML screen, or when the same grid screen should run in the browser and on the desktop.
(For a native WinForms grid, use the `Nox.Grid` NuGet package instead: see `vb-basic`, `csharp-basic`, `vb-demo`.)

| | |
|---|---|
| Project | SDK-style C# WinForms, .NET Framework 4.7.2, x64 |
| Packages | `Microsoft.Web.WebView2` (NuGet). The web grid `nox-grid.iife.js` (npm `@novnox/grid`) is downloaded into the output folder by the first build |
| Needs | WebView2 Runtime (built into Windows 11 and current Windows 10) |

## Run

`dotnet run` in this folder, or open `NoxGrid.Sample.WebView2.csproj` in Visual Studio 2019 or later → **F5**.

| Button | What happens |
|---|---|
| Load orders (C# → grid) | C# makes 500 `Order` objects and sends them as JSON; the page binds them with `grid.setData(rows)` |
| Add order | C# sends one more order; the page adds it to the bound array |
| Read edits (grid → C#) | The page sends back `grid.data` (the bound objects with every edit) and C# totals them. This is where you would save to your database |
| Dark | Switches the grid's color scheme (`dark` / `modern`) |
| (log at the bottom) | Every edited cell is reported to C# from the grid's `cellValueChanged` event |

## How it works

```
MainForm.cs                                 wwwroot/index.html
-----------                                 ------------------
PostWebMessageAsJson({type:'load', rows})   → chrome.webview 'message' → grid.setData(rows)
WebMessageReceived  {type:'cellChanged'}    ← grid.on('cellValueChanged') → chrome.webview.postMessage
PostWebMessageAsJson({type:'getData'})      → postMessage({type:'data', rows: grid.data})
```

- The page is served from the app folder with `SetVirtualHostNameToFolderMapping("app.local", wwwroot)` and opened as `https://app.local/index.html`. A real `https` origin keeps every browser feature working (clipboard, Web Crypto) and needs no web server.
- Column `field` names are the C# property names (`Id`, `Customer`, `Qty`, ...), so the JSON goes straight into the grid and back.
- Dates travel as `yyyy-MM-dd` strings; a `date` column shows and sorts them as dates.
- Browser data (cache) goes to `%LOCALAPPDATA%\NoxGrid.Sample.WebView2`, because the folder next to the .exe may be read-only (Program Files).

## License key

Not needed in this sample. The grid shows no reminder on development addresses, and a host ending in `.local` is one of them. The same goes for `NavigateToString(html)` (`about:blank`) and `file:///` pages.
If your app loads the page from a real web server (`https://erp.example.com/...`), call `NoxGridLib.setLicenseKey('NOX1...')` before creating the grid. Free key: https://novnox.dev/license/
Details (Korean): https://novnox.dev/docs/ko/articles/web.html, license key section, WebView2 table.

## Notes

- **x64 or x86**: `WebView2Loader.dll` is native, so the project picks a bitness (`<PlatformTarget>x64</PlatformTarget>`). For a 32-bit app, change it to `x86`. With AnyCPU on .NET Framework only the x86 loader is copied and a 64-bit process fails with `BadImageFormatException`.
- **Offline / your own copy of the grid**: the build downloads `nox-grid.iife.js` once from the npm CDN. To pin it in your app, `npm install @novnox/grid` and copy `node_modules/@novnox/grid/dist/nox-grid.iife.js` into `wwwroot`.
- **VB.NET**: the same calls work unchanged (`CoreWebView2.PostWebMessageAsJson`, `AddHandler CoreWebView2.WebMessageReceived, ...`).
