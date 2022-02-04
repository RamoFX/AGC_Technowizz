using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace Core.Storage {
  static public class LayoutManager {
    static public IEnumerable<string> GetExistingLayoutPaths() {
      try {
        return Directory.GetFiles(StaticSettings.LayoutsPath);
      } catch (DirectoryNotFoundException) {
        return new string[0] {};
      }
    }

    static public IEnumerable<string> GetExistingLayoutNames() {
      return GetExistingLayoutPaths().Select(path => Path.GetFileNameWithoutExtension(Path.GetFileName(path)));
    }

    static public IEnumerable<string> GetValidLayoutNames() {
      List<string> validLayoutNames = new();

      foreach (string existingLayoutName in GetExistingLayoutNames()) {
        if (Layout.HasValidCorrespondingFile(existingLayoutName)) {
          validLayoutNames.Add(existingLayoutName);
        }
      }

      return validLayoutNames;
    }

    static public bool IsNameAlreadyTaken(string name) {
      return GetExistingLayoutNames().Contains(name);
    }

    public static string GenerateNewLayoutUniqueName(string nameBase) {
      int nameCollisionPreventiveSuffix = 1;
      var existingLayoutsNames = GetExistingLayoutNames();

      while (existingLayoutsNames.Contains($"{ nameBase }{ nameCollisionPreventiveSuffix }")) {
        nameCollisionPreventiveSuffix++;
      }

      return $"{ nameBase }{ nameCollisionPreventiveSuffix }";
    }
  }
}
