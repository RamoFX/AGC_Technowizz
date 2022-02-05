using Core.Helpers;



namespace Core {
  static public partial class DynamicSettings {
    static public DynamicSetting ZA_StartupLayoutName = new("ZA_StartupLayoutName", "Příklad 2"); // Až bude rozvržení "Příklad 1", tak změnit na něj
    static public DynamicSetting ZA_HighlightTimeOn = new("ZA_HighlightTimeOn", "600");
    static public DynamicSetting ZA_HighlightTimeOff = new("ZA_HighlightTimeOff", "400");
    static public DynamicSetting ZA_TotalHighlightFlashes = new("ZA_TotalHighlightFlashes", "4");
    static public DynamicSetting ZA_LastHighlightOnOff = new("ZA_LastHighlightOn", "true");
  }
}
