using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Core.Extensions;
using Core.Settings;



namespace Core.UI {
  public static class Drawer {
    static private readonly int UnitSize = StaticSettings.UNIT_SIZE;
    static private readonly int OutlineSize = StaticSettings.OUTLINE_SIZE;
    static private readonly Pen NeutralLight = DynamicSettings.GridColor.Value.ToColor().ToPen(OutlineSize);



    static public void DrawLayout(Graphics graphics, Rectangle clip, Layout.Entity layout) {
      // Current visible area clip
      graphics.SetClip(clip);

      // Vertical grid lines
      for (int x = 0; x <= layout.Size.Width; x++) {
        // Draw only if inside clip
        if (!graphics.IsVisible(x * UnitSize, clip.Location.Y))
          continue;

        graphics.DrawLine(
          NeutralLight,

          new Point(x, 0)
            .Scale(UnitSize),

          new Point(x, layout.Size.Height)
            .Scale(UnitSize)
        );
      }

      // Horizontal grid lines
      for (int y = 0; y <= layout.Size.Height; y++) {
        // Draw only if inside clip
        if (!graphics.IsVisible(clip.Location.X, y * UnitSize))
          continue;

        graphics.DrawLine(
          NeutralLight,

          new Point(0, y)
            .Scale(UnitSize),

          new Point(layout.Size.Width, y)
            .Scale(UnitSize)
        );
      }



      // Zones
      foreach (Zone.Entity zone in layout.Zones) {
        var zoneRectangle = zone.Rectangle.Scale(UnitSize);

        if (!graphics.IsVisible(zoneRectangle))
          continue;

        graphics.FillRectangle(
          zone.Color
            .ToBrush()
            .Transparentize(),

          zone.Rectangle
            .Scale(UnitSize)
        );

        if (zone.VerticalCapacity == 0) {
          graphics.FillRectangle(
            zone.Color
              .ToBrush()
              .Transparentize(),

            zoneRectangle
          );
        }
      }
    }



    static public void DrawLayers(Graphics graphics, params Layer[] layers) {
      foreach (Layer layer in layers) {
        graphics.DrawImage(layer.Bitmap, layer.Rectangle);
      }
    }
  }
}
