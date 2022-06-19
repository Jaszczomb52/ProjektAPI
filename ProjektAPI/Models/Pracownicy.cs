using System;
using System.Collections.Generic;

namespace ProjektAPI.Models
{
    public partial class Pracownicy
    {
        public Pracownicy()
        {
            SpecjalizacjePracownikas = new HashSet<SpecjalizacjePracownika>();
            Zlecenies = new HashSet<Zlecenie>();
        }

        public int Id { get; set; }
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string NumerTelefonu { get; set; } = null!;

        public virtual ICollection<SpecjalizacjePracownika> SpecjalizacjePracownikas { get; set; }
        public virtual ICollection<Zlecenie> Zlecenies { get; set; }
    }
}
