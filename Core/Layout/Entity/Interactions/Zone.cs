using System.Linq;



namespace Core {
  public partial class Layout {
    public partial class Entity {
      public Zone.Entity GetFirstSuitableZoneOrDefault(string carBrand) {
        return this.Zones.FirstOrDefault(zone => zone.IsSuitable(carBrand));
      }
    }
  }
}
