# NoxGrid in WPF (WindowsFormsHost, C#)

The WinForms Edition of NoxGrid (NuGet `Nox.Grid`) in a WPF window on .NET Framework 4.7.2, hosted by `WindowsFormsHost`.
WPF controls and the grid share one `DataTable`; grid events update WPF text.

| | |
|---|---|
| Project | SDK-style C# WPF, .NET Framework 4.7.2, `UseWPF` + `UseWindowsForms` |
| Package | `Nox.Grid` 1.0.1 (NuGet) |
| Data | 1,000 made-up orders in a `DataTable`, bound through its `DefaultView` |

## Run

`dotnet run` in this folder, or open `NoxGrid.Sample.Wpf.csproj` in Visual Studio 2019 or later → **F5**.

| Try | What happens |
|---|---|
| Edit a cell, tick a check box | `CellValueChanged` updates the WPF text at the bottom |
| Type a customer in the WPF text box → **Filter** (or Enter) | WPF sets `DataView.RowFilter`; the grid follows the view |
| **Add order** | A row added to the `DataTable` appears in the grid |
| **Read edits** | The edits are already in the `DataTable` (`GetChanges()`): save it to your database here |
| Header funnels | The grid's own filter popup (`AllowFiltering`) |

## How it works

```xml
<Window ... xmlns:wf="clr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration"
            xmlns:nox="clr-namespace:Nox.Grid.WinForms;assembly=Nox.Grid.WinForms">
  <wf:WindowsFormsHost>
    <nox:NoxGrid x:Name="Grid" />
  </wf:WindowsFormsHost>
</Window>
```

Columns, data and events are set in `MainWindow.xaml.cs`, the same way as in a WinForms form.

## Checked

On Windows 11 at 100% display scale: drawing, mouse, typing and Enter, arrow keys and Tab inside the grid, Esc to cancel, check boxes, the filter popup, mouse wheel, closing the window. Korean IME input, Ctrl+C / Ctrl+V / Ctrl+Z, Shift+arrow selection, and Tab between WPF controls and the grid were checked by hand.
Not yet checked: display scale 125% and above.

## Notes

- **Designer**: the Visual Studio XAML designer cannot draw Windows Forms controls; the grid appears at run time. Define columns in code (or build the screen as a WinForms `UserControl` with the NoxGrid designer and host that).
- **Airspace**: as with any `WindowsFormsHost`, WPF content cannot be drawn on top of the grid (overlays, transparency, WPF animations over it).
- `System.Windows.Forms.Application.EnableVisualStyles()` in `App.OnStartup` gives the grid's popups and dialogs the current Windows look.
- Dispose the grid when the window closes (`Closed += ... Grid.Dispose()`).
- **.NET 8 or later WPF**: NoxGrid 1.x is for .NET Framework 4.7.2+; .NET 8+ is planned for 2.0. Alternatively host the web edition in WebView2 (see `winforms/webview2-csharp`).

## License key

NoxGrid 1.x is free. Without a key only the Visual Studio designer shows a small notice; your running app is never affected. Free key: https://novnox.dev/license/
