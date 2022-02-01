using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

using Core.Helpers;



namespace Core.Storage {
  class Zone : XElementConvertable<Zone> {
    public string Name;
    public Point Location;
    public Size Size;
    public int VerticalCapacity;
    public ZoneType Type;
    public List<string> CarBrands;



    public int MaxCapacity { get => this.Size.Width * this.Size.Height; }
    public int PalletsLoaded = 0;
    public int PalletsCanBeStored { get => this.MaxCapacity - this.PalletsLoaded; }



    public Zone(string name, Point location, Size size, int verticalCapacity, ZoneType type, IEnumerable<string> carBrands) {
      this.Name = name;
      this.Location = location;
      this.Size = size;
      this.VerticalCapacity = verticalCapacity;
      this.Type = type;
      this.CarBrands = carBrands.ToList();
    }



    // XElementConvertable
    override public XElement ToXElement() {
      XAttribute[] attributes = {
        new("name", this.Name),
        new("location", this.Location.ToCustomString()),
        new("size", this.Size.ToCustomString()),
        new("verticalCapacity", this.VerticalCapacity.ToString()),
        new("type", this.Type.ToString())
      };

      List<XElement> childrenElements = new();

      foreach (string carBrand in this.CarBrands) {
        var childrenElement = XmlLinqUtilities.CreateElement(
          "CarBrand",
          new XAttribute[] { new XAttribute("name", carBrand) }
        );

        childrenElements.Add(childrenElement);
      }

      return XmlLinqUtilities.CreateElement("Zone", attributes, childrenElements);
    }

    static public new Zone FromXElement(XElement element) {
      string name = element.Attribute("Name").Value;
      Point location = element.Attribute("Location").Value.ToPoint();
      Size size = element.Attribute("Size").Value.ToSize();
      int verticalCapacity = element.Attribute("VerticalCapacity").Value.ToInt();
      ZoneType type = element.Attribute("Type").Value.ToZoneType(true);
      IEnumerable<string> carBrads = element.Elements().Select( carBrandElement => carBrandElement.Attribute("name").Value );

      return new Zone(name, location, size, verticalCapacity, type, carBrads);
    }
  }
}
