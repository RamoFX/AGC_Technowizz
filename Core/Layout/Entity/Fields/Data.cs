using System;
using System.ComponentModel;
using System.Linq;



namespace Core {
  public partial class Layout {
    public partial class Entity {
      [Browsable(false)]
      public int Area {
        get => this.Size.Width * this.Size.Height;
      }



      [Browsable(false)]
      public int Area_Zones {
        get => this.Zones.Sum(zone => zone.Area);
      }



      [Browsable(false)]
      public int MaxCapacity {
        get => this.Zones.Sum(zone => zone.MaxCapacity);
      }



      [Browsable(false)]
      public int Stored {
        get => this.Zones.Sum(zone => zone.Stored);
      }



      [Browsable(false)]
      public int StoredPercent {
        get {
          if (this.Zones.Count == 0)
            return 0;

          double average = this.Zones.Average(carBrand => carBrand.StoredPercent);

          return (int) Math.Round(average);
        }
      }



      [Browsable(false)]
      public int CanStore {
        get => this.Zones.Sum(zone => zone.CanStore);
      }
    }
  }
}
