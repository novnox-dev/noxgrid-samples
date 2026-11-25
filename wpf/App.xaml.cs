// Copyright © 2026 Nox. All rights reserved.

using System.Windows;

namespace NoxGrid.Sample.Wpf
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Windows Forms controls inside WPF (the grid's filter popup, combo lists, dialogs) use the current Windows look
            System.Windows.Forms.Application.EnableVisualStyles();
            base.OnStartup(e);
        }
    }
}
