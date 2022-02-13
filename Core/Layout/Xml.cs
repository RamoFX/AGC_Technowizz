using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;

using Core.Extensions;
using Core.Settings;



namespace Core {
  public partial class Layout {
    static internal class Xml {
      static internal readonly XmlSchema Schema = Common.Xml.ImportSchema(StaticSettings.LayoutSchemaName);

      static public bool IsValid(string raw) {
        return Common.Xml.IsValid(raw, Schema);
      }

      static public XDocument ToDocument(Entity layout) {
        // Zones
        var zonesChildrenElements = Zone.Xml.ToElements(layout.Zones);
        var zones = Common.Xml.CreateElement("Zones", zonesChildrenElements);

        // Root
        XAttribute[] rootAttributes = {
        new("name", layout.Name),
        new("warehouse-name", layout.WarehouseName),
        new("size", layout.Size.ToCustomString()),
      };

        var root = Common.Xml.CreateElement("Layout", rootAttributes, zones);

        // Document
        var document = new XDocument(root);

        return document;
      }

      static public Entity FromDocument(XDocument document) {
        var root = document.Root;

        var name = root.Attribute("name").Value;
        var warehouseName = root.Attribute("warehouse-name").Value;
        var size = root.Attribute("size").Value.ToSize();
        var zones = Zone.Xml.FromElements(root.Element("Zones").Elements());

        var layout = new Entity(name, warehouseName, size, zones);

        return layout;
      }

      static public string ToString(XDocument document) {
        return document.ToString(SaveOptions.DisableFormatting);
      }

      static public string ToString(Entity layout) {
        return ToString(ToDocument(layout));
      }
    }
  }
}
