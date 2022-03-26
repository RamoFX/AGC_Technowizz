namespace Core {
  public partial class Layout {
    public partial class Entity {
      public void Add(Zone.Entity zone, int daysPeriod) {
        Zones.Add(zone);
        zone.Initialize(this, daysPeriod);
      }



      public void Add(Zone.Entity zone) {
        Zones.Add(zone);
        zone.Initialize(this, DaysPeriod);
      }



      public void Change(Entity edited) {
        Name = edited.Name;
        WarehouseName = edited.WarehouseName;
        Size = edited.Size;
      }
    }
  }
}
