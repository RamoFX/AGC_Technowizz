using System.Collections.Generic;
using System.Xml.Linq;



namespace Core.Helpers {
  static class XmlLinqUtilities {
    static public XElement CreateElement(XName name, IEnumerable<XAttribute> attributes, IEnumerable<XElement> childrenElements) {
      var element = new XElement(name);

      // Adding attributes
      foreach (var attribute in attributes) {
        element.SetAttributeValue(attribute.Name, attribute.Value);
      }

      // Adding children elements
      element.Add(childrenElements);

      return element;
    }

    static public XElement CreateElement(XName name, XAttribute attribute, IEnumerable<XElement> childrenElements) {
      return CreateElement(name, new XAttribute[1] { attribute }, childrenElements);
    }

    static public XElement CreateElement(XName name, IEnumerable<XAttribute> attributes, XElement childrenElement) {
      return CreateElement(name, attributes, new XElement[1] { childrenElement });
    }

    static public XElement CreateElement(XName name, XAttribute attribute, XElement childrenElement) {
      return CreateElement(name, new XAttribute[1] { attribute }, new XElement[1] { childrenElement });
    }

    static public XElement CreateElement(XName name, IEnumerable<XAttribute> attributes) {
      return CreateElement(name, attributes, new XElement[0] { });
    }

    static public XElement CreateElement(XName name, XAttribute attribute) {
      return CreateElement(name, new XAttribute[1] { attribute });
    }

    static public XElement CreateElement(XName name, IEnumerable<XElement> childrenElements) {
      return CreateElement(name, new XAttribute[0] { }, childrenElements);
    }

    static public XElement CreateElement(XName name, XElement childrenElement) {
      return CreateElement(name, new XElement[1] { childrenElement });
    }

    static public XElement CreateElement(XName name) {
      return CreateElement(name, new XAttribute[0] { }, new XElement[0] { });
    }
  }
}
