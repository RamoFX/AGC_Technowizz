using System.ComponentModel;
using System.Drawing;

using Core;
using Core.Extensions;
using Core.Settings;



namespace Settings {
  internal partial class SettingsProperties {
    [Category("Barva")]
    [DisplayName("Barva okrajů")]
    public Color LayoutColor {
      get => DynamicSettings.LayoutColor.Value.ToColor();
      set => DynamicSettings.LayoutColor.Value = value.Name;
    }



    [Category("Barva")]
    [DisplayName("Barva mřížky")]
    public Color GridColor {
      get => DynamicSettings.GridColor.Value.ToColor();
      set => DynamicSettings.GridColor.Value = value.Name;
    }



    [Category("Barva")]
    [DisplayName("Barva zóny pro uložení")]
    public Color ZoneColor_Storage {
      get => DynamicSettings.ZoneColor_Storage.Value.ToColor();
      set => DynamicSettings.ZoneColor_Storage.Value = value.Name;
    }



    [Category("Barva")]
    [DisplayName("Barva ostatních zón")]
    public Color ZoneColor_Other {
      get => DynamicSettings.ZoneColor_Other.Value.ToColor();
      set => DynamicSettings.ZoneColor_Other.Value = value.Name;
    }



    [Category("Barva")]
    [DisplayName("Barva plné zóny")]
    [Description("100%")]
    public Color ZoneColor_Full {
      get => DynamicSettings.ZoneColor_Full.Value.ToColor();
      set => DynamicSettings.ZoneColor_Full.Value = value.Name;
    }



    [Category("Barva")]
    [DisplayName("Barva skoro plné zóny")]
    [Description("99% ... 75%")]
    public Color ZoneColor_AlmostFull {
      get => DynamicSettings.ZoneColor_AlmostFull.Value.ToColor();
      set => DynamicSettings.ZoneColor_AlmostFull.Value = value.Name;
    }



    [Category("Barva")]
    [DisplayName("Barva zóny zaplněné nad polovinu")]
    [Description("74% ... 50%")]
    public Color ZoneColor_AboveHalf {
      get => DynamicSettings.ZoneColor_AboveHalf.Value.ToColor();
      set => DynamicSettings.ZoneColor_AboveHalf.Value = value.Name;
    }



    [Category("Barva")]
    [DisplayName("Barva zóny zaplněné do poloviny")]
    [Description("49% ... 25%")]
    public Color ZoneColor_BelowHalf {
      get => DynamicSettings.ZoneColor_BelowHalf.Value.ToColor();
      set => DynamicSettings.ZoneColor_BelowHalf.Value = value.Name;
    }



    [Category("Barva")]
    [DisplayName("Barva skoro prázdné zóny")]
    [Description("24% ... 1%")]
    public Color ZoneColor_AlmostEmpty {
      get => DynamicSettings.ZoneColor_AlmostEmpty.Value.ToColor();
      set => DynamicSettings.ZoneColor_AlmostEmpty.Value = value.Name;
    }



    [Category("Barva")]
    [DisplayName("Barva prázdné zóny")]
    [Description("0%")]
    public Color ZoneColor_Empty {
      get => DynamicSettings.ZoneColor_Empty.Value.ToColor();
      set => DynamicSettings.ZoneColor_Empty.Value = value.Name;
    }
  }
}
