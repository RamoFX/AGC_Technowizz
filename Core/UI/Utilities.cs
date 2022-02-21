using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Core.Extensions;
using Core.Settings;



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



    static public int ComputeTitleBarHeight(Form form) {
      return form.RectangleToScreen(form.ClientRectangle).Top - form.Top;
    }



    static public object MatchEntity(string path, char[] pathSeparator, Layout.Entity layout) {
      string[] pathPieces = path.Split(pathSeparator);
      int level = pathPieces.Length - 1;
      object currentSelection = null;

      // Find current selection which can be Layout or Zone
      if (level == 0 || level == 1) {
        if (level == 0) {
          if (pathPieces[level] == layout.Name) {
            currentSelection = layout;
          }
        } else {
          foreach (var zone in layout.Zones) {
            if (level == 1) {
              if (pathPieces[level] == zone.Name) {
                currentSelection = zone;

                break;
              }
            }
          }
        }
      }

      return currentSelection;
    }



    static public object MatchEntity(Point location, int unitSize, Layout.Entity layout) {
      // Handle invalid parameter values
      if (location.X < 0 || location.Y < 0 || layout == null)
        return null;

      location = location.Unscale(unitSize);

      // Handle location out of bounds
      if (!layout.Rectangle.Contains(location))
        return null;

      // Find zone match
      foreach (var zone in layout.Zones) {
        if (zone.Rectangle.Contains(location))
          return zone;
      }

      // Match is layout
      return layout;
    }



    public static int ComputeOptimalUnitSize(int unitSize, Size canvas, Size layoutUnscaled) {
      int adapted = Math.Min(
        canvas.Width / layoutUnscaled.Width,
        canvas.Height / layoutUnscaled.Height
      );

      bool isApadtedTooSmall = adapted < unitSize;

      return isApadtedTooSmall ? unitSize : adapted;
    }
  }
}
