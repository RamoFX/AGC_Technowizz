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
    static public readonly string LayoutsPath     = Path.Combine(SolutionPath, LayoutsBaseName);



    // Visual
    public const           int   UnitSize                     = 30;
    public const           int   OutlineSize                  = 4;

    static public readonly Color LayoutOutlineColor           = Color.DarkGray;
    static public readonly Color LayoutGridColor              = Color.LightGray;

    static public readonly Color ZoneStorageOutlineColor      = Color.SkyBlue;
    static public readonly Color ZoneOtherOutlineColor        = Color.Magenta;

    static public readonly Color CarBrandOutlineColor         = Color.Cyan;

    static public readonly Color CarBrandFillColor_Full        = Color.Red;
    static public readonly Color CarBrandFillColor_AlmostFull  = Color.OrangeRed;
    static public readonly Color CarBrandFillColor_AboveHalf   = Color.Orange;
    static public readonly Color CarBrandFillColor_BelowHalf   = Color.Yellow;
    static public readonly Color CarBrandFillColor_AlmostEmpty = Color.LimeGreen;
    static public readonly Color CarBrandFillColor_Empty       = Color.Transparent;



    // Dynamic settings
    public const           string SettingsFileName  = "Settings.ukvp"; // ukvp == Unordered key-value pairs
    static public readonly string SettingsFilePath  = Path.Combine(SolutionPath, SettingsFileName);
    public const           char   SettingsSeparator = ':';
  }
}
