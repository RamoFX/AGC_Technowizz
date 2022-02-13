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
          throw new ArgumentException("verticalCapacity");
        }

        if (!(name.Length > 0)) {
          throw new ArgumentException("name");
        }

        if (!(carBrand.Length > 0)) {
          throw new ArgumentException("carBrand");
        }

        if (size.Width < 1 || size.Height < 1) {
          throw new ArgumentException("size");
        }

        if (location.X < 0 || location.Y < 0) {
          throw new ArgumentException("location");
        }

        this.Name = name;
        this.VerticalCapacity = verticalCapacity;
        this.CarBrand = carBrand;
        this.Location = location;
        this.Size = size;
      }

      public Entity() : this("Nová zóna", 4, "značka-auta", new(1, 1), new(0, 0)) { }
    }
  }
}
