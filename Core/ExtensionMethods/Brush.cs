using System.Drawing;



namespace Core {
  static public partial class ExtensionMethods {
    static public SolidBrush ToBrush(this Color color) {
      return new SolidBrush(color);
    }



    static public SolidBrush Transparentize(this SolidBrush brush, int alpha) {
      return new SolidBrush(brush.Color.Transparentize(alpha));
    }
  }
}
