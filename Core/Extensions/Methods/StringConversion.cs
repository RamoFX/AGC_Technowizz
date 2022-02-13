﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Core.UI;
using Core.Settings;



namespace Core.Extensions {
  static public partial class Methods {
    static public string ToCustomString(this Size size) {
      return $"{ size.Width }{ StaticSettings.CUSTOM_STRING_SEPARATOR }{ size.Height }";
    }



    static public string ToCustomString(this Point point) {
      return new Size(point).ToCustomString();
    }
  }
}
