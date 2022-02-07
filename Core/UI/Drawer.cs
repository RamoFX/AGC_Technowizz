using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Extensions;
using Core.Storage;



namespace Core.UI {
  public static class Drawer {
    /// <summary>
    /// Draws rectangles on all zones in layout with specific color
    /// </summary>
    /// <param name="layout"></param>
    /// <param name="color"></param>
    /// <param name="g"></param>
    /// <returns>Drawn rectangles</returns>
    public static Rectangle[] Draw(Layout layout, Color color, Graphics g) {
      List<Rectangle> rectangles = new();
      foreach (Zone zone in layout.Zones.Where(zone => zone.Type == ZoneType.Storage)) {
        if (zone != null) {
          Rectangle rect = new(zone.Location.X * StaticSettings.UnitSize,
                               zone.Location.Y * StaticSettings.UnitSize,
                               zone.Size.Width * StaticSettings.UnitSize,
                               zone.Size.Height * StaticSettings.UnitSize);
          rectangles.Add(rect);
        }
      }
      g.FillRectangles(new SolidBrush(Color.FromArgb(64, color)), rectangles.ToArray());
      g.DrawRectangles(new(color, StaticSettings.OutlineSize), rectangles.ToArray());
      return rectangles.ToArray();
    }

    /// <summary>
    /// Draws rectangle on zone with specific color
    /// </summary>
    /// <param name="zone"></param>
    /// <param name="color"></param>
    /// <param name="g"></param>
    /// <returns>Drawn rectangle</returns>
    public static Rectangle Draw(Zone zone, Color color, Graphics g) {
      if (zone != null) {
        Rectangle rect = new(zone.Location.X * StaticSettings.UnitSize,
                             zone.Location.Y * StaticSettings.UnitSize,
                             zone.Size.Width * StaticSettings.UnitSize,
                             zone.Size.Height * StaticSettings.UnitSize);
        g.FillRectangle(new SolidBrush(Color.FromArgb(64, color)), rect);
        g.DrawRectangle(new(color, StaticSettings.OutlineSize), rect);
        return rect;
      } else
        return new();
    }



    // Helpers
    static int CalculateUnitSize(Control control, Layout layout, Size offset) {
      // Final unit size - fit to screen size or if too small apply default StaticSettting's size
      int unitSize_windowAdapted = Math.Min(
        (control.Width - offset.Width) / layout.Size.Width,
        (control.Height - offset.Height) / layout.Size.Height
      );

      int unitSize_preferred = unitSize_windowAdapted < StaticSettings.UnitSize
        ? StaticSettings.UnitSize
        : unitSize_windowAdapted;

      return unitSize_preferred;
    }



    // Draw
    static public void DrawGrid(Graphics graphics, Layout layout, int unitSize) {
      Pen pen = DynamicSettings.GridColor.Value.ToColor().ToPen();

      for (int x = 1; x < layout.Size.Width; x++) {
        for (int y = 1; y < layout.Size.Height; y++) {
          graphics.DrawLine(
            pen,
            new Point(0, y).Scale(unitSize),
            new Point(layout.Size.Width, y).Scale(unitSize)
          );

          //Rectangle rectangle = new(x, y, x + 1, y + 1);
          //DrawOutline(graphics, pen, rectangle.Scale(unitSize));
        }

        graphics.DrawLine(
          pen,
          new Point(x, 0).Scale(unitSize),
          new Point(x, layout.Size.Height).Scale(unitSize)
        );
      }
    }

    static public void DrawLayout(Control drawControl, Layout layout, Size offset) {
      // Preparation
      Graphics graphics = drawControl.CreateGraphics();
      int unitSize = CalculateUnitSize(drawControl, layout, offset);

      // Clear previous drawing
      graphics.Clear(drawControl.BackColor);

      // Grid
      DrawGrid(graphics, layout, unitSize);

      // Layout
      var layoutReady = layout.Scale(unitSize).IndentateInside(0);

      graphics.DrawVisualizable(layoutReady);

      // Zones
      var zones = layout.Zones;
      var zonesReady = zones.Scale(unitSize).IndentateInside(1);

      graphics.DrawVisualizables(zonesReady);

      // CarBrands
      for (int zoneIndex = 0; zoneIndex < zones.Count(); zoneIndex++) {
        var zone = zones.ElementAt(zoneIndex);
        var zoneReady = zonesReady.ElementAt(zoneIndex);

        var carBrands = zone.CarBrands;
        var carBrandsReady = carBrands.Scale(unitSize).IndentateInside(2);

        graphics.DrawVisualizables(
          carBrandsReady.FixNestedIndentation(zoneReady, 1)
        );
      }
    }

    static public void DrawLayout(Layout layout, Control control) {
      DrawLayout(control, layout, new());
    }
  }
}
