using System;
using System.Diagnostics;
using System.Drawing;

using Core.Extensions;
using Core.Settings;
using Core.UI;



namespace LayoutDesigner {
  public partial class Main {
    private void DrawLayout(Graphics graphics) {
      graphics.Clear(this.PictureBox_Layout.BackColor);

      if (this.CurrentLayout == null)
        return;

      this.PictureBox_Layout.Size = this.CurrentLayout.Size.Scale(StaticSettings.UNIT_SIZE);
      Stopwatch stopwatch = new();
      stopwatch.Start();
      Drawer.DrawLayout(graphics, this.CurrentLayout);
      stopwatch.Stop();
      Console.WriteLine($"Draw: { stopwatch.ElapsedMilliseconds } ms");
    }
  }
}
