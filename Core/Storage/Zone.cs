using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using Core.Extensions;
using Core.Helpers;



namespace Core.Storage {
  public class Zone : XElementConvertable<Zone>, IEnumerable<CarBrand> {
    [Browsable(true), DisplayName("Název")]
    public string Name { get; set; }



    [Browsable(true), DisplayName("Typ")]
    [Description("Storage - zóna určena pro uložení palet. Other - jiné využití zóny (např. zóna exportu).")]
    public ZoneType Type { get; set; }



    [Browsable(true), DisplayName("Souřadnice")]
    public Point Location { get; set; }



    [Browsable(true), DisplayName("Rozměry")]
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

    [Browsable(false)]
    public List<CarBrand> CarBrands;



    // Data
    [Browsable(false)]
    public int Area {
      get => this.Size.Width * this.Size.Height;
    }

    [Browsable(false)]
    public int Area_CarBrands {
      get => this.Sum(carBrand => carBrand.Area);
    }

    [Browsable(false)]
    public int MaxCapacity {
      get => this.Sum(carBrand => carBrand.MaxCapacity);
    }

    [Browsable(false)]
    public int Stored {
      get => this.Sum(carBrand => carBrand.Stored);
    }

    [Browsable(false)]
    public int StoredPercent {
      get {
        if (this.Count() == 0)
          return 0;

        double average = this.Average(carBrand => carBrand.StoredPercent);

        return (int) Math.Round(average);
      }
    }

    [Browsable(false)]
    public int CanStore {
      get => this.Sum(carBrand => carBrand.CanStore);
    }



    // Indexer
    public CarBrand this[int index] {
      get => this.CarBrands[index];
    }



    // References
    [Browsable(false)]
    internal Layout Parent;



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
    public void Initialize(Layout parent) {
      this.Parent = parent;

      foreach (CarBrand carBrand in this) {
        carBrand.Initialize(this);
      }
    }



    // Self interaction
    public void Add(CarBrand carBrand) {
      carBrand.Initialize(this);
      this.CarBrands.Add(carBrand);
    }

    public CarBrand GetCarBrandOrDefault(string name) {
      return this.CarBrands.FirstOrDefault(carBrand => carBrand.Name == name);
    }



    // CarBrand interaction
    private bool IsSuitable(string carBrandName) {
      return this.GetCarBrandOrDefault(carBrandName) != default;
    }

    public bool IsLoadable(string carBrandName) {
      if (!this.IsSuitable(carBrandName))
        return false;

      return this.GetCarBrandOrDefault(carBrandName).CanStore > 0;
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



    // IEnumerable
    public IEnumerator<CarBrand> GetEnumerator() {
      foreach (CarBrand carBrand in this.CarBrands) {
        yield return carBrand;
      }
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return this.GetEnumerator();
    }
  }
}
