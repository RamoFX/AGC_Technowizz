using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

using Core.UI;



namespace Core.Extensions {
  static public partial class Methods {
    static public Pen ToPen(this Color color, int size) {
      return new Pen(color, size);
    }



    static public Pen Style(this Pen pen, DashStyle dashStyle, params float[] pattern) {
      Pen newPen = new(pen.Color, pen.Width);

      newPen.DashStyle = dashStyle;
      newPen.DashPattern = pattern;

      return newPen;
    }
  }
}
