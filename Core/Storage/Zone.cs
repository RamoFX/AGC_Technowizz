using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using Communicator;
using Core.Extensions;
using Core.Helpers;



namespace Core.Storage {
  public class Zone : XElementConvertable<Zone> {
    [Browsable(true), DisplayName("Název")]
    public string Name { get; set; }



    [Browsable(true), DisplayName("Typ")]
    [Description("Storage - zóna určena pro uložení palet. Other - jiné využití plochy (např. zóna exportu nebo kancelář).")]
    public ZoneType Type { get; set; }



    [Browsable(true)]
    [DisplayName("Značka auta")]
    public string CarBrand { get; set; }



    [Browsable(true), DisplayName("Vertikální kapacita")]
    public int VerticalCapacity { get; set; }



    [Browsable(true), DisplayName("Rozměry")]
    public Size Size { get; set; }



    [Browsable(true), DisplayName("Souřadnice")]
    public Point Location { get; set; }



    [Browsable(false)]
    public Rectangle Rectangle {
      get => new(this.Location, this.Size);
    }

    [Browsable(false)]
    public Color Color {
      get {
        if (this.StoredPercent == 100) {
          return DynamicSettings.ZoneColor_Full.Value.ToColor();
        } else if (this.StoredPercent < 100 && this.StoredPercent >= 75) {
          return DynamicSettings.ZoneColor_AlmostFull.Value.ToColor();
        } else if (this.StoredPercent < 75 && this.StoredPercent >= 50) {
          return DynamicSettings.ZoneColor_AboveHalf.Value.ToColor();
        } else if (this.StoredPercent < 50 && this.StoredPercent >= 25) {
          return DynamicSettings.ZoneColor_BelowHalf.Value.ToColor();
        } else if (this.StoredPercent < 25 && this.StoredPercent > 0) {
          return DynamicSettings.ZoneColor_AlmostEmpty.Value.ToColor();
        } else {
          return DynamicSettings.ZoneColor_Empty.Value.ToColor();
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
    internal Layout Parent;

    [Browsable(false)]
    internal int DaysPeriod;



    // Constructors
    public Zone(string name, ZoneType type, int verticalCapacity, string carBrand, Size size, Point location) {
      if (name == default || type == default || verticalCapacity == default || carBrand == default || size == default || location == default) {
        throw new ArgumentNullException();
      }

      this.Name = name;
      this.Type = type;
      this.VerticalCapacity = verticalCapacity;
      this.CarBrand = carBrand;
      this.Location = location;
      this.Size = size;
    }



    // Initializators
    public void Initialize(Layout parent, int daysPeriod) {
      this.Parent = parent;
      this.DaysPeriod = daysPeriod;

      this.Stored = DatabaseAccess.GetPalletsCount(
        this.Parent.WarehouseName,
        this.Name,
        this.CarBrand,
        this.DaysPeriod
      );
    }



    // Self interaction
    public bool HasAvailableSpace() {
      return this.CanStore > 0;
    }

    private bool IsSuitable(string carBrand) {
      return this.CarBrand == carBrand;
    }

    public bool IsLoadable(string carBrandName) {
      if (!this.IsSuitable(carBrandName))
        return false;

      return this.CanStore > 0;
    }



    // XElementConvertable
    override public XElement ToXElement() {
      XAttribute[] attributes = {
        new("name", this.Name),
        new("type", this.Type.ToString()),
        new("verticalCapacity", this.VerticalCapacity.ToString()),
        new("carBrand", this.CarBrand),
        new("size", this.Size.ToCustomString()),
        new("location", this.Location.ToCustomString()),
      };

      return XmlLinqUtilities.CreateElement("Zone", attributes);
    }

    static public new Zone FromXElement(XElement element) {
      string name = element.Attribute("name")?.Value ?? default;
      ZoneType type = element.Attribute("type")?.Value.ToZoneType(true) ?? default;
      int verticalCapacity = element.Attribute("verticalCapacity")?.Value.ToInt() ?? default;
      string carBrand = element.Attribute("carBrand")?.Value ?? default;
      Size size = element.Attribute("size")?.Value.ToSize() ?? default;
      Point location = element.Attribute("location")?.Value.ToPoint() ?? default;

      Zone zone = new(name, type, verticalCapacity, carBrand, size, location);

      return zone;
    }
  }
}
