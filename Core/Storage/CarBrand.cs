using System;
using System.Drawing;
using System.Xml.Linq;

using Communicator;
using Core.Helpers;



namespace Core.Storage {
  public class CarBrand : XElementConvertable<CarBrand>, IStorageMember {
    // Main
    public string Name;



    // IVisualizable
    public Point Location { get; set; }

    public Size Size { get; set; }

    public Rectangle Rectangle {
      get => new(this.Location, this.Size);
    }

    public Color Color {
      get {
        if (this.PalletsCurrentlyStoredPercent == 100) {
          return DynamicSettings.CarBrandColor_Full.Value.ToColor();
        } else if (this.PalletsCurrentlyStoredPercent < 100 && this.PalletsCurrentlyStoredPercent >= 75) {
          return DynamicSettings.CarBrandColor_AlmostFull.Value.ToColor();
        } else if (this.PalletsCurrentlyStoredPercent < 75 && this.PalletsCurrentlyStoredPercent >= 50) {
          return DynamicSettings.CarBrandColor_AboveHalf.Value.ToColor();
        } else if (this.PalletsCurrentlyStoredPercent < 50 && this.PalletsCurrentlyStoredPercent >= 25) {
          return DynamicSettings.CarBrandColor_BelowHalf.Value.ToColor();
        } else if (this.PalletsCurrentlyStoredPercent < 25 && this.PalletsCurrentlyStoredPercent > 0) {
          return DynamicSettings.CarBrandColor_AlmostEmpty.Value.ToColor();
        } else {
          return DynamicSettings.CarBrandColor_Empty.Value.ToColor();
        }
      }
    }



    // Computations
    public int MaxCapacity {
      get => this.Size.Width * this.Size.Height * this.LayoutParent.VerticalCapacity;
    }

    public int PalletsCurrentlyStored {
      get {
        if (this.UseDatabaseAccess) {
          return DatabaseAccess.GetZonePalletsCount(this.LayoutParent.WarehouseName, this.ZoneParent.Name, this.Name);
        } else {
          return 0;
        }
      }
    }

    public int PalletsCurrentlyStoredPercent {
      get => (int) Math.Round((decimal) this.PalletsCurrentlyStored / this.MaxCapacity * 100);
    }

    public int PalletsCanBeStored {
      get => this.MaxCapacity - this.PalletsCurrentlyStored;
    }



    // Other
    private Layout LayoutParent;
    private Zone ZoneParent;
    private bool UseDatabaseAccess = false;

    

    // Constructors
    public CarBrand(string name, Point location, Size size) {
      this.Name = name;
      this.Location = location;
      this.Size = size;
    }



    // Initializators
    public void Initialize(Layout layoutParent, Zone zoneParent, bool useDatabaseAccess) {
      this.LayoutParent = layoutParent;
      this.ZoneParent = zoneParent;
      this.UseDatabaseAccess = useDatabaseAccess;
    }



    // Self interaction
    public bool HasAvailableSpace() {
      return this.PalletsCanBeStored > 0;
    }



    // XElementConvertable
    override public XElement ToXElement() {
      XAttribute[] attributes = {
        new("name", this.Name),
        new("location", this.Location.ToCustomString()),
        new("size", this.Size.ToCustomString())
      };

      return XmlLinqUtilities.CreateElement("CarBrand", attributes);
    }

    static public new CarBrand FromXElement(XElement element) {
      string name = element.Attribute("name").Value;
      Point location = element.Attribute("location").Value.ToPoint();
      Size size = element.Attribute("size").Value.ToSize();

      return new(name, location, size);
    }



    // ICloneable
    public object Clone() {
      CarBrand carBrand = (CarBrand) this.MemberwiseClone();

      carBrand.Name = this.Name;
      carBrand.Location = this.Location;
      carBrand.Size = this.Size;

      carBrand.Initialize(this.LayoutParent, this.ZoneParent, this.UseDatabaseAccess);

      return carBrand;
    }
  }
}
