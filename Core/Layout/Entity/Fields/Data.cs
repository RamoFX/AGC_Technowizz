using System;
using System.ComponentModel;
using System.Linq;



namespace Core {
  public partial class Layout {
    public partial class Entity {
      [Browsable(false)]
      public int Area {
        get => Size.Width * Size.Height;
      }



      [Browsable(false)]
      public int Area_Zones {
        get => Zones.Sum(zone => zone.Area);
      }



      [Browsable(false)]
      public int MaxCapacity {
        get => Zones.Sum(zone => zone.MaxCapacity);
      }



      [Browsable(false)]
      public int Stored {
        get => Zones.Sum(zone => zone.Stored);
      }



      [Browsable(false)]
      public int StoredPercent {
        get {
          if (Zones.Count == 0)
            return 0;

          double average = Zones.Average(carBrand => carBrand.StoredPercent);

          return (int) Math.Round(average);
        }
      }



      [Browsable(false)]
      public int CanStore {
        get => Zones.Sum(zone => zone.CanStore);
      }
    }
  }
}
