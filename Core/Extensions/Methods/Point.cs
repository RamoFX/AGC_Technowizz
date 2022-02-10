﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Core.UI;
using Core.Storage;



namespace Core.Extensions {
  static public partial class Methods {
    static public Point Scale(this Point point, int multiplier) {
      return new(point.X * multiplier, point.Y * multiplier);
    }



    static public Point Shift(this Point point, Point shift) {
      return new(
        point.X + shift.X,
        point.Y + shift.Y
      );
    }
  }
}