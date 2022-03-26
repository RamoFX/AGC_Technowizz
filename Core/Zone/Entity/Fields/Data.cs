using System;
using System.ComponentModel;



namespace Core {
  public partial class Zone {
    public partial class Entity {
      [Browsable(false)]
      public int Area {
        get => Size.Width * Size.Height;
      }

      [Browsable(false)]
      public int MaxCapacity {
        get => Area * VerticalCapacity;
      }

      [Browsable(false)]
      public int Stored;

      [Browsable(false)]
      public int StoredPercent {
        get {
          if (VerticalCapacity == 0) {
            return 0;
          }

          return (int) Math.Round((decimal) Stored / MaxCapacity * 100);
        }
      }

      [Browsable(false)]
      public int CanStore {
        get => MaxCapacity - Stored;
      }
    }
  }
}
