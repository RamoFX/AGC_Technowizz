using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

using Core.UI;



namespace Core.Extensions {
  static public partial class Methods {
    static public Point Scale(this Point point, int scaleFactor) {
      return new(point.X * scaleFactor, point.Y * scaleFactor);
    }

    static public Point Unscale(this Point point, int scaleFactor) {
      return new(point.X / scaleFactor, point.Y / scaleFactor);
    }
  }
}
