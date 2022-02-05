﻿using Core.Storage;
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

    public static class Drawer
    {
      const int boxSize = 30;
      const int borderWidth = 3;

      const int upperSize = 240;
      const int bottomSize = 150;

      const int Astart = 0, Cstart = 0;
      const int Bstart = 510, Dstart = 870;

      const int HighlightTimeOnMs = 600;
      const int HighlightTimeOffMs = 300;

      /// <summary>
      /// Draws rectangles on all zones in layout with specific color
      /// </summary>
      /// <param name="layout"></param>
      /// <param name="color"></param>
      /// <param name="g"></param>
      /// <returns>Drawn rectangles</returns>
      public static Rectangle[] Draw(Layout layout, Color color, Graphics g)
      {
        List<Rectangle> rectangles = new();
        foreach (Zone zone in layout.Zones.Where(zone => zone.Type == ZoneType.Storage))
        {
          if (zone.Name != "X")
          {
            Rectangle rect = new();
            switch (zone.Name[0])
            {
              case 'A':
                rect.X = Astart + (Convert.ToInt32(zone.Name.Substring(1)) - 1) * boxSize;
                rect.Y = 0;
                rect.Height = upperSize;
                break;
              case 'B':
                rect.X = Bstart + (Convert.ToInt32(zone.Name.Substring(1)) - 1) * boxSize;
                rect.Y = 0;
                rect.Height = upperSize;
                break;
              case 'C':
                rect.X = Cstart + (Convert.ToInt32(zone.Name.Substring(1)) - 1) * boxSize;
                rect.Y = upperSize + 4 * boxSize;
                rect.Height = bottomSize;
                break;
              case 'D':
                rect.X = Dstart + (Convert.ToInt32(zone.Name.Substring(1)) - 1) * boxSize;
                rect.Y = upperSize + 4 * boxSize;
                rect.Height = bottomSize;
                break;
            }
            rect.Width = boxSize;
            rectangles.Add(rect);
          }
        }
        g.FillRectangles(new SolidBrush(Color.FromArgb(64, color)), rectangles.ToArray());
        g.DrawRectangles(new(color, borderWidth), rectangles.ToArray());
        return rectangles.ToArray();
      }

      /// <summary>
      /// Draws rectangle on zone with specific color
      /// </summary>
      /// <param name="zone"></param>
      /// <param name="color"></param>
      /// <param name="g"></param>
      /// <returns>Drawn rectangle</returns>
      public static Rectangle Draw(Zone zone, Color color, Graphics g)
      {
        if (zone != null)
        {
          Rectangle rect = new();
          switch (zone.Name[0])
          {
            case 'A':
              rect.X = Astart + (Convert.ToInt32(zone.Name.Substring(1)) - 1) * boxSize;
              rect.Y = 0;
              rect.Height = upperSize;
              break;
            case 'B':
              rect.X = Bstart + (Convert.ToInt32(zone.Name.Substring(1)) - 1) * boxSize;
              rect.Y = 0;
              rect.Height = upperSize;
              break;
            case 'C':
              rect.X = Cstart + (Convert.ToInt32(zone.Name.Substring(1)) - 1) * boxSize;
              rect.Y = upperSize + 4 * boxSize;
              rect.Height = bottomSize;
              break;
            case 'D':
              rect.X = Dstart + (Convert.ToInt32(zone.Name.Substring(1)) - 1) * boxSize;
              rect.Y = upperSize + 4 * boxSize;
              rect.Height = bottomSize;
              break;
          }
          rect.Width = boxSize;
          g.FillRectangle(new SolidBrush(Color.FromArgb(64, color)), rect);
          g.DrawRectangle(new(color, borderWidth), rect);
          return rect;
        }
        else return new();
      }
    }
  }
}