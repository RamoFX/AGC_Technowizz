using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Core.Storage;



namespace Core {
  static class Extensions {
    private const char CustomStringSeparator = ',';

    static public string ToCustomString(this Size size) {
      return $"{ size.Width }{ CustomStringSeparator }{ size.Height }";
    }

    static public string ToCustomString(this Point point) {
      return new Size(point).ToCustomString();
    }

    static public Size ToSize(this string value) {
      string[] values = value.Split(CustomStringSeparator);
      int width = int.Parse(values[0]);
      int height= int.Parse(values[1]);

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
