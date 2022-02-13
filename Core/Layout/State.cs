using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace Core {
  static public partial class Layout {
    static public class State {
      static public bool IsValid(string name) {
        string raw = FileSystem.ImportRaw(name);
        return Xml.IsValid(raw);
      }

      static public bool AreEqual(Entity layout, XDocument document) {
        return Xml.ToString(layout) == Xml.ToString(document);
      }

      static public bool IsUpToDate(Entity layout) {
        bool exists = FileSystem.Exists(layout.Name);

        if (!exists)
          return false;

        string savedRaw = FileSystem.ImportRaw(layout.Name);
        var savedDocument = Common.Xml.Parse(savedRaw);

        return AreEqual(layout, savedDocument);
      }
    }
  }
}
