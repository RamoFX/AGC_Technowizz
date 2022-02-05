﻿using Communicator;
using Core.Helpers;
using Core.UI;
using System;
using System.Drawing;
using System.Xml.Linq;

namespace Core.Storage
{
  public class CarBrand : XElementConvertable<CarBrand> {
    // Main properties
    public string Name;
    public Point Location;
    public Size Size;



    // Other properties
    private Layout LayoutParent;
    private Zone ZoneParent;
    private bool UseDatabaseAccess = false;



    // Computation fields
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

    public int PalletsCanBeStored {
      get => this.MaxCapacity - this.PalletsCurrentlyStored;
    }

    public int PalletsCurrentlyStoredPercent {
      get => (int) Math.Round((decimal) this.PalletsCurrentlyStored / this.MaxCapacity * 100);
    }



    // Other fields
    public Color FillColor {
      get {
        if (this.PalletsCurrentlyStoredPercent == 100) {
          return Colors.FromStringToColor(DynamicSettings.CarBrandFillColor_Full.Value);
        } else if (this.PalletsCurrentlyStoredPercent < 100 && this.PalletsCurrentlyStoredPercent >= 75) {
          return Colors.FromStringToColor(DynamicSettings.CarBrandFillColor_AlmostFull.Value);
        } else if (this.PalletsCurrentlyStoredPercent < 75 && this.PalletsCurrentlyStoredPercent >= 50) {
          return Colors.FromStringToColor(DynamicSettings.CarBrandFillColor_AboveHalf.Value);
        } else if (this.PalletsCurrentlyStoredPercent < 50 && this.PalletsCurrentlyStoredPercent >= 25) {
          return Colors.FromStringToColor(DynamicSettings.CarBrandFillColor_BelowHalf.Value);
        } else if (this.PalletsCurrentlyStoredPercent < 25 && this.PalletsCurrentlyStoredPercent > 0) {
          return Colors.FromStringToColor(DynamicSettings.CarBrandFillColor_AlmostEmpty.Value);
        } else {
          return Colors.FromStringToColor(DynamicSettings.CarBrandFillColor_Empty.Value);
        }
      }
    }

    public readonly Color OutlineColor = Color.Cyan;



    // Constructors
    public CarBrand(string name, Point location, Size size) {
      this.Name = name;
      this.Location = location;
      this.Size = size;
    }

    public CarBrand(CarBrand from)
      : this(from.Name, from.Location, from.Size) { }



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
  }
}
