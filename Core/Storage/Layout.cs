using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

using Core.Helpers;



namespace Core.Storage {
  public class Layout : XDocumentConvertable<Layout> {
    public string Name;
    public Size Size;
    public List<Zone> Zones;



    public int MaxCapacity { get => this.Zones.Aggregate(0, (sum, zone) => sum + zone.MaxCapacity); }
    public int PalletsCurrentlyStored { get => this.Zones.Aggregate(0, (sum, zone) => sum + zone.PalletsCurrentlyStored); }
    public int PalletsCanBeStored { get => this.MaxCapacity - this.PalletsCurrentlyStored; }



    public Layout(string name, Size size, IEnumerable<Zone> zones) {
      this.Name = name;
      this.Size = size;
      this.Zones = zones.ToList();
    }

    public Layout(string name, Size size) : this(name, size, new Zone[0] {}) { }

    public Layout(Layout from) : this(from.Name, from.Size, from.Zones) { }



    // Self interactions
    static public string GetPath(string name) {
      return Path.Combine(
        Preferences.LayoutsPath,
        Path.ChangeExtension(name, "xml")
      );
    }

    public string GetPath() {
      return GetPath(this.Name);
    }

    public string LatestSaveHash() {
      try {
        return Layout.Import(this.Name).ComputeHash();
      } catch (FileNotFoundException) {
        return "";
      }
    }
    
    public bool IsSaved() {
      return LayoutManager.GetExistingLayoutsNames().Contains(this.Name);
    }

    public bool IsSaveUpToDate() {
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
    public IEnumerable<Zone> GetSuitableZones(string carBrand) {
      return this.Zones.FindAll(zone => zone.IsSuitable(carBrand));
    }



    // IO interactions
    public bool Export() {
      bool didExportedSuccessfuly;

      try {
        if (!Directory.Exists(Preferences.LayoutsPath)) {
          Directory.CreateDirectory(Preferences.LayoutsPath);
        }

        XDocument document = this.ToXDocument();
        document.Save(this.GetPath());

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
