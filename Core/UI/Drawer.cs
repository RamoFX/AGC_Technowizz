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
    static public void DrawLayout(Graphics graphics, Layout.Entity layout) {
      // Preparation
      int unitSize = StaticSettings.UnitSize;
      int outlineSize = StaticSettings.OutlineSize * 0 + 1;

      Pen penNeutralLight = DynamicSettings.GridColor.Value.ToColor().ToPen(outlineSize);

      Pen penNeutralDark = DynamicSettings.LayoutColor.Value.ToColor().ToPen(outlineSize);



      // Vertical grid lines
      for (int x = 0; x <= layout.Size.Width; x++) {
        graphics.DrawLine(
          penNeutralLight,

          new Point(x, 0)
            .Scale(unitSize),

          new Point(x, layout.Size.Height)
            .Scale(unitSize)
        );
      }

      // Horizontal grid lines
      for (int y = 0; y <= layout.Size.Height; y++) {
        graphics.DrawLine(
          penNeutralLight,

          new Point(0, y)
            .Scale(unitSize),

          new Point(layout.Size.Width, y)
            .Scale(unitSize)
        );
      }



      // Layout
      graphics.DrawRectangle(
        penNeutralDark,

        layout.Rectangle
          .Scale(unitSize)
      );



      // Zones
      foreach (Zone.Entity zone in layout.Zones) {
        var zoneRectangle = zone.Rectangle.Scale(unitSize);

        graphics.FillRectangle(
          zone.Color
            .ToBrush()
            .Transparentize(),

          zone.Rectangle
            .Scale(unitSize)
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
