using Core.Helpers;



namespace Core.Storage {
  public static class Preferences {
    static public readonly string LayoutBasePath = Paths.GetDocumentsPath();
    static public readonly string LayoutBaseName = "AGC_Technowizz_Layouts";
    static public readonly string LayoutsPath = Paths.JoinPaths(LayoutBasePath, LayoutBaseName);
  }
}
