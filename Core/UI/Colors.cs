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
      try {
        return Color.FromName(colorString);
      }
      catch {
        if (colorString.StartsWith("#"))
          return ColorTranslator.FromHtml(colorString.Substring(1));
        else
          return Color.FromArgb(Convert.ToInt32(colorString.Substring(1), 16));
      }
    }
  }
}
