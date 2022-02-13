using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

using Core.Settings;



namespace Core {
  public partial class Layout {
    static public partial class FileSystem {
      static public IEnumerable<string> GetFilesNames() {
        CreateDirectory();

        var paths = Directory.GetFiles(StaticSettings.LayoutsPath);

        return paths.Select(path =>
          Path.GetFileNameWithoutExtension(
            Path.GetFileName(path)
          )
        );
      }

      static public string ImportRaw(string name) {
        string path = GetPath(name);

        if (!Exists(path))
          return "";

        return File.ReadAllText(path);
      }

      static public Entity Import(string name) {
        string raw = ImportRaw(name);
        XDocument document = Common.Xml.Parse(raw);

        return Xml.FromDocument(document);
      }
    }
  }
}
