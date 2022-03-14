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

    static public Point Add(this Point point1, Point point2) {
      return new(point1.X + point2.X, point1.Y + point2.Y);
    }

    static public Point Subtract(this Point point1, Point point2) {
      return new(point1.X - point2.X, point1.Y - point2.Y);
    }

    static public Point Abs(this Point point) {
      return new(Math.Abs(point.X), Math.Abs(point.Y));
    }
  }
}
