using System;
using System.Drawing;

using Core.Extensions;
using Core.Settings;



namespace Core.UI {
  public static class Drawer {
    static private readonly Pen NeutralLight = DynamicSettings.GridColor.Value.ToColor().ToPen(StaticSettings.OUTLINE_SIZE);



    static public void DrawLayout(Graphics graphics, Rectangle clip, int unitSize, Layout.Entity layout, object selection, bool isHightContrast, bool isCreatingZone, Point dragStart, Point dragEnd) {
      // Current visible clip
      graphics.SetClip(clip);



      // Vertical grid lines
      for (int x = 0; x <= layout.Size.Width; x++) {
        // Draw only if inside visible clip
        if (!graphics.IsVisible(x * unitSize, clip.Location.Y))
          continue;

        graphics.DrawLine(
          NeutralLight,

          new Point(x, 0)
            .Scale(unitSize),

          new Point(x, layout.Size.Height)
            .Scale(unitSize)
        );
      }



      // Horizontal grid lines
      for (int y = 0; y <= layout.Size.Height; y++) {
        // Draw only if inside visible clip
        if (!graphics.IsVisible(clip.Location.X, y * unitSize))
          continue;

        graphics.DrawLine(
          NeutralLight,

          new Point(0, y)
            .Scale(unitSize),

          new Point(layout.Size.Width, y)
            .Scale(unitSize)
        );
      }



      // Zones
      foreach (Zone.Entity zone in layout.Zones) {
        var zoneRectangle = zone.Rectangle.Scale(unitSize);

        // Draw only if inside visible clip
        if (!graphics.IsVisible(zoneRectangle))
          continue;

        // Preparation
        bool isSelection = zone == selection;
        bool doDraw = !isHightContrast || ( isHightContrast && isSelection );

        var brush = zone.Color
            .ToBrush()
            .Transparentize(isSelection ? 150 : 200);

        var pen = zone.Color
            .ToPen(StaticSettings.OUTLINE_SIZE);

        // Draw
        if (doDraw)
          graphics.FillRectangle(brush, zoneRectangle);

        graphics.DrawRectangle(pen, zoneRectangle);

        // Text
        if (doDraw)
          graphics.DrawString(zone.Name, StaticSettings.ZoneNameFont, Brushes.White, zoneRectangle);
      }



      // Dragging creation
      if (!isCreatingZone)
        return;

      var creationColor = DynamicSettings.DragCreationColor.Value.ToColor();
      var creationPen = creationColor.ToPen(StaticSettings.OUTLINE_SIZE);
      var creationBrush = creationColor.ToBrush().Transparentize(150);
      var creationRectangle = Utilities.CreateRectangleFromPoints(dragStart, dragEnd).Scale(unitSize);

      graphics.DrawRectangle(creationPen, creationRectangle);
      graphics.FillRectangle(creationBrush, creationRectangle);
    }
    


    static public void DrawLayout(Graphics graphics, Rectangle clip, int unitSize, Layout.Entity layout, object selection, bool isHightContrast) {
      DrawLayout(graphics, clip, unitSize, layout, selection, isHightContrast, false, new(), new());
    }
  }
}
