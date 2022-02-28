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



namespace ZoneAssigner {
  public partial class Main {
    private void Canvas_Layout_Paint(object sender, PaintEventArgs e) {
      // Remove previous paintings
      e.Graphics.Clear(this.Canvas_Layout.BackColor);

      // Continue is layout present
      if (this.CurrentLayout == null)
        return;

      // Update unit size
      this.CurrentUnitSize = Utilities.ComputeOptimalUnitSize(
        StaticSettings.UNIT_SIZE,
        this.Panel_CanvasWrapper.Size,
        this.CurrentLayout.Size
      );
      
      // Resize canvas
      this.Canvas_Layout.Size = this.CurrentLayout.Size.Scale(this.CurrentUnitSize) + new Size(StaticSettings.OUTLINE_SIZE / 2, StaticSettings.OUTLINE_SIZE / 2);

      // Draw
      Drawer.DrawLayout(e.Graphics, e.ClipRectangle, this.CurrentUnitSize, this.CurrentLayout, this.CurrentSelection);
    }
  }
}
