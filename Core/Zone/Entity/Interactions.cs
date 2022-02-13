namespace Core {
  public partial class Zone {
    public partial class Entity {
      public bool IsSuitable(string carBrand) {
        return this.CanStore > 0 && this.CarBrand == carBrand;
      }
    }
  }
}