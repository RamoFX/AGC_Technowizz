using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using Core.Extensions;
using Core.Helpers;



namespace Core.Storage {
  public class Zone : XElementConvertable<Zone>, IStorageMember {
    // Main
    [Browsable(true)]
    [DisplayName("Název")]
    public string Name { get; set; }

    [Browsable(true)]
    [DisplayName("Typ")]
    [Description("Storage - zóna určena pro uložení palet. Other - jiné využití zóny (např. zóna exportu).")]
    public ZoneType Type { get; set; }

    [Browsable(false)]
    public List<CarBrand> CarBrands;



    // IVisualizable
    [Browsable(true)]
    [DisplayName("Souřadnice")]
    public Point Location { get; set; }

    [Browsable(true)]
    [DisplayName("Rozměry")]
    public Size Size { get; set; }

    [Browsable(false)]
    public Rectangle Rectangle {
      get => new(this.Location, this.Size);
    }

    [Browsable(false)]
    public Color Color {
      get {
        if (this.Type == ZoneType.Storage) {
          return DynamicSettings.ZoneColor_Storage.Value.ToColor();
        } else {
          return DynamicSettings.ZoneColor_Other.Value.ToColor();
        }
      }
    }



    // Computations
    [Browsable(false)]
    public int MaxCapacity {
      get => this.CarBrands.Sum(carBrand => carBrand.MaxCapacity);
    }

    [Browsable(false)]
    public int PalletsCurrentlyStored {
      get => this.CarBrands.Sum(carBrand => carBrand.PalletsCurrentlyStored);
    }

    [Browsable(false)]
    public int PalletsCurrentlyStoredPercent {
      get {
        if (this.CarBrands.Count == 0)
          return 0;

        double average = this.CarBrands.Average(carBrand => carBrand.PalletsCurrentlyStoredPercent);

        return (int) Math.Round(average);
      }
    }

    [Browsable(false)]
    public int PalletsCanBeStored {
      get => this.MaxCapacity - this.PalletsCurrentlyStored;
    }



    // Other
    private Layout LayoutParent;
    private bool UseDatabaseAccess;



    // Constructors
    public Zone(string name, Point location, Size size, ZoneType type, IEnumerable<CarBrand> carBrands) {
      this.Name = name;
      this.Location = location;
      this.Size = size;
      this.Type = type;
      this.CarBrands = carBrands.ToList();
    }

    public Zone(string name, Point location, Size size, ZoneType type)
      : this(name, location, size, type, new CarBrand[0] { }) { }



    // Initializators
    public void Initialize(Layout layoutParent, bool useDatabaseAccess) {
      this.LayoutParent = layoutParent;
      this.UseDatabaseAccess = useDatabaseAccess;

      foreach (CarBrand carBrand in this.CarBrands) {
        carBrand.Initialize(this.LayoutParent, this, this.UseDatabaseAccess);
      }
    }



    // Self interaction
    public CarBrand GetCarBrand(string name) {
      return this.CarBrands.FirstOrDefault(carBrand => carBrand.Name == name);
    }



    // CarBrand interaction
    private bool IsSuitable(string carBrandName) {
      return this.GetCarBrand(carBrandName) != default;
    }

    public bool IsLoadable(string carBrandName) {
      if (this.IsSuitable(carBrandName)) {
        return this.GetCarBrand(carBrandName).PalletsCanBeStored > 0;
      } else {
        return false;
      }
    }



    // XElementConvertable
    override public XElement ToXElement() {
      IEnumerable<XElement> zoneChildrenElements = this.CarBrands.Select(carBrand => carBrand.ToXElement());

      XAttribute[] attributes = {
        new("name", this.Name),
        new("location", this.Location.ToCustomString()),
        new("size", this.Size.ToCustomString()),
        new("type", this.Type.ToString())
      };

      return XmlLinqUtilities.CreateElement("Zone", attributes, zoneChildrenElements);
    }

    static public new Zone FromXElement(XElement element) {
      string name = element.Attribute("name").Value;
      Point location = element.Attribute("location").Value.ToPoint();
      Size size = element.Attribute("size").Value.ToSize();
      ZoneType type = element.Attribute("type").Value.ToZoneType(true);
      IEnumerable<CarBrand> carBrads = element.Elements().Select( carBrandElement => CarBrand.FromXElement(carBrandElement));

      return new Zone(name, location, size, type, carBrads);
    }



    // ICloneable
    public object Clone() {
      Zone zone = (Zone) this.MemberwiseClone();

      zone.Name = this.Name;
      zone.Location = this.Location;
      zone.Size = this.Size;
      zone.Type = this.Type;
      zone.CarBrands = this.CarBrands;

      zone.Initialize(this.LayoutParent, this.UseDatabaseAccess);

      return zone;
    }
  }
}
