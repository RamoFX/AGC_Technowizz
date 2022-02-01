using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace Core.Helpers {
  static class XmlLinqUtilities {
    static public XElement CreateElement(XName name, IEnumerable<XAttribute> attributes, IEnumerable<XElement> childrenElements) {
      var element = new XElement(name);

      // Adding attributes
      if (attributes != null) {
        foreach (var attribute in attributes) {
          element.SetAttributeValue(attribute.Name, attribute.Value);
        }
      }

      // Adding children elements
      if (childrenElements != null) {
        element.Add(childrenElements);
      }

      return element;
    }

    static public XElement CreateElement(XName name, IEnumerable<XAttribute> attributes) {
      return CreateElement(name, attributes, null);
    }

    static public XElement CreateElement(XName name, IEnumerable<XElement> childrenElements) {
      return CreateElement(name, null, childrenElements);
    }
  }
}
