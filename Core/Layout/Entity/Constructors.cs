using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;



namespace Core {
  public partial class Layout {
    public partial class Entity {
      public Entity(string name, string warehouseName, Size size, IEnumerable<Zone.Entity> zones) {
        if (name == default || warehouseName == default || zones == default) {
          throw new ArgumentNullException();
        }

        name = name.Trim();
        warehouseName = warehouseName.Trim();

        if (!(name.Length > 0)) {
          throw new ArgumentException("name");
        }

        if (!(warehouseName.Length > 0)) {
          throw new ArgumentException("warehouseName");
        }

        if (size.Width < 1 || size.Height < 1) {
          throw new ArgumentException("size");
        }

        this.Name = name;
        this.WarehouseName = warehouseName;
        this.Size = size;
        this.Zones = zones.ToList();
      }



      public Entity(string name, string warehouseName, Size size)
        : this(name, warehouseName, size, new Zone.Entity[0] { }) { }



      public Entity(Entity from)
        : this(from.Name, from.WarehouseName, from.Size, from.Zones) { }


      public Entity()
        : this("Nové rozložení", "název-skladu", new Size(10, 10)) { }
    }
  }
}
