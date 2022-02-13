using System;
using System.ComponentModel;



namespace Core {
  public partial class Zone {
    public partial class Entity {
      [Browsable(false)]
      public int Area {
        get => this.Size.Width * this.Size.Height;
      }

      [Browsable(false)]
      public int MaxCapacity {
        get => this.Area * this.VerticalCapacity;
      }

      [Browsable(false)]
      public int Stored;

      [Browsable(false)]
      public int StoredPercent {
        get {
          if (this.VerticalCapacity == 0) {
            return 0;
          }

          return (int) Math.Round((decimal) this.Stored / this.MaxCapacity * 100);
        }
      }

      [Browsable(false)]
      public int CanStore {
        get => this.MaxCapacity - this.Stored;
      }
    }
  }
}
