# NoxGrid samples

Sample projects for **NoxGrid**, a data grid for Windows Forms (.NET Framework 4.7.2) and the web.

- Homepage: https://novnox.dev
- Documentation: https://novnox.dev/docs/
- Free license key: https://novnox.dev/license/
- Questions and feedback: https://novnox.dev/feedback/

This repository contains sample code only. NoxGrid itself comes from NuGet (`Nox.Grid`, `Nox.Grid.Server`) and npm (`@novnox/grid`, `@novnox/grid-react`, `@novnox/grid-vue`).

## Samples

| Folder | What it is | How to run |
|---|---|---|
| [`winforms/vb-demo`](winforms/vb-demo) | Sales order app in VB.NET: workbook with 4 sheets, formulas across sheets, subtotals, Excel import/export, print preview, designer | Open `NoxGridDemo.sln` in Visual Studio 2019 or later → **F5** |
| [`winforms/vb-basic`](winforms/vb-basic) | Smallest VB.NET form with a grid | `dotnet run` or open in Visual Studio |
| [`winforms/csharp-basic`](winforms/csharp-basic) | Smallest C# form with a grid | `dotnet run` or open in Visual Studio |
| [`winforms/webview2-csharp`](winforms/webview2-csharp) | The web grid inside a WinForms form (WebView2): C# sends data, the page reports edits back | `dotnet run` or open in Visual Studio |
| [`web`](web) | Plain HTML pages: ERP orders, factory production, office budget | Open an `.html` file in a browser (NoxGrid loads from the npm CDN) |
| [`react`](react) | React component with state and events | `npm install` → `npm run dev` |
| [`vue`](vue) | Vue 3 component with reactive data and events | `npm install` → `npm run dev` |
| [`python/flask`](python/flask) | Python (Flask) backend: the grid loads orders from SQLite as JSON, edits and new rows are saved back | `pip install -r requirements.txt` → `python app.py` → http://localhost:5000 |
| [`server/aspnetcore`](server/aspnetcore) | ASP.NET Core: read Excel/CSV on the server, download the grid as `.xlsx` | `dotnet run` → http://localhost:5099 |

The web pages are in English by default. Add `?lang=ko` to the address for Korean.

## Requirements

- Windows Forms samples: Visual Studio 2019 or later. `vb-basic` and `csharp-basic` also build with the .NET SDK (8 or later) and the .NET Framework 4.7.2 targeting pack; `vb-demo` needs Visual Studio (its form resources need Visual Studio's MSBuild)
- Web samples: any modern browser; Node.js 20 or later for React and Vue
- Server sample: .NET 8 SDK or later; Flask sample: Python 3.9 or later

## License key

NoxGrid 1.x is free. A free key only removes a small reminder; nothing stops working without it. Get one at https://novnox.dev/license/.

- Windows Forms: the reminder appears only in the Visual Studio designer, never in your running app. Register the key in the designer: right-click a grid → **Register License Key...**
- Web: no reminder on localhost or local files. On a real site, call `setLicenseKey('NOX1...')` before creating grids (see the comments in each sample).

## License

The sample code in this repository is under the [MIT License](LICENSE). You can copy it into your own projects.
NoxGrid itself (the NuGet and npm packages) is licensed separately; see https://novnox.dev/license/.

Copyright © 2026 Nox
