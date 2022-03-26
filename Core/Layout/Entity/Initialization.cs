using System.ComponentModel;



namespace Core {
  public partial class Layout {
    public partial class Entity {
      [Browsable(false)]
      internal int DaysPeriod;



      public void Initialize(int daysPeriod) {
        DaysPeriod = daysPeriod;

        foreach (Zone.Entity zone in Zones) {
          zone.Initialize(this, DaysPeriod);
        }
      }
    }
  }
}
