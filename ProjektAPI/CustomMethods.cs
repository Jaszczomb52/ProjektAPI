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

        #region eployees
        internal static string UpdateEmployee(Pracownicy temp)
        {
            using (var ctx = new Models.projektContext())
            {
                try
                {
                    Pracownicy? P = ctx.Pracownicies.Where(x => x.Id == temp.Id).FirstOrDefault();
                    if (P == null)
                        return "No such person in DB";
                    P.Imie = temp.Imie;
                    P.Nazwisko = temp.Nazwisko;
                    P.NumerTelefonu = temp.NumerTelefonu;
                    P.Zlecenies = temp.Zlecenies;
                    P.SpecjalizacjePracownikas = temp.SpecjalizacjePracownikas;
                    ctx.SaveChanges();
                    return "Done";
                }
                catch
                {
                    return "Error";
                }
            }
        }

        internal static string DeleteEmployee(int i)
        {
            using(var ctx = new Models.projektContext())
            {
                try
                {
                    Pracownicy? P = ctx.Pracownicies.Where(x => x.Id == i).FirstOrDefault();
                    if (P == null)
                        return "No such person in DB";
                    ctx.Remove(P);
                    ctx.SaveChanges();
                    return "Done";
                }
                catch
                {
                    return "Error";
                }
            }
        }

        internal static string InsertEmployee(Models.Pracownicy input)
        {
            using (var ctx = new Models.projektContext())
            {
                int id = ctx.Pracownicies.Max(x => (int?)x.Id) ?? 0;
                input.Id = id + 1;
                try
                {
                    ctx.Add(input);
                    ctx.SaveChanges();
                    return "done";
                }
                catch(Exception e)
                {
                    return e.ToString();
                }
            }
        }

        /// /////////////////////////////////////

        internal static string InsertSpec(Models.SpecjalizacjePracownika input)
        {
            using (var ctx = new Models.projektContext())
            {
                int id = ctx.SpecjalizacjePracownikas.Max(x => (int?)x.Id) ?? 0;
                input.Id = id + 1;
                try
                {
                    ctx.Add(input);
                    ctx.SaveChanges();
                    return "done";
                }
                catch(Exception e)
                {
                    return e.ToString();
                }
            }
        }

        #endregion
        #region dictionaries
        // Producent methods
        internal static List<Producent> GetProducents()
        {
            using (Models.projektContext ctx = new Models.projektContext())
            {
                List<Models.Producent> temp = (from P in ctx.Producents
                                                select new Models.Producent
                                                {
                                                    Id = P.Id,
                                                    Nazwa = P.Nazwa,
                                                    CzescNaMagazynies = P.CzescNaMagazynies
                                                }).ToList();
                return temp;
            }
        }

        internal static string AddProducent(Producent pr)
        {
            using (var ctx = new Models.projektContext())
            {
                int id = ctx.Producents.Max(x => (int?)x.Id) ?? 0;
                pr.Id = id + 1;
                try
                {
                    ctx.Add(pr);
                    ctx.SaveChanges();
                    return "done";
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
        }

        internal static string ModifyProducent(Producent prod)
        {
            using (var ctx = new Models.projektContext())
            {
                try
                {
                    Producent? P = ctx.Producents.Where(x => x.Id == prod.Id).FirstOrDefault();
                    if (P == null)
                        return "No such producent in DB";
                    P.Nazwa = prod.Nazwa;
                    P.CzescNaMagazynies = prod.CzescNaMagazynies;
                    ctx.SaveChanges();
                    return "Done";
                }
                catch
                {
                    return "Error";
                }
            }
        }

        internal static string DeleteProducent(int i)
        {
            using (var ctx = new Models.projektContext())
            {
                try
                {
                    Producent? P = ctx.Producents.Where(x => x.Id == i).FirstOrDefault();
                    if (P == null)
                        return "No such person in DB";
                    ctx.Remove(P);
                    ctx.SaveChanges();
                    return "Done"; 
                }
                catch
                {
                    return "Error";
                }
            }
        }

        // Types methods
        internal static List<TypCzesci> GetTypes()
        {
            using (Models.projektContext ctx = new Models.projektContext())
            {
                List<Models.TypCzesci> temp = (from P in ctx.TypCzescis
                                               select new Models.TypCzesci
                                               {
                                                   Id = P.Id,
                                                   Typ = P.Typ,
                                                   CzescNaMagazynies = P.CzescNaMagazynies
                                               }).ToList();
                return temp;
            }
        }

        internal static string AddType(TypCzesci tp)
        {
            using (var ctx = new Models.projektContext())
            {
                int id = ctx.TypCzescis.Max(x => (int?)x.Id) ?? 0;
                tp.Id = id + 1;
                try
                {
                    ctx.Add(tp);
                    ctx.SaveChanges();
                    return "done";
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
        }

        internal static string DeleteType(int i)
        {
            using (var ctx = new Models.projektContext())
            {
                try
                {
                    TypCzesci? P = ctx.TypCzescis.Where(x => x.Id == i).FirstOrDefault();
                    if (P == null)
                        return "No such person in DB";
                    ctx.Remove(P);
                    ctx.SaveChanges();
                    return "Done";
                }
                catch
                {
                    return "Error";
                }
            }
        }

        internal static string ModifyType(TypCzesci prod)
        {
            using (var ctx = new Models.projektContext())
            {
                try
                {
                    TypCzesci? P = ctx.TypCzescis.Where(x => x.Id == prod.Id).FirstOrDefault();
                    if (P == null)
                        return "No such producent in DB";
                    P.Typ = prod.Typ;
                    P.CzescNaMagazynies = prod.CzescNaMagazynies;
                    ctx.SaveChanges();
                    return "Done";
                }
                catch
                {
                    return "Error";
                }
            }
        }

        // Models methods
        internal static List<ModelCzesci> GetModels()
        {
            using (Models.projektContext ctx = new Models.projektContext())
            {
                List<Models.ModelCzesci> temp = (from P in ctx.ModelCzescis
                                               select new Models.ModelCzesci
                                               {
                                                   Id = P.Id,
                                                   Model = P.Model,
                                                   CzescNaMagazynies = P.CzescNaMagazynies
                                               }).ToList();
                return temp;
            }
        }

        internal static string AddModel(ModelCzesci tp)
        {
            using (var ctx = new Models.projektContext())
            {
                int id = ctx.ModelCzescis.Max(x => (int?)x.Id) ?? 0;
                tp.Id = id + 1;
                try
                {
                    ctx.Add(tp);
                    ctx.SaveChanges();
                    return "done";
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
        }

        internal static string ModifyModel(ModelCzesci prod)
        {
            using (var ctx = new Models.projektContext())
            {
                try
                {
                    ModelCzesci? P = ctx.ModelCzescis.Where(x => x.Id == prod.Id).FirstOrDefault();
                    if (P == null)
                        return "No such producent in DB";
                    P.Model = prod.Model;
                    P.CzescNaMagazynies = prod.CzescNaMagazynies;
                    ctx.SaveChanges();
                    return "Done";
                }
                catch
                {
                    return "Error";
                }
            }
        }

        internal static string DeleteModel(int i)
        {
            using (var ctx = new Models.projektContext())
            {
                try
                {
                    ModelCzesci? P = ctx.ModelCzescis.Where(x => x.Id == i).FirstOrDefault();
                    if (P == null)
                        return "No such person in DB";
                    ctx.Remove(P);
                    ctx.SaveChanges();
                    return "Done";
                }
                catch
                {
                    return "Error";
                }
            }
        }
        #endregion
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
