using System;
using System.Collections.Generic;

namespace ProjektAPI.Models
{
    public partial class CzescNaMagazynie
    {
        public CzescNaMagazynie()
        {
            CzescUzytaDoZlecenia = new HashSet<CzescUzytaDoZlecenium>();
        }

        public int Id { get; set; }
        public string KodSegmentu { get; set; } = null!;
        public int Idproducenta { get; set; }
        public int Idtypu { get; set; }
        public int Idmodelu { get; set; }
        public bool Archiwum { get; set; }

        public virtual ModelCzesci IdmodeluNavigation { get; set; } = null!;
        public virtual Producent IdproducentaNavigation { get; set; } = null!;
        public virtual TypCzesci IdtypuNavigation { get; set; } = null!;
        public virtual ICollection<CzescUzytaDoZlecenium> CzescUzytaDoZlecenia { get; set; }
    }
}
