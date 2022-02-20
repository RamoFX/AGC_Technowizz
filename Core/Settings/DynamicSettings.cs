namespace Core.Settings {
  static public partial class DynamicSettings {
    // Zone assigner
    static public DynamicSetting StartupLayoutName = new("StartupLayoutName", "Příklad 1");

    // Highlight
    static public DynamicSetting Highlight_Duration          = new("Highlight_Duration_On",       "500");
    static public DynamicSetting Highlight_TotalFlashesCount = new("Highlight_TotalFlashesCount", "4");

    // Colors
    static public DynamicSetting GridColor = new("NeutralColor_Light", "LightGray");

    static public DynamicSetting ZoneColor_Other = new("ZoneColor_Other",   "DeepPink");

    static public DynamicSetting ZoneColor_Full        = new("ZoneColor_Full",        "Red");
    static public DynamicSetting ZoneColor_AlmostFull  = new("ZoneColor_AlmostFull",  "OrangeRed");
    static public DynamicSetting ZoneColor_AboveHalf   = new("ZoneColor_AboveHalf",   "Orange");
    static public DynamicSetting ZoneColor_BelowHalf   = new("ZoneColor_BelowHalf",   "Yellow");
    static public DynamicSetting ZoneColor_AlmostEmpty = new("ZoneColor_AlmostEmpty", "DarkSeaGreen");
    static public DynamicSetting ZoneColor_Empty       = new("ZoneColor_Empty",       "DarkCyan");
  }
}
