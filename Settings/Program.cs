﻿using System;
using System.Windows.Forms;

namespace Settings {
  internal static class Program {
    /// <summary>
    /// Hlavní vstupní bod aplikace.
    /// </summary>
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Main());
    }
  }
}
