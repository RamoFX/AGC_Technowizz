using Core.Helpers;



namespace Core {
  static public partial class DynamicSettings {
    // Zone assigner
    static public DynamicSetting     ZA_StartupLayoutName = new("ZA_StartupLayoutName",     "Příklad 1");
    static public DynamicSetting       ZA_HighlightTimeOn = new("ZA_HighlightTimeOn",       "600");
    static public DynamicSetting      ZA_HighlightTimeOff = new("ZA_HighlightTimeOff",      "400");
    static public DynamicSetting ZA_TotalHighlightFlashes = new("ZA_TotalHighlightFlashes", "4");
    static public DynamicSetting    ZA_LastHighlightOnOff = new("ZA_LastHighlightOnOff",    "true");

    // Colors
    static public DynamicSetting               LayoutColor = new("LayoutColor",               "DarkGray");
    static public DynamicSetting                 GridColor = new("GridColor",                 "LightGray");

    static public DynamicSetting         ZoneColor_Storage = new("ZoneColor_Storage",         "DarkBlue");
    static public DynamicSetting           ZoneColor_Other = new("ZoneColor_Other",           "DeepPink");

    static public DynamicSetting        CarBrandColor_Full = new("CarBrandColor_Full",        "Red");
    static public DynamicSetting  CarBrandColor_AlmostFull = new("CarBrandColor_AlmostFull",  "OrangeRed");
    static public DynamicSetting   CarBrandColor_AboveHalf = new("CarBrandColor_AboveHalf",   "Orange");
    static public DynamicSetting   CarBrandColor_BelowHalf = new("CarBrandColor_BelowHalf",   "Yellow");
    static public DynamicSetting CarBrandColor_AlmostEmpty = new("CarBrandColor_AlmostEmpty", "DarkSeaGreen");
    static public DynamicSetting       CarBrandColor_Empty = new("CarBrandColor_Empty",       "DarkCyan");
  }
}
