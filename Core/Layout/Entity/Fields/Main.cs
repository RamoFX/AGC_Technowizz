﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;



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
        get => new(new(0, 0), Size);
      }



      [Browsable(false)]
      public readonly List<Zone.Entity> Zones;
    }
  }
}
