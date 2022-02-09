using System;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Linq;

using Communicator;
using Core.Extensions;
using Core.Helpers;



namespace Core.Storage {
  public class CarBrand : XElementConvertable<CarBrand> {
    [Browsable(true)]
    [DisplayName("Značka auta")]
    public string Name { get; set; }



    [Browsable(true), DisplayName("Relativní souřadnice")]
    [Description("Souřadnice vůči dané zóně.")]
    public Point Location { get; set; }



    [Browsable(true), DisplayName("Rozměry")]
    public Size Size { get; set; }



    [Browsable(true), DisplayName("Vertikální kapacita")]
    public int VerticalCapacity { get; set; }



    [Browsable(false)]
    public Rectangle Rectangle {
      get => new(this.Location, this.Size);
    }

    [Browsable(false)]
    public Color Color {
      get {
        if (this.StoredPercent == 100) {
          return DynamicSettings.CarBrandColor_Full.Value.ToColor();
        } else if (this.StoredPercent < 100 && this.StoredPercent >= 75) {
          return DynamicSettings.CarBrandColor_AlmostFull.Value.ToColor();
        } else if (this.StoredPercent < 75 && this.StoredPercent >= 50) {
          return DynamicSettings.CarBrandColor_AboveHalf.Value.ToColor();
        } else if (this.StoredPercent < 50 && this.StoredPercent >= 25) {
          return DynamicSettings.CarBrandColor_BelowHalf.Value.ToColor();
        } else if (this.StoredPercent < 25 && this.StoredPercent > 0) {
          return DynamicSettings.CarBrandColor_AlmostEmpty.Value.ToColor();
        } else {
          return DynamicSettings.CarBrandColor_Empty.Value.ToColor();
        }
      }
    }



    // Data
    [Browsable(false)]
    public int Area {
      get => this.Size.Width * this.Size.Height;
    }

    [Browsable(false)]
    public int MaxCapacity {
      get => this.Area * this.VerticalCapacity;
    }

    [Browsable(false)]
    public int Stored;

    [Browsable(false)]
    public int StoredPercent {
      get => (int) Math.Round((decimal) this.Stored / this.MaxCapacity * 100);
    }

    [Browsable(false)]
    public int CanStore {
      get => this.MaxCapacity - this.Stored;
    }



    // References
    [Browsable(false)]
    internal Zone Parent;



    // Constructors
    public CarBrand(string name, Point location, Size size, int verticalCapacity) {
      this.Name = name;
      this.Location = location;
      this.Size = size;
      this.VerticalCapacity = verticalCapacity;
    }



    // Initializators
    public void Initialize(Zone parent) {
      this.Parent = parent;

      string zoneName = this.Parent.Name;

      Layout layout = this.Parent.Parent;
      string warehouseName = layout.WarehouseName;
      int daysPeriod = layout.DaysPeriod;

      this.Stored = DatabaseAccess.GetPalletsCount(warehouseName, zoneName, this.Name, daysPeriod);
    }



    // Self interaction
    public bool HasAvailableSpace() {
      return this.CanStore > 0;
    }



    // XElementConvertable
    override public XElement ToXElement() {
      XAttribute[] attributes = {
        new("name", this.Name),
        new("location", this.Location.ToCustomString()),
        new("size", this.Size.ToCustomString()),
        new("verticalCapacity", this.VerticalCapacity.ToString())
      };

      return XmlLinqUtilities.CreateElement("CarBrand", attributes);
    }

    static public new CarBrand FromXElement(XElement element) {
      string name = element.Attribute("name").Value;
      Point location = element.Attribute("location").Value.ToPoint();
      Size size = element.Attribute("size").Value.ToSize();
      int verticalCapacity = element.Attribute("verticalCapacity").Value.ToInt();

      return new(name, location, size, verticalCapacity);
    }
  }
}
