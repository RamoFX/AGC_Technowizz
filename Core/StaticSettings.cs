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
    public const           int                    UnitSize = 30;
    public const           int                 OutlineSize = 4;

    static public readonly Color               LayoutColor = Color.DarkGray;
    static public readonly Color                 GridColor = Color.LightGray;

    static public readonly Color         ZoneColor_Storage = Color.DarkBlue;
    static public readonly Color           ZoneColor_Other = Color.DeepPink;

    static public readonly Color        CarBrandColor_Full = Color.Red;
    static public readonly Color  CarBrandColor_AlmostFull = Color.OrangeRed;
    static public readonly Color   CarBrandColor_AboveHalf = Color.Orange;
    static public readonly Color   CarBrandColor_BelowHalf = Color.Yellow;
    static public readonly Color CarBrandColor_AlmostEmpty = Color.DarkSeaGreen;
    static public readonly Color       CarBrandColor_Empty = Color.DarkCyan;



    // Dynamic settings
    public const           string  SettingsFileName = "Settings.ukvp"; // ukvp == Unordered key-value pairs
    static public readonly string  SettingsFilePath = Path.Combine(SolutionPath, SettingsFileName);
    public const           char   SettingsSeparator = ':';



    // Other
    public const char CustomStringSeparator = ',';
  }
}
