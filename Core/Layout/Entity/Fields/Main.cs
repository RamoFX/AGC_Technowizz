using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using Core.Extensions;
using Core.Settings;



namespace Core {
  public partial class Layout {
    public partial class Entity {
      [Browsable(true), DisplayName("Název rozložení")]
      public string Name { get; set; }



      [Browsable(true), DisplayName("Název skladu")]
      [Description("Musí se shodovat s názvem skladu nebo jiným identifikátorem v databázi, se kterou komunikuje.")]
      public string WarehouseName { get; set; }



      [Browsable(true), DisplayName("Rozměry")]
      public Size Size { get; set; }



      [Browsable(false)]
      public Rectangle Rectangle {
        get => new(new(0, 0), this.Size);
      }



      [Browsable(false)]
      public readonly Color Color = DynamicSettings.LayoutColor.Value.ToColor();



      [Browsable(false)]
      public readonly List<Zone.Entity> Zones;
    }
  }
}
