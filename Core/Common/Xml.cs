using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;



namespace Core {
  internal partial class Common {
    internal class Xml {
      static public XmlSchema ImportSchema(string path) {
        string schemaRaw = File.ReadAllText(path);
        var stringReader = new StringReader(schemaRaw);
        var schema = XmlSchema.Read(stringReader, (s, e) => throw e.Exception);

        return schema;
      }

      static public XDocument Parse(string raw) {
        return XDocument.Parse(raw);
      }

      static public bool IsValid(XDocument document, XmlSchema schema) {
        XmlSchemaSet xmlSchemaSet = new();
        xmlSchemaSet.Add(schema);

        List<string> warnings = new();
        List<string> errors = new();

        document.Validate(xmlSchemaSet, (sender, e) => {
          if (e.Severity == XmlSeverityType.Warning) {
            warnings.Add(e.Message);
          } else if (e.Severity == XmlSeverityType.Error) {
            errors.Add(e.Message);
          }
        });

        foreach (string warning in warnings) {
          Console.WriteLine($"Warning (XML Validator): { warning }");
        }

        foreach (string error in errors) {
          Console.WriteLine($"Error (XML Validator): { error }");
        }

        return warnings.Count == 0 && errors.Count == 0;
      }

      static public bool IsValid(string rawDocument, XmlSchema schema) {
        try {
          var document = Parse(rawDocument);
          return IsValid(document, schema);
        } catch {
          return false;
        }
      }

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
}
