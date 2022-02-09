using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Core.UI;
using Core.Storage;



namespace Core.Extensions {
  static public partial class Methods {
    static public Color ToColor(this string colorString) {
      if (colorString.StartsWith("#"))
        return Color.FromArgb(Convert.ToInt32(Colors.HexConverter(colorString.Substring(1)), 16));
      if (colorString.StartsWith("@")) {
        IEnumerable<int> colors = colorString.Substring(1).Split(',').Select(color => Convert.ToInt32(color));
        return Color.FromArgb(colors.ElementAt(0), colors.ElementAt(1), colors.ElementAt(2));
      }
      return Color.FromName(colorString);
    }

    static public Color Transparentize(this Color color, int alpha) {
      return Color.FromArgb(alpha, color);
    }

    static public Color Transparentize(this Color color) {
      return color.Transparentize(200);
    }
  }
}
