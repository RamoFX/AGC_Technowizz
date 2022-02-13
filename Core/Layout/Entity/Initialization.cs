using System.ComponentModel;



namespace Core {
  public partial class Layout {
    public partial class Entity {
      [Browsable(false)]
      internal int DaysPeriod;



      public void Initialize(int daysPeriod) {
        this.DaysPeriod = daysPeriod;

        foreach (Zone.Entity zone in this.Zones) {
          zone.Initialize(this, this.DaysPeriod);
        }
      }
    }
  }
}
