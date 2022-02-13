﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Core.UI {
  static public class Utilities {
    static public void DelayAction(int millisecond, Action action) {
      Timer timer = new();

      timer.Tick += delegate {
        action.Invoke();
        timer.Stop();
      };

      timer.Interval = millisecond;
      timer.Start();
    }

    static public int GetTitleBarHeight(Form form) {
      return form.RectangleToScreen(form.ClientRectangle).Top - form.Top;
    }
  }
}
