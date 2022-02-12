using System;
using System.IO;



namespace Core {
  public static class StaticSettings {
    // Solution
    static public readonly string SolutionBasePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    public const string SOLUTION_BASE_NAME = "AGC_Technowizz";
    static public readonly string SolutionPath = Path.Combine(SolutionBasePath, SOLUTION_BASE_NAME);



    // Layout
    public const string LAYOUTS_BASE_NAME = "Layouts";
    static public readonly string LayoutsPath = Path.Combine(SolutionPath, LAYOUTS_BASE_NAME);



    // Visual
    public const int UNIT_SIZE = 48;
    public const int OUTLINE_SIZE = 4;


    // Dynamic settings
    public const string SETTINGS_FILE_NAME = "Settings.ukvp"; // ukvp == Unordered key-value pairs
    static public readonly string SettingsFilePath = Path.Combine(SolutionPath, SETTINGS_FILE_NAME);
    public const char SETTINGS_SEPARATOR = ':';



    // Other
    public const char CUSTOM_STRING_SEPARATOR = ',';
  }
}
