// Copyright © 2026 Nox. All rights reserved.

using System;
using System.Windows.Forms;

namespace NoxGrid.Sample.CSharp
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
