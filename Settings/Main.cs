using Core;
using Core.UI;
using Core.Extensions;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Settings
{
  public partial class Main : Form
  {
    public Main()
    {
      InitializeComponent();
    }

    private void Main_Load(object sender, EventArgs e)
    {
      propertyGrid.SelectedObject = new __Properties();
      propertyGrid.PropertySort = PropertySort.Categorized;
    }
  }

  class __Properties
  {
    [DisplayName("Název počátečního rozložení")]
    [Category("Rozložení")]
    public string ZA_StartupLayoutName {
      get => DynamicSettings.ZA_StartupLayoutName.Value;
      set => DynamicSettings.ZA_StartupLayoutName.Value = value;
    }

    [DisplayName("Čas rozsvícení zóny (blikání)")]
    [Category("Čas (ms)")]
    public int ZA_HighlightTimeOn {
      get => DynamicSettings.ZA_HighlightTimeOn.Value.ToInt();
      set => DynamicSettings.ZA_HighlightTimeOn.Value = value.ToString();
    }

    [DisplayName("Čas zhasnutí zóny (blikání)")]
    [Category("Čas (ms)")]
    public int ZA_HighlightTimeOff {
      get => DynamicSettings.ZA_HighlightTimeOff.Value.ToInt();
      set => DynamicSettings.ZA_HighlightTimeOff.Value = value.ToString();
    }

    [DisplayName("Celkový počet rozsvícení zóny")]
    [Category("Blikání")]
    public int ZA_TotalHighlightFlashes { 
      get => DynamicSettings.ZA_TotalHighlightFlashes.Value.ToInt(); 
      set => DynamicSettings.ZA_TotalHighlightFlashes.Value = value.ToString(); 
    }

    [DisplayName("Nechat zónu rozsvícenou")]
    [Category("Blikání")]
    public bool ZA_LastHighlightOnOff { 
      get => DynamicSettings.ZA_LastHighlightOnOff.Value.ToBool(); 
      set => DynamicSettings.ZA_LastHighlightOnOff.Value = value.ToString();
    }

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

    [DisplayName("Barva skladovácích prostorů")]
    [Category("Barva")]
    public Color ZoneColor_Storage { 
      get => DynamicSettings.ZoneColor_Storage.Value.ToColor(); 
      set => DynamicSettings.ZoneColor_Storage.Value = value.Name; 
    }

    [DisplayName("Barva ostatních prosotrů")]
    [Category("Barva")]
    public Color ZoneColor_Other { 
      get => DynamicSettings.ZoneColor_Other.Value.ToColor(); 
      set => DynamicSettings.ZoneColor_Other.Value = value.Name; 
    }

    [DisplayName("Barva plné zóny")]
    [Category("Barva")]
    public Color CarBrandColor_Full { 
      get => DynamicSettings.CarBrandColor_Full.Value.ToColor(); 
      set => DynamicSettings.CarBrandColor_Full.Value = value.Name; 
    }

    [DisplayName("Barva skoro plné zóny")]
    [Category("Barva")]
    public Color CarBrandColor_AlmostFull { 
      get => DynamicSettings.CarBrandColor_AlmostFull.Value.ToColor(); 
      set => DynamicSettings.CarBrandColor_AlmostFull.Value = value.Name; 
    }

    [DisplayName("Barva zóny zaplněné nad polovinu")]
    [Category("Barva")]
    public Color CarBrandColor_AboveHalf { 
      get => DynamicSettings.CarBrandColor_AboveHalf.Value.ToColor(); 
      set => DynamicSettings.CarBrandColor_AboveHalf.Value = value.Name; 
    }

    [DisplayName("Barva zóny zaplněné do poloviny")]
    [Category("Barva")]
    public Color CarBrandColor_BelowHalf {
      get => DynamicSettings.CarBrandColor_BelowHalf.Value.ToColor(); 
      set => DynamicSettings.CarBrandColor_BelowHalf.Value = value.Name;
    }

    [DisplayName("Barva skoro prázdné zóny")]
    [Category("Barva")]
    public Color CarBrandColor_AlmostEmpty { 
      get => DynamicSettings.CarBrandColor_AlmostEmpty.Value.ToColor(); 
      set => DynamicSettings.CarBrandColor_AlmostEmpty.Value = value.Name;
    }

    [DisplayName("Barva prázdné zóny")]
    [Category("Barva")]
    public Color CarBrandColor_Empty {
      get => DynamicSettings.CarBrandColor_Empty.Value.ToColor();
      set => DynamicSettings.CarBrandColor_Empty.Value = value.Name;
    }
  }
}