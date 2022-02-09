using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Core.UI;
using Core.Storage;



namespace Core.Extensions {
  static public partial class Methods {
    static public Pen ToPen(this Color color, int size) {
      return new Pen(color, size);
    }

    static public Pen Dashed(this Pen pen) {
      Pen newPen = new(pen.Color, pen.Width);

      int width = StaticSettings.OutlineSize;
      newPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
      newPen.DashPattern = new float[] { width, width * 2 };

      return newPen;
    }
  }
}
