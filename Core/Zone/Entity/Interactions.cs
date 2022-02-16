namespace Core {
  public partial class Zone {
    public partial class Entity {
      public bool IsSuitable(string carBrand) {
        return this.CanStore > 0 && this.CarBrand == carBrand;
      }



      public void Change(Entity edited) {
        this.Name = edited.Name;
        this.CarBrand = edited.CarBrand;
        this.VerticalCapacity = edited.VerticalCapacity;
        this.Size = edited.Size;
        this.Location = edited.Location;
      }
    }
  }
}