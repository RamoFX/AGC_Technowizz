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
      bool directoryExists = Directory.Exists(Preferences.LayoutsPath);

      if (!directoryExists) {
        Directory.CreateDirectory(Preferences.LayoutsPath);
      }

      return Path.Combine(
        Preferences.LayoutsPath,
        Path.ChangeExtension(name, "xml")
      );
    }

    public string GetPath() {
      return GetPath(this.Name);
    }

    public string LatestSaveHash() {
      if (this.HasCorrespondingFile()) {
        return Import(this.Name).ComputeHash();
      } else {
        return "";
      }
    }

    public bool HasCorrespondingFile() {
      return File.Exists(this.GetPath());
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
    public IEnumerable<Zone> GetSuitableZones(string carBrand) {
      return this.Zones.FindAll(zone => zone.IsSuitable(carBrand));
    }



    // File system interactions
    public void Move(string toName) {
      if (this.HasCorrespondingFile()) {
        File.Move(this.GetPath(), GetPath(toName));
      }
    }

    public void Rename(string newName) {
      string oldName = this.Name;

      // Check if file exists
      if (this.HasCorrespondingFile()) {
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
      if (this.HasCorrespondingFile()) {
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
