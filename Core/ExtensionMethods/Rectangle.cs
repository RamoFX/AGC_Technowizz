using System.Drawing;



namespace Core {
  static public partial class ExtensionMethods {
    static public Rectangle Scale(this Rectangle rectangle, int multiplier) {
      return new Rectangle(rectangle.Location.Scale(multiplier), rectangle.Size.Scale(multiplier));
    }
  }
}
