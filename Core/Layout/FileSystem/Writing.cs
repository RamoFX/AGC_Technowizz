using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using Core.Settings;



namespace Core {
  public partial class Layout {
    static public partial class FileSystem {
      static internal void CreateDirectory() {
        string path = StaticSettings.LayoutsPath;

        if (!Directory.Exists(path)) {
          Directory.CreateDirectory(path);
        }
      }

      static public void Export(Entity layout) {
        XDocument document = Xml.ToDocument(layout);
        string path = GetPath(layout.Name);
        document.Save(path);
      }

      static public void ExportAs(Entity layout, string newName) {
        layout.Name = newName;
        Export(layout);
      }
    }
  }
}
