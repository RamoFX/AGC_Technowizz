using Core.Helpers;



namespace Core {
  static public partial class DynamicSettings {
    // Zone assigner
    static public DynamicSetting StartupLayoutName = new("StartupLayoutName", "Příklad 1");



    // Highlight
    static public DynamicSetting Highlight_CycleDuration     = new("Highlight_Duration_On",       "500");
    static public DynamicSetting Highlight_TotalFlashesCount = new("Highlight_TotalFlashesCount", "4");



    // Colors
    static public DynamicSetting        NeutralColor_Dark  = new("NeutralColor_Dark",         "DarkGray");
    static public DynamicSetting        NeutralColor_Light = new("NeutralColor_Light",        "LightGray");

    static public DynamicSetting        ZoneColor_Storage  = new("ZoneColor_Storage",         "DarkBlue");
    static public DynamicSetting        ZoneColor_Other    = new("ZoneColor_Other",           "DeepPink");

    static public DynamicSetting CarBrandColor_Full        = new("CarBrandColor_Full",        "Red");
    static public DynamicSetting CarBrandColor_AlmostFull  = new("CarBrandColor_AlmostFull",  "OrangeRed");
    static public DynamicSetting CarBrandColor_AboveHalf   = new("CarBrandColor_AboveHalf",   "Orange");
    static public DynamicSetting CarBrandColor_BelowHalf   = new("CarBrandColor_BelowHalf",   "Yellow");
    static public DynamicSetting CarBrandColor_AlmostEmpty = new("CarBrandColor_AlmostEmpty", "DarkSeaGreen");
    static public DynamicSetting CarBrandColor_Empty       = new("CarBrandColor_Empty",       "DarkCyan");
  }
}
