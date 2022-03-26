namespace Core {
  public partial class Zone {
    public partial class Entity {
      public bool IsSuitable(string carBrand) {
        return CanStore > 0 && CarBrand == carBrand;
      }



      public bool IsLoadable() {
        return !( VerticalCapacity == 0 && CarBrand == "" );
      }



      public void Change(Entity edited) {
        Name = edited.Name;
        CarBrand = edited.CarBrand;
        VerticalCapacity = edited.VerticalCapacity;
        Size = edited.Size;
        Location = edited.Location;
      }
    }
  }
}