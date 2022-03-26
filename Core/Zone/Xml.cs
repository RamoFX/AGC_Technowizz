using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;



namespace Core {
  public partial class Zone {
    static internal class Xml {
      static public XElement ToElement(Entity zone) {
        XAttribute[] attributes = {
          new("name", zone.Name),
          new("vertical-capacity", zone.VerticalCapacity.ToString()),
          new("car-brand", zone.CarBrand),
          new("size", zone.Size.ToCustomString()),
          new("location", zone.Location.ToCustomString()),
        };

        var element = Common.Xml.CreateElement("Zone", attributes);

        return element;
      }

      static public IEnumerable<XElement> ToElements(IEnumerable<Entity> zones) {
        foreach (Entity zone in zones)
          yield return ToElement(zone);
      }

      static public Entity FromElement(XElement element) {
        string name = element.Attribute("name").Value;
        int verticalCapacity = element.Attribute("vertical-capacity").Value.ToInt();
        string carBrand = element.Attribute("car-brand").Value;
        Size size = element.Attribute("size").Value.ToSize();
        Point location = element.Attribute("location").Value.ToPoint();

        Entity zone = new(name, verticalCapacity, carBrand, size, location);

        return zone;
      }

      static public IEnumerable<Entity> FromElements(IEnumerable<XElement> elements) {
        foreach (var element in elements)
          yield return FromElement(element);
      }
    }
  }
}
