using ProjektAPI.Models;

namespace ProjektAPI
{
    public class CustomMethods
    {
        internal static List<Models.Pracownicy> GetZlecenia()
        {
            using (Models.projektContext ctx = new Models.projektContext())
            {
                List<Models.Pracownicy> temp = (from P in ctx.Pracownicies
                                         select new Models.Pracownicy
                                         {
                                             Id = P.Id,
                                             Imie = P.Imie,
                                             Nazwisko = P.Nazwisko,
                                             NumerTelefonu = P.NumerTelefonu,
                                             SpecjalizacjePracownikas = P.SpecjalizacjePracownikas,
                                             Zlecenies = P.Zlecenies
                                         }).ToList();
                return temp;
            }
        }

        internal static List<Zlecenia> LoadGeneralData()
        {
            using (var context = new Models.projektContext())
            {
                var temp = (from Zlec in context.Zlecenies
                            join CzeZl in context.CzescUzytaDoZlecenia on Zlec.Id equals CzeZl.Idzlecenia
                            join CzeMa in context.CzescNaMagazynies on CzeZl.Idczesci equals CzeMa.Id
                            join Typ in context.TypCzescis on CzeMa.Idtypu equals Typ.Id
                            join Prod in context.Producents on CzeMa.Idproducenta equals Prod.Id
                            join Mod in context.ModelCzescis on CzeMa.Idmodelu equals Mod.Id
                            join Prac in context.Pracownicies on Zlec.Idpracownika equals Prac.Id
                            select new Zlecenia
                            {
                                ImieKlienta = Zlec.Imie,
                                NazwiskoKlienta = Zlec.Nazwisko,
                                Email = Zlec.Email,
                                ImieSerwisanta = Prac.Imie,
                                NazwiskoSerwisanta = Prac.Nazwisko,
                                OpisProblemu = Zlec.OpisZlecenia,
                                TypUzytejCzesci = Typ.Typ,
                                ProducentCzesci = Prod.Nazwa,
                                ModelCzesci = Mod.Model,
                                DataPrzyjeciaZlecenia = Zlec.DataPrzyjecia,
                                DataWydaniaSprzetu = Zlec.DataWydania,
                                CzyKontaktTelefoniczny = Zlec.KontaktTelefoniczny,
                                Telefon = Zlec.NumerTelefonu,
                                CzySzybkieZlecenie = Zlec.SzybkieZlecenie,
                                StatusZlecenia = Zlec.Status
                            }).ToList();

                return temp;
            }
        }

        #region warehouse
        internal static List<CzescNaMagazynie> GetWarehouse()
        {
            using (projektContext ctx = new projektContext())
            {
                var temp = (from CNM in ctx.CzescNaMagazynies
                            select new CzescNaMagazynie
                            {
                                Id = CNM.Id,
                                KodSegmentu = CNM.KodSegmentu,
                                Idproducenta = CNM.Idproducenta,
                                Idtypu = CNM.Idtypu,
                                Idmodelu = CNM.Idmodelu,
                                Archiwum = CNM.Archiwum,
                                IdmodeluNavigation = CNM.IdmodeluNavigation,
                                IdproducentaNavigation = CNM.IdproducentaNavigation,
                                IdtypuNavigation = CNM.IdtypuNavigation,
                                CzescUzytaDoZlecenia = CNM.CzescUzytaDoZlecenia
                            }).ToList();
                return temp;
            }
        }
        #endregion
    }

    public class Methods<T>
    {
        internal static List<T> Get()
        {
            using (projektContext ctx = new projektContext())
            {
                try
                {
                    List<T>? P = default(List<T>);
                    P = typeof(T).Name == "ModelCzesci" ? (from _ in ctx.ModelCzescis select new ModelCzesci()
                                                           {
                                                               Id = _.Id,
                                                               Model = _.Model
                                                           }).ToList() as List<T> : P;

                    P = typeof(T).Name == "TypCzesci" ? (from _ in ctx.TypCzescis
                                                           select new TypCzesci()
                                                           {
                                                               Id = _.Id,
                                                               Typ = _.Typ
                                                           }).ToList() as List<T> : P;

                    P = typeof(T).Name == "CzescNaMagazynie" ? (from _ in ctx.CzescNaMagazynies
                                                           select new CzescNaMagazynie()
                                                           {
                                                               Id = _.Id,
                                                               Archiwum = _.Archiwum,
                                                               CzescUzytaDoZlecenia = _.CzescUzytaDoZlecenia,
                                                               Idmodelu = _.Idmodelu,
                                                               Idproducenta = _.Idproducenta,
                                                               Idtypu = _.Idtypu,
                                                               KodSegmentu = _.KodSegmentu
                                                           }).ToList() as List<T> : P;

                    P = typeof(T).Name == "Pracownicy" ? (from _ in ctx.Pracownicies
                                                           select new Pracownicy()
                                                           {
                                                               Id = _.Id,
                                                               Imie = _.Imie,
                                                               Nazwisko = _.Nazwisko,
                                                               NumerTelefonu = _.NumerTelefonu
                                                           }).ToList() as List<T> : P;

                    P = typeof(T).Name == "Producent" ? (from _ in ctx.Producents
                                                           select new Producent()
                                                           {
                                                               Id = _.Id,
                                                               Nazwa = _.Nazwa
                                                           }).ToList() as List<T> : P;

                    P = typeof(T).Name == "SpecjalizacjePracownika" ? (from _ in ctx.SpecjalizacjePracownikas
                                                           select new SpecjalizacjePracownika()
                                                           {
                                                               Id = _.Id,
                                                               Idpracownika = _.Idpracownika,
                                                               Budowanie = _.Budowanie,
                                                               Diagnostyka = _.Diagnostyka,
                                                               NaprawaCzesci = _.NaprawaCzesci,
                                                               NaprawaSoftu = _.NaprawaSoftu
                                                           }).ToList() as List<T> : P;

                    P = typeof(T).Name == "Zlecenie" ? (from _ in ctx.Zlecenies
                                                           select new Zlecenie()
                                                           {
                                                               Id = _.Id,
                                                               Idpracownika = _.Idpracownika,
                                                               Imie = _.Imie,
                                                               Nazwisko = _.Nazwisko,
                                                               DataPrzyjecia = _.DataPrzyjecia,
                                                               DataWydania = _.DataWydania,
                                                               Email = _.Email,
                                                               KontaktTelefoniczny = _.KontaktTelefoniczny,
                                                               Koszt = _.Koszt,
                                                               NumerTelefonu = _.NumerTelefonu,
                                                               OpisZlecenia = _.OpisZlecenia,
                                                               Status = _.Status,
                                                               SzybkieZlecenie = _.SzybkieZlecenie
                                                           }).ToList() as List<T> : P;
                    return P;
                }
                catch
                {
                    return default(List<T>);
                }
            }
        }
        
        internal static string Delete(int i)
        {
            using (var ctx = new projektContext())
            {
                try
                {
                    T? P = default(T);
                    P = typeof(T).Name == "ModelCzesci" ? (T)(object)ctx.ModelCzescis.First(_ => _.Id == i) : P;
                    P = typeof(T).Name == "TypCzesci" ? (T)(object)ctx.TypCzescis.First(_ => _.Id == i) : P;
                    P = typeof(T).Name == "CzescNaMagazynie" ? (T)(object)ctx.CzescNaMagazynies.First(_ => _.Id == i) : P;
                    P = typeof(T).Name == "Pracownicy" ? (T)(object)ctx.Pracownicies.First(_ => _.Id == i) : P;
                    P = typeof(T).Name == "Producent" ? (T)(object)ctx.Producents.First(_ => _.Id == i) : P;
                    P = typeof(T).Name == "SpecjalizacjePracownika" ? (T)(object)ctx.SpecjalizacjePracownikas.First(_ => _.Id == i) : P;
                    P = typeof(T).Name == "Zlecenie" ? (T)(object)ctx.Zlecenies.First(_ => _.Id == i) : P;
                    if ( P is null)
                        return typeof(T).ToString();
                    ctx.Remove(P);
                    ctx.SaveChanges();
                    return "Done";
                }
                catch(Exception e)
                {
                    return "Error" + e;
                }
            }
        }

        internal static string Modify(T input)
        {
            try
            {
                using (var ctx = new projektContext())
                {
                    T? P = input;
                    if (P is ModelCzesci)
                    {
                        if ((input as ModelCzesci) is null) return "null";
                        ctx.ModelCzescis.Update(input as ModelCzesci);
                        ctx.SaveChanges();
                    }

                    if (P is TypCzesci)
                    {
                        if ((input as TypCzesci) is null) return "null";
                        ctx.TypCzescis.Update(input as TypCzesci);
                        ctx.SaveChanges();
                    }
                    if (P is Pracownicy)
                    {
                        if ((input as Pracownicy) is null) return "null";
                        ctx.Pracownicies.Update(input as Pracownicy);
                        ctx.SaveChanges();
                    }
                    if (P is Producent)
                    {
                        if ((input as Producent) is null) return "null";
                        ctx.Producents.Update(input as Producent);
                        ctx.SaveChanges();
                    }
                    if (P is SpecjalizacjePracownika)
                    {
                        if ((input as SpecjalizacjePracownika) is null) return "null"; 
                        ctx.SpecjalizacjePracownikas.Update(input as SpecjalizacjePracownika);
                        ctx.SaveChanges();
                    }
                    if (P is Zlecenie)
                    {
                        if ((input as Zlecenie) is null) return "null";
                        ctx.Zlecenies.Update(input as Zlecenie);
                        ctx.SaveChanges();
                    }
                    if (P is null)
                        return "Null";
                    
                    return "Done";
                }
            }
            catch(Exception e)
            {
                return "Error" + e;
            }
        }

        internal static string Add(T input)
        {
            try
            {
                using (var ctx = new projektContext())
                {
                    T? P = input;

                    if (P is null)
                        return "Null";

                    if (P is ModelCzesci)
                    {
                        var temp = input as ModelCzesci;
                        if (temp != null)
                        {
                            temp.Id = ctx.ModelCzescis.Max(_ => (int?)_.Id) + 1 ?? 0;
                            ctx.ModelCzescis.Add(temp);
                        }
                    }

                    if (P is TypCzesci)
                    {
                        var temp = input as TypCzesci;
                        if (temp != null)
                        {
                            temp.Id = ctx.TypCzescis.Max(_ => (int?)_.Id) + 1 ?? 0;
                            ctx.TypCzescis.Add(temp);
                        }
                    }
                    if (P is Pracownicy)
                    {
                        var temp = input as Pracownicy;
                        if (temp != null)
                        {
                            temp.Id = ctx.Pracownicies.Max(_ => (int?)_.Id) + 1 ?? 0;
                            ctx.Pracownicies.Add(temp);
                        }
                    }
                    if (P is Producent)
                    {
                        var temp = input as Producent;
                        if (temp != null)
                        {
                            temp.Id = ctx.Producents.Max(_ => (int?)_.Id) + 1 ?? 0;
                            ctx.Producents.Add(temp);
                        }
                    }
                    if (P is SpecjalizacjePracownika)
                    {
                        var temp = input as SpecjalizacjePracownika;
                        if (temp != null)
                        {
                            temp.Id = ctx.SpecjalizacjePracownikas.Max(_ => (int?)_.Id) + 1 ?? 0;
                            ctx.SpecjalizacjePracownikas.Add(temp);
                        }
                    }
                    if (P is Zlecenie)
                    {
                        var temp = input as Zlecenie;
                        if (temp != null)
                        {
                            temp.Id = ctx.Zlecenies.Max(_ => (int?)_.Id) + 1 ?? 0;
                            ctx.Zlecenies.Add(temp);
                        }
                    }
                    
                    ctx.SaveChanges();
                    return "Done";
                }
            }
            catch(Exception e)
            {
                return "Error" + e;
            }
        }

    }

    // custom classes
    public class Zlecenia
    {
        public int ID { get; set; }
        public string ImieKlienta { set; get; }
        public string NazwiskoKlienta { get; set; }
        public string Email { set; get; }
        public string ImieSerwisanta { set; get; }
        public string NazwiskoSerwisanta { get; set; }
        public string OpisProblemu { set; get; }
        public string TypUzytejCzesci { set; get; }
        public string ProducentCzesci { set; get; }
        public string ModelCzesci { set; get; }
        public DateTime DataPrzyjeciaZlecenia { set; get; }
        public DateTime? DataWydaniaSprzetu { set; get; }
        public bool CzyKontaktTelefoniczny { set; get; }
        public string Telefon { set; get; }
        public bool CzySzybkieZlecenie { set; get; }
        public string StatusZlecenia { set; get; }
    }
}
