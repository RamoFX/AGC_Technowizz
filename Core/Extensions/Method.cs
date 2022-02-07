using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Core.UI;
using Core.Storage;



namespace Core.Extensions {
  static public class Method {
    // Color
    static public Color ToColor(this string colorString) {
      if (colorString.StartsWith("#"))
        return Color.FromArgb(Convert.ToInt32(Colors.HexConverter(colorString.Substring(1)), 16));
      if (colorString.StartsWith("@")) {
        IEnumerable<int> colors = colorString.Substring(1).Split(',').Select(color => Convert.ToInt32(color));
        return Color.FromArgb(colors.ElementAt(0), colors.ElementAt(1), colors.ElementAt(2));
      }
      return Color.FromName(colorString);
    }



    // To string
    static public string ToCustomString(this Size size) {
      return $"{ size.Width }{ StaticSettings.CustomStringSeparator }{ size.Height }";
    }

    static public string ToCustomString(this Point point) {
      return new Size(point).ToCustomString();
    }



    // To object
    static public Size ToSize(this string value) {
      string[] values = value.Split(StaticSettings.CustomStringSeparator);
      int width = int.Parse(values[0]);
      int height = int.Parse(values[1]);

      return new Size(width, height);
    }

    static public Point ToPoint(this string value) {
      return new Point(value.ToSize());
    }

    static public int ToInt(this string value) {
      return int.Parse(value);
    }

    static public ZoneType ToZoneType(this string value, bool ignoreCase) {
      return (ZoneType) Enum.Parse(typeof(ZoneType), value, ignoreCase);
    }



    // Scaling
    static public Point Scale(this Point point, int multiplier) {
      return new(point.X * multiplier, point.Y * multiplier);
    }

    static public Size Scale(this Size size, int multiplier) {
      return new(size.Width * multiplier, size.Height * multiplier);
    }

    static public Rectangle Scale(this Rectangle rectangle, int multiplier) {
      return new Rectangle(rectangle.Location.Scale(multiplier), rectangle.Size.Scale(multiplier));
    }



    // Identation
    // For example if drawing an outline, then change dimension to make it draw INSIDE its rectangle
    static public Point IndentateInside(this Point point, bool isFirst) {
      if (isFirst) {
        int x = point.X + StaticSettings.OutlineSize;
        int y = point.Y + StaticSettings.OutlineSize;

        return new Point(x, y);
      } else {
        int x = point.X - StaticSettings.OutlineSize * 2;
        int y = point.Y - StaticSettings.OutlineSize * 2;

        return new Point(x, y);
      }
    }

    static public Size IndentateInside(this Size size, bool isFirst) {
      return new Size(new Point(size).IndentateInside(isFirst));
    }

    static public Rectangle IndentateInside(this Rectangle rectangle) {
      return new Rectangle(rectangle.Location.IndentateInside(true), rectangle.Size.IndentateInside(false));
    }



    // Drawing
    static public Pen ToPen(this Color color) {
      return new Pen(color, StaticSettings.OutlineSize);
    }



    // Scaling IStorageMember
    static public IStorageMember Scale(this IStorageMember storageMembers, int multiplier) {
      IStorageMember scaledStorageMember = (IStorageMember) storageMembers.Clone();

      scaledStorageMember.Location = scaledStorageMember.Location.Scale(multiplier);
      scaledStorageMember.Size = scaledStorageMember.Size.Scale(multiplier);

      return scaledStorageMember;
    }

    static public IEnumerable<IStorageMember> Scale(this IEnumerable<IStorageMember> storageMembers, int multiplier) {
      List<IStorageMember> scaledStorageMembers = new();

      foreach (IStorageMember storageMember in storageMembers) {
        scaledStorageMembers.Add(storageMember.Scale(multiplier));
      }

      return scaledStorageMembers;
    }



    // Identation IStorageMember
    static public IStorageMember IndentateInside(this IStorageMember storageMembers, int level) {
      IStorageMember identatedStorageMembers = (IStorageMember) storageMembers.Clone();

      for (int levelIndex = 0; levelIndex < level; levelIndex++) {
        identatedStorageMembers.Location = identatedStorageMembers.Location.IndentateInside(true);
        identatedStorageMembers.Size = identatedStorageMembers.Size.IndentateInside(false);
      }

      return identatedStorageMembers;
    }

    static public IEnumerable<IStorageMember> IndentateInside(this IEnumerable<IStorageMember> storageMembers, int level) {
      List<IStorageMember> identatedStorageMembers = new();

      foreach (IStorageMember storageMember in storageMembers) {
        identatedStorageMembers.Add(storageMember.IndentateInside(level));
      }

      return identatedStorageMembers;
    }



    // Fixing nested identation IStorageMember
    static public IStorageMember FixNestedIndentation(this IStorageMember child, IStorageMember parent, int levelDifference) {
      IStorageMember fixedChild = (IStorageMember) child.Clone();



      // Computations
      int offset = levelDifference * StaticSettings.OutlineSize;

      bool isHorizontallyFirst = child.Location.X - offset == parent.Location.X;
      bool isHorizontallyLast = child.Location.X + child.Size.Width + offset == parent.Location.X + parent.Size.Width;
      bool isHorizontallyAlone = isHorizontallyFirst && isHorizontallyLast;

      bool isVerticallyFirst = child.Location.Y - offset == parent.Location.Y;
      bool isVerticallyLast = child.Location.Y + child.Size.Height + offset == parent.Location.Y + parent.Size.Height;
      bool isVerticallyAlone = isVerticallyFirst && isVerticallyLast;



      // Preparation
      int x = fixedChild.Location.X;
      int y = fixedChild.Location.Y;

      int width = fixedChild.Size.Width;
      int height = fixedChild.Size.Height;



      // Fixing
      if (!isHorizontallyAlone) {
        if (isHorizontallyFirst) {
          width += offset;
        } else if (isHorizontallyLast) {
          x -= offset;
          width += offset;
        } else {
          x -= offset;
          width += offset * 2;
        }
      }

      if (!isVerticallyAlone) {
        if (isVerticallyFirst) {
          height += offset;
        } else if (isVerticallyLast) {
          y -= offset;
          height += offset;
        } else {
          y -= offset;
          height += offset * 2;
        }
      }



      // Changing
      fixedChild.Location = new(x, y);
      fixedChild.Size = new(width, height);



      return fixedChild;
    }

    static public IEnumerable<IStorageMember> FixNestedIndentation(this IEnumerable<IStorageMember> children, IStorageMember parent, int levelDifference) {
      List<IStorageMember> fixedStorageMembers = new();

      if (children.Count() > 0) {
        foreach (IStorageMember child in children) {
          fixedStorageMembers.Add(child.FixNestedIndentation(parent, levelDifference));
        }
      }

      return fixedStorageMembers;
    }



    // Drawing IStorageMember
    static public void DrawVisualizable(this Graphics graphics, IStorageMember storageMember) {
      graphics.DrawRectangle(storageMember.Color.ToPen(), storageMember.Rectangle);
    }

    static public void DrawVisualizables(this Graphics graphics, IEnumerable<IStorageMember> storageMember) {
      foreach (var visualizable in storageMember) {
        graphics.DrawVisualizable(visualizable);
      }
    }
  }
}
