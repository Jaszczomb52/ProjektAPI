using System;
using System.Collections.Generic;

namespace ProjektAPI.Models
{
    public partial class Producent
    {
        public Producent()
        {
            CzescNaMagazynies = new HashSet<CzescNaMagazynie>();
        }

        public int Id { get; set; }
        public string Nazwa { get; set; } = null!;

        public virtual ICollection<CzescNaMagazynie> CzescNaMagazynies { get; set; }
    }
}
