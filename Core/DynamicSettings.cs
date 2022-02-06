using Core.Helpers;



namespace Core {
  static public partial class DynamicSettings {
    static public DynamicSetting ZA_StartupLayoutName          = new("ZA_StartupLayoutName", "Příklad 2"); // Až bude rozvržení "Příklad 1", tak změnit na něj
    static public DynamicSetting ZA_HighlightTimeOn            = new("ZA_HighlightTimeOn", "600");
    static public DynamicSetting ZA_HighlightTimeOff           = new("ZA_HighlightTimeOff", "400");
    static public DynamicSetting ZA_TotalHighlightFlashes      = new("ZA_TotalHighlightFlashes", "4");
    static public DynamicSetting ZA_LastHighlightOnOff         = new("ZA_LastHighlightOnOff", "true");

    static public DynamicSetting LayoutOutlineColor            = new("LayoutOutlineColor", "@169,169,169");
    static public DynamicSetting LayoutGridColor               = new("LayoutGridColor", "@211,211,211");

    static public DynamicSetting ZoneOutlineColor_Storage      = new("ZoneOutlineColor_Storage", "@135,206,235");
    static public DynamicSetting ZoneOutlineColor_Other        = new("ZoneOutlineColor_Other", "@255,0,255");

    static public DynamicSetting CarBrandOutlineColor          = new("CarBrandOutlineColor", "@0,255,255");

    static public DynamicSetting CarBrandFillColor_Full        = new("CarBrandFillColor_Full", "Red");
    static public DynamicSetting CarBrandFillColor_AlmostFull  = new("CarBrandFillColor_AlmostFull", "@255,69,0");
    static public DynamicSetting CarBrandFillColor_AboveHalf   = new("CarBrandFillColor_AboveHalf", "@255,165,0");
    static public DynamicSetting CarBrandFillColor_BelowHalf   = new("CarBrandFillColor_BelowHalf", "Yellow");
    static public DynamicSetting CarBrandFillColor_AlmostEmpty = new("CarBrandFillColor_AlmostEmpty", "LimeGreen");
    static public DynamicSetting CarBrandFillColor_Empty       = new("CarBrandFillColor_Empty", "#ffff");
  }
}
