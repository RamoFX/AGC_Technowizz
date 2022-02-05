using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Storage;



namespace Core.UI {
  public static class Drawer {
    const int borderWidth = 3;

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
      g.DrawRectangles(new(color, borderWidth), rectangles.ToArray());
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
        g.DrawRectangle(new(color, borderWidth), rect);
        return rect;
      } else
        return new();
    }

    /// <summary>
    /// Returns color that should be a background for drawing specific CarBrand
    /// </summary>
    /// <param name="carBrandUsage"></param>
    /// <returns>Color</returns>
    public static Color GetColorByCarBrandUsage(CarBrand carBrand) {
      int carBrandUsage = carBrand.PalletsCurrentlyStored / carBrand.MaxCapacity;
      if (carBrandUsage == 100)
        return Colors.Color100;
      if (carBrandUsage >= 75)
        return Colors.Color99_75;
      if (carBrandUsage >= 50)
        return Colors.Color74_50;
      if (carBrandUsage >= 25)
        return Colors.Color49_25;
      if (carBrandUsage > 0)
        return Colors.Color24_1;

      return Color.Transparent;
    }
  }
}
