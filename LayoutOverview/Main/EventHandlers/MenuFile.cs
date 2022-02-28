using System;
using System.Diagnostics;
using System.Linq;

using Core.Settings;
using Core.UI;



namespace LayoutOverview {
  public partial class Main {
    private void MenuItem_Open_Click(object sender, EventArgs e) {
      this.OpenLayout();
    }



    private void MenuItem_Close_Click(object sender, EventArgs e) {
      this.UnloadLayout();
    }


    private void MenuItem_OpenInFileExplorer_Click(object sender, EventArgs e) {
      if (Core.Layout.FileSystem.GetValidNames().Count() == 0) {
        MessageBoxes.NoLayoutsExist();
        return;
      }

      Process.Start("explorer.exe", StaticSettings.LayoutsPath);
    }


    private void MenuItem_Exit_Click(object sender, EventArgs e) {
      this.Close();
    }
  }
}
