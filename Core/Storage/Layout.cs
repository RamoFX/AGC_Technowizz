using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;

using Core.Helpers;



namespace Core.Storage {
  public class Layout : XDocumentConvertable<Layout>, IStorageMember {
    // Main
    [Browsable(true)]
    [DisplayName("Název rozvržení")]
    public string Name { get; set; }

    [Browsable(true)]
    [DisplayName("Název skladu")]
    [Description("Musí se shodovat s názvem skladu nebo jiným identifikátorem v databázi, se kterou komunikuje.")]
    public string WarehouseName { get; set; }

    [Browsable(true)]
    [DisplayName("Vertikální kapacita")]
    public int VerticalCapacity { get; set; }

    public List<Zone> Zones;



    // IVisualizable
    [Browsable(false)]
    public Point Location {
      get => new(0, 0);
      set { } // Fuck the rules
    }

    [Browsable(true)]
    [DisplayName("Rozměry")]
    public Size Size { get; set; }

    [Browsable(false)]
    public Rectangle Rectangle {
      get => new(this.Location, this.Size);
    }

    [Browsable(false)]
    public Color Color {
      get => DynamicSettings.LayoutColor.Value.ToColor();
    }



    // Computations
    [Browsable(false)]
    public int MaxCapacity {
      get => this.Zones.Aggregate(0, (sum, zone) => sum + zone.MaxCapacity);
    }

    [Browsable(false)]
    public int PalletsCurrentlyStored {
      get => this.Zones.Aggregate(0, (sum, zone) => sum + zone.PalletsCurrentlyStored);
    }

    [Browsable(false)]
    public int PalletsCurrentlyStoredPercent {
      get => this.Zones.Aggregate(0, (sum, zone) => sum + zone.PalletsCurrentlyStoredPercent);
    }

    [Browsable(false)]
    public int PalletsCanBeStored {
      get => this.MaxCapacity - this.PalletsCurrentlyStored;
    }



    // Other
    private bool UseDatabaseAccess;



    // Constructors
    public Layout(string name, string warehouseName, Size size, int verticalCapacity, IEnumerable<Zone> zones) {
      this.Name = name;
      this.WarehouseName = warehouseName;
      this.Size = size;
      this.VerticalCapacity = verticalCapacity;
      this.Zones = zones.ToList();
    }

    public Layout(string name, string warehouseName, Size size, int verticalCapacity)
      : this(name, warehouseName, size, verticalCapacity, new Zone[0] {}) { }



    // Initializators
    public void Initialize(bool useDatabaseAccess) {
      this.UseDatabaseAccess = useDatabaseAccess;

      foreach (Zone zone in this.Zones) {
        zone.Initialize(this, this.UseDatabaseAccess);
      }
    }



    // Self interactions
    static public string GetPath(string name) {
      bool directoryExists = Directory.Exists(StaticSettings.LayoutsPath);

      if (!directoryExists) {
        Directory.CreateDirectory(StaticSettings.LayoutsPath);
      }

      return Path.Combine(
        StaticSettings.LayoutsPath,
        Path.ChangeExtension(name, "xml")
      );
    }

    public string GetPath() {
      return GetPath(this.Name);
    }

    public string LatestSaveHash() {
      if (this.HasValidCorrespondingFile()) {
        return Import(this.Name).ComputeHash();
      } else {
        return "";
      }
    }

    static public bool HasValidCorrespondingFile(string name) {
      bool isValid;

      try {
        Import(name);

        isValid = true;
      } catch {
        isValid = false;
      }

      return isValid;
    }

    public bool HasValidCorrespondingFile() {
      return HasValidCorrespondingFile(this.Name);
    }

    public bool IsCorrespondingFileUpToDate() {
      string hashSavedLayout = this.LatestSaveHash();
      string hashCurrentLayout = this.ComputeHash();

      return hashSavedLayout == hashCurrentLayout;
    }

    public string ComputeHash() {
      string documentString = this.ToXDocument().ToString(SaveOptions.DisableFormatting);
      byte[] documentBytes = Encoding.UTF8.GetBytes(documentString);
      using MD5 md5 = MD5.Create();
      byte[] hashRaw = md5.ComputeHash(documentBytes);

      return BitConverter.ToString(hashRaw).Replace("-", String.Empty);
    }



    // Zone interactions
    public Zone GetFirstSuitableZoneOrDefault(string carBrand) {
      return this.Zones.FirstOrDefault(zone => zone.IsLoadable(carBrand));
    }



    // File system interactions
    public void Move(string toName) {
      if (this.HasValidCorrespondingFile()) {
        File.Move(this.GetPath(), GetPath(toName));
      }
    }

    public void Rename(string newName) {
      string oldName = this.Name;

      // Check if file exists
      if (this.HasValidCorrespondingFile()) {
        // Can be older version
        Layout oldLayout = Layout.Import(oldName);
        oldLayout.Move(newName);
        oldLayout.Name = newName;
        oldLayout.Export();
      }

      // Rename
      this.Name = newName;
    }

    public void Delete() {
      if (this.HasValidCorrespondingFile()) {
        File.Delete(this.GetPath());
      }
    }

    public void Export() {
      XDocument document = this.ToXDocument();
      document.Save(this.GetPath());
    }

    public void ExportAs(string newName) {
      this.Name = newName;
      this.Export();
    }

    static public Layout Import(string name) {
      XDocument document = XDocument.Load(GetPath(name));

      return Layout.FromXDocument(document);
    }



    // XDocumentConvertable
    override public XDocument ToXDocument() {
      // Zones
      IEnumerable<XElement> zonesChildrenElements = this.Zones.Select(zone => zone.ToXElement());

      XElement zones = XmlLinqUtilities.CreateElement("Zones", zonesChildrenElements);

      // Root
      XAttribute[] rootAttributes = {
        new("name", this.Name),
        new("warehouseName", this.WarehouseName),
        new("size", this.Size.ToCustomString()),
        new("verticalCapacity", this.VerticalCapacity)
      };

      XElement root = XmlLinqUtilities.CreateElement("Layout", rootAttributes, zones);

      // Document
      XDocument document = new(root);

      return document;
    }

    static public new Layout FromXDocument(XDocument document) {
      XElement root = document.Root;

      string name = root.Attribute("name").Value;
      string warehouseName = root.Attribute("warehouseName").Value;
      Size size = root.Attribute("size").Value.ToSize();
      int verticalCapacity = root.Attribute("verticalCapacity").Value.ToInt();
      IEnumerable<Zone> zones = root.Element("Zones").Elements().Select(zone => Zone.FromXElement(zone));

      Layout layout = new(name, warehouseName, size, verticalCapacity, zones);

      return layout;
    }



    // ICloneable
    public object Clone() {
      Layout layout = (Layout) this.MemberwiseClone();

      layout.Name = this.Name;
      layout.WarehouseName = this.WarehouseName;
      layout.Location = this.Location; // Pointless since Layout's Location is always new Point(0, 0)
      layout.Size = this.Size;
      layout.VerticalCapacity = this.VerticalCapacity;
      layout.Zones = this.Zones;

      // Only non-cloned layout should be used for Communicator.DatabaseAccess communication
      layout.Initialize(false);

      return layout;
    }
  }
}
