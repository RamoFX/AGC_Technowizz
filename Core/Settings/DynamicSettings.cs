namespace Core.Settings {
  static public partial class DynamicSettings {
    // Layout drawer
    static public DynamicSetting ZoneNameSize = new("ZoneNameSize", "12");

    // Colors
    static public DynamicSetting GridColor = new("GridColor", "LightGray");

    static public DynamicSetting ZoneColor_Other = new("ZoneColor_Other",   "DeepPink");

    static public DynamicSetting ZoneColor_Full        = new("ZoneColor_Full",        "Maroon");
    static public DynamicSetting ZoneColor_AlmostFull  = new("ZoneColor_AlmostFull",  "Red");
    static public DynamicSetting ZoneColor_AboveHalf   = new("ZoneColor_AboveHalf",   "Orange");
    static public DynamicSetting ZoneColor_BelowHalf   = new("ZoneColor_BelowHalf",   "DarkSeaGreen");
    static public DynamicSetting ZoneColor_AlmostEmpty = new("ZoneColor_AlmostEmpty", "DarkOliveGreen");
    static public DynamicSetting ZoneColor_Empty       = new("ZoneColor_Empty",       "DarkCyan");
  }
}
