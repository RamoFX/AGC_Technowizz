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



    static public object MatchEntity(Point location, Layout.Entity layout) {
      // Handle invalid parameter values
      if (location.X < 0 || location.Y < 0 || layout == null)
        return null;

      location = location.Unscale(StaticSettings.UNIT_SIZE);

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



    static public Rectangle CreateMovingClip(Rectangle unscaledEntityBounds) {
      var clip = unscaledEntityBounds.Scale(StaticSettings.UNIT_SIZE);

      clip.X += StaticSettings.CLIP_OFFSET;
      clip.Y += StaticSettings.CLIP_OFFSET;

      clip.Width -= StaticSettings.CLIP_OFFSET * 2;
      clip.Height -= StaticSettings.CLIP_OFFSET * 2;

      return clip;
    }



    static public Rectangle CreateResizingClip(Rectangle unscaledEntityBounds) {
      var clip = unscaledEntityBounds.Scale(StaticSettings.UNIT_SIZE);

      clip.X -= StaticSettings.CLIP_OFFSET;
      clip.Y -= StaticSettings.CLIP_OFFSET;

      clip.Width += StaticSettings.CLIP_OFFSET * 2;
      clip.Height += StaticSettings.CLIP_OFFSET * 2;

      return clip;
    }
  }
}
