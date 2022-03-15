﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Core.UI;



namespace Core.Extensions {
  static public partial class Methods {
    static public SolidBrush ToBrush(this Color color) {
      return new SolidBrush(color);
    }



    static public SolidBrush Transparentize(this SolidBrush brush, int alpha) {
      return new SolidBrush(brush.Color.Transparentize(alpha));
    }
  }
}