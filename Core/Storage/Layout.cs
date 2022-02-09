using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Xml.Linq;
using Core.Extensions;
using Core.Helpers;



namespace Core.Storage {
  public class Layout : XDocumentConvertable<Layout>, IEnumerable<Zone> {
    [Browsable(true), DisplayName("Název rozvržení")]
    public string Name { get; set; }



    [Browsable(true), DisplayName("Název skladu")]
    [Description("Musí se shodovat s názvem skladu nebo jiným identifikátorem v databázi, se kterou komunikuje.")]
    public string WarehouseName { get; set; }



    [Browsable(true), DisplayName("Rozměry")]
    public Size Size { get; set; }



    [Browsable(false)]
    public readonly Point Location = new(0, 0);

    [Browsable(false)]
    public Rectangle Rectangle {
      get => new(this.Location, this.Size);
    }

    [Browsable(false)]
    public readonly Color Color = DynamicSettings.NeutralColor_Dark.Value.ToColor();

    [Browsable(false)]
    public readonly List<Zone> Zones;



    // Data
    [Browsable(false)]
    public int Area {
      get => this.Size.Width * this.Size.Height;
    }

    [Browsable(false)]
    public int Area_Zones {
      get => this.Sum(zone => zone.Area);
    }

    [Browsable(false)]
    public int MaxCapacity {
      get => this.Sum(zone => zone.MaxCapacity);
    }

    [Browsable(false)]
    public int Stored {
      get => this.Sum(zone => zone.Stored);
    }

    [Browsable(false)]
    public int StoredPercent {
      get {
        if (this.Zones.Count == 0)
          return 0;

        double average = this.Average(carBrand => carBrand.StoredPercent);

        return (int) Math.Round(average);
      }
    }

    [Browsable(false)]
    public int CanStore {
      get => this.Sum(zone => zone.CanStore);
    }



    // Indexer
    public Zone this[int index] {
      get => this.Zones[index];
    }



    // References
    [Browsable(false)]
    internal int DaysPeriod;



    // Constructors
    public Layout(string name, string warehouseName, Size size, IEnumerable<Zone> zones) {
      this.Name = name;
      this.WarehouseName = warehouseName;
      this.Size = size;
      this.Zones = zones.ToList();
    }

    public Layout(string name, string warehouseName, Size size)
      : this(name, warehouseName, size, new Zone[0] {}) { }



    // Initializators
    public void Initialize(int daysPeriod) {
      this.DaysPeriod = daysPeriod;
      
      foreach (Zone zone in this) {
        zone.Initialize(this);
      }
    }



    // Self interactions
    public void Add(Zone zone) {
      zone.Initialize(this);
      this.Zones.Add(zone);
    }

    static public string GetPath(string name) {
      LayoutManager.EnsureLayoutDirectory();

      return Path.Combine(
        StaticSettings.LayoutsPath,
        Path.ChangeExtension(name, "xml")
      );
    }

    public string GetPath() {
      return GetPath(this.Name);
    }

    public string LatestSaveHash() {
      if (!this.HasValidCorrespondingFile())
        return "";

      return Import(this.Name).ComputeHash();
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
      IEnumerable<Zone> zones = root.Element("Zones").Elements().Select(zone => Zone.FromXElement(zone));

      Layout layout = new(name, warehouseName, size, zones);

      return layout;
    }



    // IEnumerable
    public IEnumerator<Zone> GetEnumerator() {
      foreach (Zone zone in this.Zones) {
        yield return zone;
      }
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return this.GetEnumerator();
    }
  }
}
