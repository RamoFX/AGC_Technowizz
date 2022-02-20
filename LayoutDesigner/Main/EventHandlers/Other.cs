﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Core;
using Core.Extensions;
using Core.Settings;
using Core.UI;



namespace LayoutDesigner {
  public partial class Main {
    private void Tree_Layout_MouseDown(object sender, MouseEventArgs e) {
      object currentSelection = null;

      var node = this.Tree_Layout.HitTest(e.X, e.Y).Node;

      if (node != null) {
        if (this.CurrentLayout == null)
          return;

        string path = node.FullPath;
        char[] pathSeparator = this.Tree_Layout.PathSeparator.ToCharArray();
        var layout = this.CurrentLayout;

        currentSelection = Utilities.MatchEntity(path, pathSeparator, layout);
      }

      this.SetCurrentSelection(currentSelection);
    }



    private void Properties_CurrentSelection_Enter(object sender, EventArgs e) {
      // Lose focus (shouldn't be editable)
      this.Properties_CurrentSelection.Enabled = false;
      this.Properties_CurrentSelection.Enabled = true;

      if (this.CurrentLayout == null || this.CurrentSelection == null)
        return;
      
      // Edit matched entity
      bool isZone = this.CurrentSelection.GetType().ToString() == "Core.Zone+Entity";
      bool isLayout = this.CurrentSelection.GetType().ToString() == "Core.Layout+Entity";

      if (isZone) {
        var zone = (Zone.Entity) this.CurrentSelection;
        this.EditZone(zone);
      } else if (isLayout) {
        this.EditLayout();
      }
    }



    private void Canvas_Layout_Paint(object sender, PaintEventArgs e) {
      e.Graphics.Clear(this.Canvas_Layout.BackColor);

      if (this.CurrentLayout == null)
        return;

      this.Canvas_Layout.Size = this.CurrentLayout.Size.Scale(StaticSettings.UNIT_SIZE) + new Size(StaticSettings.OUTLINE_SIZE / 2, StaticSettings.OUTLINE_SIZE / 2);

      Drawer.DrawLayout(e.Graphics, e.ClipRectangle, this.CurrentLayout, this.CurrentSelection);
    }
  }
}
