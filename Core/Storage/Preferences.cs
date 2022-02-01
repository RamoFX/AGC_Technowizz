using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core.Helpers;



namespace Core.Storage {
  static class Preferences {
    static public readonly string LayoutBasePath = Paths.GetDocumentsPath();
    static public readonly string LayoutBaseName = "AGC_Technowizz_Configs";
    static public readonly string LayoutsPath = Paths.JoinPaths(LayoutBasePath, LayoutBaseName);
    static public readonly char LayoutCsvSeparator = ';';
  }
}
