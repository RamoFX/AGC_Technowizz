﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Core.UI;
using Core.Storage;



namespace Core.Extensions {
  static public partial class Methods {
    static public Size ToSize(this string value) {
      string[] values = value.Split(StaticSettings.CustomStringSeparator);
      int width = int.Parse(values[0]);
      int height = int.Parse(values[1]);

      return new Size(width, height);
    }



    static public Point ToPoint(this string value) {
      return new Point(value.ToSize());
    }



    static public int ToInt(this string value) {
      return int.Parse(value);
    }



    static public ZoneType ToZoneType(this string value, bool ignoreCase) {
      return (ZoneType) Enum.Parse(typeof(ZoneType), value, ignoreCase);
    }
  }
}