using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace Core.Storage {
  static public class LayoutManager {
    static public IEnumerable<string> GetExistingLayoutsPaths() {
      try {
        return Directory.GetFiles(Preferences.LayoutsPath);
      } catch (DirectoryNotFoundException) {
        return new string[0] {};
      }
    }

    static public IEnumerable<string> GetExistingLayoutsNames() {
      return GetExistingLayoutsPaths().Where(name => !name.EndsWith(".last")).Select(path => Path.GetFileNameWithoutExtension(Path.GetFileName(path)));
    }

    static public bool IsNameAlreadyTaken(string name) {
      return GetExistingLayoutsNames().Contains(name);
    }

    public static string GenerateNewLayoutUniqueName(string nameBase) {
      int nameCollisionPreventiveSuffix = 1;
      var existingLayoutsNames = GetExistingLayoutsNames();

      while (existingLayoutsNames.Contains($"{ nameBase }{ nameCollisionPreventiveSuffix }")) {
        nameCollisionPreventiveSuffix++;
      }

      return $"{ nameBase }{ nameCollisionPreventiveSuffix }";
    }
  }
}
