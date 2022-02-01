using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using Core.Helpers;
using Core.Storage;



namespace Core {
  class Program {
    // Use for development testing or debugging, won't be used as entrypoint
    static void Main() {
      //CreateExampleXml();
    }

    static void CreateExampleXml() {
      XDocument document = new();

      // Brands
      XElement brand1 = new("Brand");
      brand1.SetAttributeValue("name", "toy");

      XElement brand2 = new("Brand");
      brand2.SetAttributeValue("name", "ms");

      XElement brand3 = new("Brand");
      brand3.SetAttributeValue("name", "bmw");

      // Layout
      XElement layout = new("Layout");
      layout.SetAttributeValue("name", "example");
      layout.SetAttributeValue("size", "16,9");

      // Zones
      XElement zones = new("Zones");

      // Zone1
      XElement zone1 = new("Zone");
      zone1.SetAttributeValue("name", "A1");
      zone1.SetAttributeValue("size", "4,3");

      // Zone2
      XElement zone2 = new("Zone");
      zone2.SetAttributeValue("name", "B1");
      zone2.SetAttributeValue("size", "3,4");

      // Zone1, Zone2
      XElement[] zone1_zone2 = new XElement[2] { zone1, zone2 };

      // Add to the XML DOM
      document.Add(layout);
      layout.Add(zones);
      zones.Add(zone1_zone2);
      zone1.Add(brand1, brand3);
      zone2.Add(brand2);

      // Save
      document.Save("./example.xml");
    }
  }
}
