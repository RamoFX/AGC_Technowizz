using System.ComponentModel;

using Communicator;



namespace Core {
  public partial class Zone {
    public partial class Entity {
      [Browsable(false)]
      internal Layout.Entity Parent;

      [Browsable(false)]
      internal int DaysPeriod;

      public void Initialize(Layout.Entity parent, int daysPeriod) {
        Parent = parent;
        DaysPeriod = daysPeriod;

        Stored = DatabaseAccess.GetPalletsCount(
          Parent.WarehouseName,
          Name,
          DaysPeriod
        );
      }
    }
  }
}