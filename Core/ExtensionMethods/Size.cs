using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Core.UI;



namespace Core.Extensions {
  static public partial class Methods {
    static public Size Scale(this Size size, int multiplier) {
      return new(size.Width * multiplier, size.Height * multiplier);
    }
  }
}
