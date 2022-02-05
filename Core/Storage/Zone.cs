using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

using Core.Communicator;
using Core.Helpers;



namespace Core.Storage {
  public class Zone : XElementConvertable<Zone> {
    // References
    public Layout LayoutParent;



    // Main properties
    public string Name;
    public Point Location;
    public Size Size;
    public ZoneType Type;
    public List<CarBrand> CarBrands;



    // Computation fields
    public int MaxCapacity {
      get => this.CarBrands.Aggregate(0, (sum, carBrand) => sum + carBrand.MaxCapacity);
    }

    public int PalletsCurrentlyStored {
      get => this.CarBrands.Aggregate(0, (sum, carBrand) => sum + carBrand.PalletsCurrentlyStored);
    }

    public int PalletsCanBeStored {
      get => this.MaxCapacity - this.PalletsCurrentlyStored;
    }



    // Constructors
    public Zone(string name, Point location, Size size, ZoneType type, IEnumerable<CarBrand> carBrands) {
      this.Name = name;
      this.Location = location;
      this.Size = size;
      this.Type = type;
      this.CarBrands = carBrands.ToList();
    }

    public Zone(string name, Point location, Size size, ZoneType type) : this(name, location, size, type, new CarBrand[0] { }) { }

    public Zone(Zone from) : this(from.Name, from.Location, from.Size, from.Type, from.CarBrands) { }



    // Initializators
    public void InitializeLayoutParent(Layout layout) {
      this.LayoutParent = layout;
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
  }
}
