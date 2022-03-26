using System.Collections.Generic;
using System.IO;
using System.Linq;

using Core.Settings;



namespace Core {
  public partial class Layout {
    static public partial class FileSystem {
      static public string GetPath(string name) {
        CreateDirectory();

        return Path.Combine(
          StaticSettings.LayoutsPath,
          Path.ChangeExtension(name, "xml")
        );
      }

      static public IEnumerable<string> GetValidNames() {
        return GetFilesNames().Where(State.IsValid);
      }

      static public bool Exists(string name) {
        string path = GetPath(name);
        return File.Exists(path);
      }
    }
  }
}
