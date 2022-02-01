using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

using Core.Helpers;



namespace Core.Storage {
  public class Layout : XDocumentConvertable<Layout> {
    public string Name;
    public Size Size;
    public List<Zone> Zones;



    public int MaxCapacity { get => this.Zones.Aggregate(0, (sum, zone) => sum + zone.MaxCapacity); }
    public int PalletsLoaded { get => this.Zones.Aggregate(0, (sum, zone) => sum + zone.PalletsLoaded); }
    public int PalletsCanBeStored { get => this.MaxCapacity - this.PalletsLoaded; }



    public Layout(string name, Size size, IEnumerable<Zone> zones) {
      this.Name = name;
      this.Size = size;
      this.Zones = zones.ToList();
    }

    public Layout(string name, Size size) : this(name, size, new Zone[0] {}) { }



    static public string GetPath(string name) {
      return Paths.JoinPaths(
        Preferences.LayoutsPath,
        Paths.ApplyFileExtension(name, "xml")
      );
    }

    public string GetPath() {
      return GetPath(this.Name);
    }



    public void RemoveZone(string name) {
      Zone zone = this.Zones.Find(zone => zone.Name == name);

      if (zone == null) {
        throw new ArgumentException($"Layout.Zones doesn't contain a Zone with name \"{ name }\"");
      } else {
        this.Zones.Remove(zone);
      }
    }

    public IEnumerable<string> GetCarBrandSuitableZonesNames(string carBrand) {
      List<string> suitableZonesNames = new();

      foreach(Zone zone in this.Zones) {
        if (zone.IsCarBrandSuitable(carBrand)) {
          suitableZonesNames.Add(zone.Name);
        }
      }

      return suitableZonesNames;
    }



    public bool Export() {
      bool didExportedSuccessfuly;

      try {
        XDocument document = this.ToXDocument();
        document.Save(this.GetPath()); // Where goes the saved file?

        didExportedSuccessfuly = true;
      } catch {
        didExportedSuccessfuly = false;
      }

      return didExportedSuccessfuly;
    }

    static public Layout Import(string name) { 
      string path = GetPath(name);
      XDocument document = XDocument.Load(path);

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
        new("size", this.Size.ToCustomString())
      };

      XElement root = XmlLinqUtilities.CreateElement("Layout", rootAttributes, new XElement[] { zones });

      // Document
      XDocument document = new(root);

      return document;
    }

    static public new Layout FromXDocument(XDocument document) {
      XElement root = document.Root;

      string name = root.Attribute("name").Value;
      Size size = root.Attribute("size").Value.ToSize();
      IEnumerable<Zone> zones = root.Element("Zones").Elements().Select(zone => Zone.FromXElement(zone));

      return new Layout(name, size, zones);
    }
  }
}
