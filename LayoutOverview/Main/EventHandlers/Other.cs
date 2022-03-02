using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Core;
using Core.Extensions;
using Core.Settings;
using Core.UI;



namespace LayoutOverview {
  public partial class Main {
    private void Tree_Layout_MouseDown(object sender, MouseEventArgs e) {
      object currentSelection = null;

      var node = this.Tree_Layout.HitTest(e.X, e.Y).Node;

      if (node != null) {
        if (this.CurrentLayout == null)
          return;

        string path = Regex.Replace(node.FullPath, @" \(\d+ %\)$", "");
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
    }



    private void Canvas_Layout_Paint(object sender, PaintEventArgs e) {
      // Remove previous paintings
      e.Graphics.Clear(this.Canvas_Layout.BackColor);

      // Continue is layout present
      if (this.CurrentLayout == null)
        return;

      // Update unit size
      this.CurrentUnitSize = Utilities.ComputeOptimalUnitSize(
        DynamicSettings.UnitSize.Value.ToInt(),
        SplitContainer_Vertical.Panel2.Size,
        this.CurrentLayout.Size
      );
      
      // Resize canvas
      this.Canvas_Layout.Size = this.CurrentLayout.Size.Scale(this.CurrentUnitSize) + new Size(StaticSettings.OUTLINE_SIZE / 2, StaticSettings.OUTLINE_SIZE / 2);

      // Draw
      Drawer.DrawLayout(e.Graphics, e.ClipRectangle, this.CurrentUnitSize, this.CurrentLayout, this.CurrentSelection);
    }
  }
}
