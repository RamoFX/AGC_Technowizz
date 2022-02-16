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



    static public object GetEntityFromTreePath(string path, char[] pathSeparator, Layout.Entity layout) {
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
  }
}
