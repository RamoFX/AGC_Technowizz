using System;
using System.Drawing;
using System.IO;



namespace Core.Settings {
  public static class StaticSettings {
    // Solution
    static public readonly string SolutionBasePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    public const string SOLUTION_BASE_NAME = "AGC_Technowizz";
    static public readonly string SolutionPath = Path.Combine(SolutionBasePath, SOLUTION_BASE_NAME);



    // Layout
    public const string LayoutsBaseName = "Layouts";
    static public readonly string LayoutsPath = Path.Combine(SolutionPath, LayoutsBaseName);
    public const string LayoutSchemaName = "Layout.xsd";


    // Dynamic settings
    public const string SettingsFileName = "Settings.ukvp"; // ukvp == Unordered key-value pairs
    static public readonly string SettingsFilePath = Path.Combine(SolutionPath, SettingsFileName);
    public const char SETTINGS_SEPARATOR = ':';



    // Visual
    public const int OUTLINE_SIZE = 2;

    static public Font ZoneNameFont {
      get => new(
        "Courier New",
        DynamicSettings.ZoneNameSize.Value.ToInt(),
        FontStyle.Regular,
        GraphicsUnit.Pixel
      );
    }



    // Other
    public const char CUSTOM_STRING_SEPARATOR = ',';
  }
}
