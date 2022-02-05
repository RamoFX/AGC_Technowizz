using System;
using System.Drawing;
using System.IO;



namespace Core {
  public static class StaticSettings {
    // Solution
    static public readonly string SolutionBasePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    public const           string SolutionBaseName = "AGC_Technowizz";
    static public readonly string     SolutionPath = Path.Combine(SolutionBasePath, SolutionBaseName);



    // Layout
    public const           string LayoutsBaseName = "Layouts";
    static public readonly string     LayoutsPath = Path.Combine(SolutionPath, LayoutsBaseName);



    // Visual
    public const           int                        UnitSize = 30;
    public const           int                     OutlineSize = 4;


    // Dynamic settings
    public const           string  SettingsFileName = "Settings.ukvp"; // ukvp == Unordered key-value pairs
    static public readonly string  SettingsFilePath = Path.Combine(SolutionPath, SettingsFileName);
    public const           char   SettingsSeparator = ':';
  }
}
