using Core.Extensions;
using Core.Settings;
using Core.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LayoutDesigner {
  public partial class Main {
    private void DrawLayout(Graphics graphics) {
      graphics.Clear(this.PictureBox_Layout.BackColor);

      if (this.CurrentLayout == null)
        return;

      this.PictureBox_Layout.Size = this.CurrentLayout.Size.Scale(StaticSettings.UnitSize);
      Stopwatch stopwatch = new();
      stopwatch.Start();
      Drawer.DrawLayout(graphics, this.CurrentLayout);
      stopwatch.Stop();
      Console.WriteLine($"Draw: { stopwatch.ElapsedMilliseconds } ms");
    }
  }
}
