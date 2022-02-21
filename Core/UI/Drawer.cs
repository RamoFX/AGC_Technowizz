using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Core.Extensions;
using Core.Settings;



namespace Core.UI {
  public static class Drawer {
    static private readonly Pen NeutralLight = DynamicSettings.GridColor.Value.ToColor().ToPen(StaticSettings.OUTLINE_SIZE);



    static public void DrawLayout(Graphics graphics, Rectangle clip, Layout.Entity layout, object selection) {
      // Current visible clip
      graphics.SetClip(clip);



      // Vertical grid lines
      for (int x = 0; x <= layout.Size.Width; x++) {
        // Draw only if inside visible clip
        if (!graphics.IsVisible(x * StaticSettings.UNIT_SIZE, clip.Location.Y))
          continue;

        graphics.DrawLine(
          NeutralLight,

          new Point(x, 0)
            .Scale(StaticSettings.UNIT_SIZE),

          new Point(x, layout.Size.Height)
            .Scale(StaticSettings.UNIT_SIZE)
        );
      }



      // Horizontal grid lines
      for (int y = 0; y <= layout.Size.Height; y++) {
        // Draw only if inside visible clip
        if (!graphics.IsVisible(clip.Location.X, y * StaticSettings.UNIT_SIZE))
          continue;

        graphics.DrawLine(
          NeutralLight,

          new Point(0, y)
            .Scale(StaticSettings.UNIT_SIZE),

          new Point(layout.Size.Width, y)
            .Scale(StaticSettings.UNIT_SIZE)
        );
      }



      // Zones
      foreach (Zone.Entity zone in layout.Zones) {
        var zoneRectangle = zone.Rectangle.Scale(StaticSettings.UNIT_SIZE);

        // Draw only if inside visible clip
        if (!graphics.IsVisible(zoneRectangle))
          continue;

        // Preparation
        bool isSelection = zone == selection;

        var brush = zone.Color
            .ToBrush()
            .Transparentize(isSelection ? 150 : 200);

        var pen = zone.Color
            .ToPen(StaticSettings.OUTLINE_SIZE);

        // Draw
        graphics.FillRectangle(
          brush,
          zoneRectangle
        );

        graphics.DrawRectangle(
          pen,
          zoneRectangle
        );

        // Text
        Font font = new(FontFamily.GenericMonospace, 9, FontStyle.Bold);
        int fontHeight = font.Height;
        const int chunkSize = 6;
        int linesCount = zone.Name.Length / chunkSize + 1;

        for (int lineIndex = 0; lineIndex < linesCount; lineIndex++) {
          bool isLast = (lineIndex + 1) * chunkSize > zone.Name.Length;
          int charsCount = isLast ? zone.Name.Length % chunkSize : chunkSize;
          var chars = zone.Name.ToList().GetRange(lineIndex * chunkSize, charsCount);
          string nameChunk = string.Join("", chars);
          PointF point = zoneRectangle.Location.Shift(new(0, fontHeight * lineIndex));

          graphics.DrawString(nameChunk, font, Brushes.White, point);
        }
      }
    }
  }
}
