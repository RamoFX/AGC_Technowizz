using System;
using System.IO;



namespace Core.Settings {
  public static class StaticSettings {
    // Solution
    static public readonly string SolutionBasePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    public const string SolutionBaseName = "AGC_Technowizz";
    static public readonly string SolutionPath = Path.Combine(SolutionBasePath, SolutionBaseName);



    // Layout
    public const string LayoutsBaseName = "Layouts";
    static public readonly string LayoutsPath = Path.Combine(SolutionPath, LayoutsBaseName);
    public const string LayoutSchemaName = "Layout.xsd";


    // Dynamic settings
    public const string SettingsFileName = "Settings.ukvp"; // ukvp == Unordered key-value pairs
    static public readonly string SettingsFilePath = Path.Combine(SolutionPath, SettingsFileName);
    public const char SettingsSeparator = ':';



    // Visual
    public const int UnitSize = 48;
    public const int OutlineSize = 4;



    // Other
    public const char CustomStringSeparator = ',';
  }
}
