using Core.Helpers;
using Core.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace Core.Storage
{
  public class Layout : XDocumentConvertable<Layout> {
    // Main properties
    public string Name;
    public string WarehouseName;
    public Size Size;
    public int VerticalCapacity;
    public List<Zone> Zones;



    // Other properties
    private bool _UseDatabaseAccess = false;

    private bool UseDatabaseAccess {
      get => this._UseDatabaseAccess;
      set {
        this._UseDatabaseAccess = value;

        foreach (Zone zone in this.Zones) {
          zone.Initialize(this, this._UseDatabaseAccess);
        }
      }
    }



    // Computation fields
    public int MaxCapacity {
      get => this.Zones.Aggregate(0, (sum, zone) => sum + zone.MaxCapacity);
    }

    public int PalletsCurrentlyStored {
      get {
        if (this.UseDatabaseAccess) {
          return this.Zones.Aggregate(0, (sum, zone) => sum + zone.PalletsCurrentlyStored);
        } else {
          return 0;
        }
      }
    }

    public int PalletsCanBeStored {
      get => this.MaxCapacity - this.PalletsCurrentlyStored;
    }



    // Other fields
    public Color OutlineColor = Colors.FromStringToColor(DynamicSettings.LayoutOutlineColor.Value);
    public Color GridColor = Colors.FromStringToColor(DynamicSettings.LayoutGridColor.Value);



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

    public Layout(Layout from)
      : this(from.Name, from.WarehouseName, from.Size, from.VerticalCapacity, from.Zones) { }



    // Initializators
    public void Initialize(bool useDatabaseAccess) {
      this.UseDatabaseAccess = useDatabaseAccess;
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
  }
}
