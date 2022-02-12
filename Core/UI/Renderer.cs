using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Extensions;
using Core.Storage;



namespace Core.UI {
  static internal class Renderer {
    //static public Layer RenderGrid(int widthUnscaled, int heightUnscaled) {
    //  Bitmap bitmap = new(0, 0);
    //  Layer layer = new(bitmap, carBrand.Rectangle);
    //  using Graphics graphics = Graphics.FromImage(bitmap);

    //  // Vertical grid lines
    //  for (int x = 0; x <= width; x++) {
    //    graphics.DrawLine(
    //      penNeutralLight,

    //      new Point(x, 0)
    //        .Scale(unitSize),

    //      new Point(x, layout.Size.Height)
    //        .Scale(unitSize)
    //    );
    //  }

    //  // Horizontal grid lines
    //  for (int y = 0; y <= height; y++) {
    //    graphics.DrawLine(
    //      penNeutralLight,

    //      new Point(0, y)
    //        .Scale(unitSize),

    //      new Point(layout.Size.Width, y)
    //        .Scale(unitSize)
    //    );
    //  }

    //  return layer;
    //}



    static public Layer RenderZone(Zone zone) {
      // Preparation
      int unitSize = StaticSettings.UNIT_SIZE;

      int width = zone.Size.Width * unitSize;
      int height = zone.Size.Height * unitSize;
      Rectangle rectangle = zone.Rectangle.Scale(unitSize);

      // Creation
      Bitmap bitmap = new(width, height);
      Layer layer = new(bitmap, rectangle);

      // Rendering
      using Graphics graphics = Graphics.FromImage(bitmap);

      return layer;
    }
  }
}
