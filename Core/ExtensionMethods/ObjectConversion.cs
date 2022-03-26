using System.Drawing;
using Core.Settings;



namespace Core {
  static public partial class ExtensionMethods {
    static public Size ToSize(this string value) {
      string[] values = value.Split(StaticSettings.CUSTOM_STRING_SEPARATOR);
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
  }
}
