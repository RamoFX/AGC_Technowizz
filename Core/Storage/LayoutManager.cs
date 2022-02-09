using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace Core.Storage {
  static public class LayoutManager {
    static public void EnsureLayoutDirectory() {
      string path = StaticSettings.LayoutsPath;

      if (!Directory.Exists(path)) {
        Directory.CreateDirectory(path);
      }
    }

    static public IEnumerable<string> GetExistingLayoutPaths() {
      EnsureLayoutDirectory();

      return Directory.GetFiles(StaticSettings.LayoutsPath);
    }

    static public IEnumerable<string> GetExistingLayoutNames() {
      return GetExistingLayoutPaths().Select(path =>
        Path.GetFileNameWithoutExtension(
          Path.GetFileName(path)
        )
      );
    }

    static public IEnumerable<string> GetValidLayoutNames() {
      foreach (string layoutName in GetExistingLayoutNames())
        if (Layout.HasValidCorrespondingFile(layoutName))
          yield return layoutName;
    }

    static public bool IsNameAlreadyTaken(string name) {
      return GetExistingLayoutNames().Contains(name);
    }
  }
}
