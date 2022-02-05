using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Core.UI {
  public static class Colors {
    static public Color FromStringToColor(string colorString)
    {
      if (colorString.StartsWith("#"))
        return Color.FromArgb(Convert.ToInt32(HexConverter(colorString.Substring(1)), 16));
      if (colorString.StartsWith("@"))
      {
        IEnumerable<int> colors = colorString.Substring(1).Split(',').Select(color => Convert.ToInt32(color));
        return Color.FromArgb(colors.ElementAt(0), colors.ElementAt(1), colors.ElementAt(2)); 
      }
      return Color.FromName(colorString);
    }

    static string HexConverter(string hexColor)
    {
      switch (hexColor.Length)
      {
        case 4:
          hexColor += "F";
          goto case 3;
        case 3:
          string color = "";
          hexColor += "F";
          foreach (char c in hexColor)
            color += c + c.ToString();
          hexColor = color;
          break;

        case 6:
          hexColor += "FF";
          break;
        case 8:
          break;

        default:
          return "";
      }
      return hexColor;
    }
  }
}
