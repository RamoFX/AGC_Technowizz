using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using Core.Communicator;
using Core.Helpers;



namespace Core.Storage {
  public class CarBrand : XElementConvertable<CarBrand> {
    // References
    public Zone ZoneParent;



    // Main properties
    public string Name;
    public Point Location;
    public Size Size;



    // Computation fields
    public int MaxCapacity {
      get => this.Size.Width * this.Size.Height * this.ZoneParent.LayoutParent.VerticalCapacity;
    }

    public int PalletsCurrentlyStored {
      get => DatabaseAccess.GetZonePalletsCount(this.ZoneParent.LayoutParent.WarehouseName, this.ZoneParent.Name, this.Name);
    }

    public int PalletsCanBeStored {
      get => this.MaxCapacity - this.PalletsCurrentlyStored;
    }



    // Constructors
    public CarBrand(string name, Point location, Size size) {
      this.Name = name;
      this.Location = location;
      this.Size = size;
    }

    public CarBrand(CarBrand from) : this(from.Name, from.Location, from.Size) { }



    // Initializators
    public void InitZoneParent(Zone zone) {
      this.ZoneParent = zone;
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
  }
}
