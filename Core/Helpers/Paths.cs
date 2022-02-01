using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



namespace Core.Helpers {
  static class Paths {
    public static string GetDocumentsPath() {
      return Environment.GetFolderPath(
        Environment.SpecialFolder.MyDocuments
      );
    }

    public static string JoinPaths(params string[] paths) {
      return Path.Combine(paths);
    }

    public static string ApplyFileExtension(string path, string extension) {
      return Path.ChangeExtension(path, extension);
    }
  }
}
