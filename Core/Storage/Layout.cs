using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

using Core.Helpers;
using Core.Storage.Utilities;



namespace Core.Storage {
  class Layout : XDocumentConvertable<Layout> {
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



    // XDocumentCompatible
    override public XDocument ToXDocument() {
      XElement[] elements = new XElement[3] {
        new("Name", this.Name),
        new("Size", this.Size.ToCustomString()),
        new("Zones", this.Zones.Select(zone => zone.ToXElement()))
      };

      XElement rootElement = new("Layout", elements);

      XDocument document = new(rootElement);

      return document;
    }

    static public new Layout FromXDocument(XDocument document) {
      XElement root = document.Root;

      string name = root.Element("Name").Value;
      Size size = root.Element("Size").Value.ToSize();
      IEnumerable<Zone> zones = root.Element("Zones").Elements().Select(xElementZone => Zone.FromXElement(xElementZone));

      return new Layout(name, size, zones);
    }
  }
}
 