using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace Core.Storage {
  static public class LayoutManager {
    static public IEnumerable<string> GetExistingLayoutsPaths() {
      try {
        return Directory.GetFiles(Preferences.LayoutsPath);
      } catch (DirectoryNotFoundException) {
        return new string[] {};
      }
    }

    static public IEnumerable<string> GetExistingLayoutsNames() {
      return GetExistingLayoutsPaths().Select(path => Path.GetFileNameWithoutExtension(Path.GetFileName(path)));
    }

    static bool IsNameAlreadyTaken(string name) {
      return GetExistingLayoutsNames().Contains(name);
    }
  }
}
