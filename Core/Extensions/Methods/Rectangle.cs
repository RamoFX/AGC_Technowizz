using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Core.UI;
using Core.Storage;



namespace Core.Extensions {
  static public partial class Methods {
    static public Rectangle Scale(this Rectangle rectangle, int multiplier) {
      return new Rectangle(rectangle.Location.Scale(multiplier), rectangle.Size.Scale(multiplier));
    }

    static public Rectangle Shift(this Rectangle rectangle, Point shift) {
      return new(
        rectangle.Location.Shift(shift),
        rectangle.Size
      );
    }
  }
}
