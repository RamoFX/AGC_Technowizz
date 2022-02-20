using Core.Extensions;
using System;
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



    static public object MatchEntity(Point location, int scaleFactor, Layout.Entity layout) {
      // Handle invalid parameter values
      if (location.X < 0 || location.Y < 0 || scaleFactor < 1 || layout == null)
        return null;

      location = location.Unscale(scaleFactor);

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
  }
}
