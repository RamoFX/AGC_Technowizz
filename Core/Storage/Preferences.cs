using System;
using System.IO;
using Core.Helpers;



namespace Core.Storage {
  public static class Preferences {
    static public readonly string LayoutBasePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    static public readonly string LayoutBaseName = "AGC_Technowizz_Layouts";
    static public readonly string LayoutsPath = Path.Combine(LayoutBasePath, LayoutBaseName);
  }
}
