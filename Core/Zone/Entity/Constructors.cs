using System;
using System.Drawing;



namespace Core {
  public partial class Zone {
    public partial class Entity {
      public Entity(string name, int verticalCapacity, string carBrand, Size size, Point location) {
        if (name == default || carBrand == default) {
          throw new ArgumentNullException();
        }

        name = name.Trim();
        carBrand = carBrand.Trim();

        if (verticalCapacity < 0) {
          throw new ArgumentException("Invalid verticalCapacity");
        }

        if (!( name.Length > 0 )) {
          throw new ArgumentException("Invalid name");
        }

        bool isValidRegularZone = carBrand.Length > 0 && verticalCapacity > 0;
        bool isValidOtherZone = carBrand.Length == 0 && verticalCapacity == 0;
        bool isInvalidRegularOrOtherZone = !( isValidRegularZone || isValidOtherZone );

        if (isInvalidRegularOrOtherZone) {
          throw new ArgumentException("Invalid carBrand and/or verticalCapacity");
        }

        if (size.Width < 1 || size.Height < 1) {
          throw new ArgumentException("Invalid size");
        }

        if (location.X < 0 || location.Y < 0) {
          throw new ArgumentException("Invalid location");
        }

        Name = name;
        VerticalCapacity = verticalCapacity;
        CarBrand = carBrand;
        Location = location;
        Size = size;
      }



      public Entity(Entity from)
        : this(from.Name, from.VerticalCapacity, from.CarBrand, from.Size, from.Location) { }



      public Entity()
        : this("Nová zóna", 4, "značka-auta", new(1, 1), new(0, 0)) { }
    }
  }
}
