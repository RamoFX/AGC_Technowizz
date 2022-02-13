using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace Core {
  public partial class Layout {
    public partial class Entity {
      public void Add(Zone.Entity zone, int daysPeriod) {
        this.Zones.Add(zone);
        zone.Initialize(this, daysPeriod);
      }



      public void Add(Zone.Entity zone) {
        this.Zones.Add(zone);
        zone.Initialize(this, this.DaysPeriod);
      }
    }
  }
}
