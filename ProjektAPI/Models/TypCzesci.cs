using System;
using System.Collections.Generic;

namespace ProjektAPI.Models
{
    public partial class TypCzesci
    {
        public TypCzesci()
        {
            CzescNaMagazynies = new HashSet<CzescNaMagazynie>();
        }

        public int Id { get; set; }
        public string Typ { get; set; } = null!;

        public virtual ICollection<CzescNaMagazynie>? CzescNaMagazynies { get; set; }
    }
}
