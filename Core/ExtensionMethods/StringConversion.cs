using System.Drawing;
using Core.Settings;



namespace Core {
  static public partial class ExtensionMethods {
    static public string ToCustomString(this Size size) {
      return $"{ size.Width }{ StaticSettings.CUSTOM_STRING_SEPARATOR }{ size.Height }";
    }



    static public string ToCustomString(this Point point) {
      return new Size(point).ToCustomString();
    }
  }
}
