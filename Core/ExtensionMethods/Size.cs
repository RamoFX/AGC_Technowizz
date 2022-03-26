using System.Drawing;



namespace Core {
  static public partial class ExtensionMethods {
    static public Size Scale(this Size size, int multiplier) {
      return new(size.Width * multiplier, size.Height * multiplier);
    }
  }
}
