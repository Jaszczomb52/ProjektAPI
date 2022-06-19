using System;
using System.Collections.Generic;

namespace ProjektAPI.Models
{
    public partial class SpecjalizacjePracownika
    {
        public int Id { get; set; }
        public short Diagnostyka { get; set; }
        public short NaprawaCzesci { get; set; }
        public short NaprawaSoftu { get; set; }
        public short Budowanie { get; set; }
        public int Idpracownika { get; set; }

        public virtual Pracownicy IdpracownikaNavigation { get; set; } = null!;
    }
}
