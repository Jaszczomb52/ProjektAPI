using System;
using System.Collections.Generic;

namespace ProjektAPI.Models
{
    public partial class CzescUzytaDoZlecenium
    {
        public int Id { get; set; }
        public DateTime DataWpisu { get; set; }
        public int Idzlecenia { get; set; }
        public int Idczesci { get; set; }

        public virtual CzescNaMagazynie? IdczesciNavigation { get; set; } = null!;
        public virtual Zlecenie? IdzleceniaNavigation { get; set; } = null!;
    }
}
