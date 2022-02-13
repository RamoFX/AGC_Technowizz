﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Core;
using Core.Extensions;
using Core.Settings;
using Core.UI;
using Core.UI.Dialogs;



namespace LayoutDesigner {
  public partial class Main {
    // File (Tool strip menu item)
    private void Item_New_Click(object sender, EventArgs e) {
      this.NewLayout();
    }

    private void MenuItem_Open_Click(object sender, EventArgs e) {
      this.OpenLayout();
    }

    private void MenuItem_Close_Click(object sender, EventArgs e) {
      this.UnloadLayout();
    }


    private void MenuItem_Save_Click(object sender, EventArgs e) {
      this.SaveLayout();
    }

    private void MenuItem_SaveAs_Click(object sender, EventArgs e) {
      this.SaveLayoutAs();
    }

    private void MenuItem_Rename_Click(object sender, EventArgs e) {
      this.RenameLayout();
    }


    private void MenuItem_Delete_Click(object sender, EventArgs e) {
      this.DeleteLayout();
    }


    private void MenuItem_OpenInFileExplorer_Click(object sender, EventArgs e) {
      if (Core.Layout.FileSystem.GetFilesNames().Count() == 0) {
        MessageBoxes.NoLayoutsExist();
        return;
      }

      Process.Start("explorer.exe", StaticSettings.LayoutsPath);
    }


    private void MenuItem_Exit_Click(object sender, EventArgs e) {
      this.Close();
    }



    // Layout (Tool strip menu item)
    private void MenuItem_NewZone_Click(object sender, EventArgs e) {
      this.NewZone();
    }

    private void MenuItem_RemoveZone_Click(object sender, EventArgs e) {
      this.DeleteZone();
    }
  }
}