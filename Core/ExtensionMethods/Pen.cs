using System.Drawing;



namespace Core {
  static public partial class ExtensionMethods {
    static public Pen ToPen(this Color color, int size) {
      return new Pen(color, size);
    }
  }
}
