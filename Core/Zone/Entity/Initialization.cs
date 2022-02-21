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
        this.Parent = parent;
        this.DaysPeriod = daysPeriod;

        this.Stored = DatabaseAccess.GetPalletsCount(
          this.Parent.WarehouseName,
          this.Name,
          this.DaysPeriod
        );
      }
    }
  }
}