using System.Drawing;



namespace Core {
  static public partial class ExtensionMethods {
    static public Point Scale(this Point point, int scaleFactor) {
      return new(point.X * scaleFactor, point.Y * scaleFactor);
    }

    static public Point Unscale(this Point point, int scaleFactor) {
      return new(point.X / scaleFactor, point.Y / scaleFactor);
    }
  }
}
