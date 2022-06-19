using System;
using System.Collections.Generic;

namespace ProjektAPI.Models
{
    public partial class Zlecenie
    {
        public Zlecenie()
        {
            CzescUzytaDoZlecenia = new HashSet<CzescUzytaDoZlecenium>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public bool KontaktTelefoniczny { get; set; }
        public DateTime DataPrzyjecia { get; set; }
        public decimal Koszt { get; set; }
        public DateTime? DataWydania { get; set; }
        public string? NumerTelefonu { get; set; }
        public string Status { get; set; } = null!;
        public bool SzybkieZlecenie { get; set; }
        public string OpisZlecenia { get; set; } = null!;
        public int Idpracownika { get; set; }

        public virtual Pracownicy IdpracownikaNavigation { get; set; } = null!;
        public virtual ICollection<CzescUzytaDoZlecenium> CzescUzytaDoZlecenia { get; set; }
    }
}
