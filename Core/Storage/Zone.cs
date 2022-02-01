using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using Core;
using Core.Storage.Utilities;
using Core.Helpers;



namespace Core.Storage {
  class Zone : XElementConvertable<Zone> {
    public string Name;
    public Point Location;
    public Size Size;
    public int VerticalCapacity;
    public List<string> CarBrands;
    public ZoneType Type;



    public int MaxCapacity { get => this.Size.Width * this.Size.Height; }
    public int PalletsLoaded = 0;
    public int PalletsCanBeStored { get => this.MaxCapacity - this.PalletsLoaded; }



    public Zone(string name, Point location, Size size, int verticalCapacity, IEnumerable<string> carBrands, ZoneType type) {
      this.Name = name;
      this.Location = location;
      this.Size = size;
      this.VerticalCapacity = verticalCapacity;
      this.CarBrands = carBrands.ToList();
      this.Type = type;
    }



    // XElementCompatible
    override public XElement ToXElement() {
      XAttribute[] attributes = {
        new("name", this.Name),
        new("location", this.Location.ToCustomString()),
        new("size", this.Size.ToCustomString()),
        new("verticalCapacity", this.VerticalCapacity.ToString()),
        new("type", this.Type.ToString())
      };

      XElement[] childrenElements = {
        new("name", this.Name),
        new("location", this.Location.ToCustomString()),
        new("size", this.Size.ToCustomString()),
        new("verticalCapacity", this.VerticalCapacity.ToString()),
        new("type", this.Type.ToString())
      };

      return XmlLinqUtilities.CreateElement("Zone", attributes, childrenElements);
    }

    static public new Zone FromXElement(XElement element) {
      string name = element.Element("Name").Value;
      Point location = element.Element("Location").Value.ToPoint();
      Size size = element.Element("Size").Value.ToSize();
      int verticalCapacity = element.Element("VerticalCapacity").Value.ToInt();
      ZoneType type = element.Element("Type").Value.ToZoneType(true);

      return new Zone(name, location, size, verticalCapacity, type);
    }
  }
}
