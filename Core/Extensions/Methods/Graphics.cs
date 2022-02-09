using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Core.UI;
using Core.Storage;



namespace Core.Extensions {
  static public partial class Methods {
    static public void DrawCarBrand(this Graphics graphics, CarBrand carBrand, Point parent) {
      var brush = carBrand.Color
          .ToBrush()
          .Transparentize();

      var rectangle = carBrand.Rectangle
          .Shift(parent)
          .Scale(StaticSettings.UnitSize);

      graphics.FillRectangle(brush, rectangle);
    }
  }
}
