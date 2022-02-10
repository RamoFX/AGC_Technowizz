using System.ComponentModel;
using System.Drawing;

using Core;
using Core.Extensions;



namespace Settings {
  internal partial class SettingsProperties {
    [DisplayName("Barva okrajů")]
    [Category("Barva")]
    public Color LayoutColor {
      get => DynamicSettings.LayoutColor.Value.ToColor();
      set => DynamicSettings.LayoutColor.Value = value.Name;
    }



    [DisplayName("Barva mřížky")]
    [Category("Barva")]
    public Color GridColor {
      get => DynamicSettings.GridColor.Value.ToColor();
      set => DynamicSettings.GridColor.Value = value.Name;
    }



    [DisplayName("Barva zóny pro uložení")]
    [Category("Barva")]
    public Color ZoneColor_Storage {
      get => DynamicSettings.ZoneColor_Storage.Value.ToColor();
      set => DynamicSettings.ZoneColor_Storage.Value = value.Name;
    }



    [DisplayName("Barva ostatních zón")]
    [Category("Barva")]
    public Color ZoneColor_Other {
      get => DynamicSettings.ZoneColor_Other.Value.ToColor();
      set => DynamicSettings.ZoneColor_Other.Value = value.Name;
    }



    [DisplayName("Barva plné zóny")]
    [Category("Barva")]
    [Description("100%")]
    public Color ZoneColor_Full {
      get => DynamicSettings.ZoneColor_Full.Value.ToColor();
      set => DynamicSettings.ZoneColor_Full.Value = value.Name;
    }



    [DisplayName("Barva skoro plné zóny")]
    [Category("Barva")]
    [Description("99% ... 75%")]
    public Color ZoneColor_AlmostFull {
      get => DynamicSettings.ZoneColor_AlmostFull.Value.ToColor();
      set => DynamicSettings.ZoneColor_AlmostFull.Value = value.Name;
    }



    [DisplayName("Barva zóny zaplněné nad polovinu")]
    [Category("Barva")]
    [Description("74% ... 50%")]
    public Color ZoneColor_AboveHalf {
      get => DynamicSettings.ZoneColor_AboveHalf.Value.ToColor();
      set => DynamicSettings.ZoneColor_AboveHalf.Value = value.Name;
    }



    [DisplayName("Barva zóny zaplněné do poloviny")]
    [Category("Barva")]
    [Description("49% ... 25%")]
    public Color ZoneColor_BelowHalf {
      get => DynamicSettings.ZoneColor_BelowHalf.Value.ToColor();
      set => DynamicSettings.ZoneColor_BelowHalf.Value = value.Name;
    }



    [DisplayName("Barva skoro prázdné zóny")]
    [Category("Barva")]
    [Description("24% ... 1%")]
    public Color ZoneColor_AlmostEmpty {
      get => DynamicSettings.ZoneColor_AlmostEmpty.Value.ToColor();
      set => DynamicSettings.ZoneColor_AlmostEmpty.Value = value.Name;
    }



    [DisplayName("Barva prázdné zóny")]
    [Category("Barva")]
    [Description("0%")]
    public Color ZoneColor_Empty {
      get => DynamicSettings.ZoneColor_Empty.Value.ToColor();
      set => DynamicSettings.ZoneColor_Empty.Value = value.Name;
    }
  }
}
