using System;
using System.Collections.Generic;

namespace ProjektAPI.Models
{
    public partial class ModelCzesci
    {
        public ModelCzesci()
        {
            CzescNaMagazynies = new HashSet<CzescNaMagazynie>();
        }

        public int Id { get; set; }
        public string Model { get; set; } = null!;

        public virtual ICollection<CzescNaMagazynie> CzescNaMagazynies { get; set; }
    }
}
