using Common;
using Common.access;
using Common.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.Enums;

namespace Server
{
    public class KorisnikServisi : IKorisnikServisi
    {
        private KorisnikServisi() { }

        private ILogger logger = new Logger();

        public ILogger Logger { get => logger; set => logger = value; }

        public bool DodajKorisnika(Korisnik k)
        {
            using (var dbContext = new DataBaseContext())
            {
                try
                {
                    dbContext.Korisnici.Add(k);
                    dbContext.SaveChanges();
                    Logger.LogServer("\nUspesno dodat korisnik: " + k.KorisnickoIme, DateTime.Now);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool PromeniKorisnikovaPolja(Korisnik k)
        {
            using (var dbContext = new DataBaseContext())
            {
                try
                {
                    var oldUser = dbContext.Korisnici.Find(k.KorisnickoIme);
                    if (oldUser != null)
                    {
                        dbContext.Korisnici.Remove(oldUser);
                        dbContext.SaveChanges();
                        dbContext.Korisnici.Add(k);
                        Logger.LogServer("\nUspesno izmenjen korisnik: " + k.KorisnickoIme, DateTime.Now);
                        dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public void ProveriKorisnika(string ime, string sifra)
        {
            using (var dbContext = new DataBaseContext())
            {
                var admin = dbContext.Korisnici.FirstOrDefault(m => m.KorisnickoIme == ime);
                if (admin == null)
                {
                    var user = new Korisnik
                    {
                        KorisnickoIme = "Admin",
                        VrstaClanstva = Enums.Clanovi.ADMIN,
                        Sifra = "admin",
                    };
                    dbContext.Korisnici.Add(user);
                    dbContext.SaveChanges();
                }
            }
        }

        public Korisnik Get(string ime)
        {
            using (var dbContext = new DataBaseContext())
            {
                return dbContext.Korisnici.FirstOrDefault(m => m.KorisnickoIme == ime);
            }
        }

        public bool DodajSkolu(AutoSkola skola)
        {
            using (var dbContext = new DataBaseContext())
            {
                try
                {
                    dbContext.AutoSkolaBaza.Add(skola);
                    dbContext.SaveChanges();
                    Logger.LogServer("\nUspesno dodata skola: " + skola.naziv, DateTime.Now);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool IzmeniSkolu(AutoSkola skola)
        {
            using (var dbContext1 = new DataBaseContext())
            {
                var staraSkola = dbContext1.AutoSkolaBaza.FirstOrDefault(m => m.MBR == skola.MBR);

                if (staraSkola != null)
                {
                    var lists = dbContext1.AutoSkolaBaza.Where(f => f.naziv.Equals(staraSkola.naziv)).ToList();
                    lists.ForEach(a => a.naziv = skola.naziv);
                    dbContext1.SaveChanges();
                    Logger.LogServer("\nUspesno izmenjena skola: " + skola.naziv, DateTime.Now);
                }
            }

            using (var dbContext = new DataBaseContext())
            {
                try
                {
                    var staraSkola = dbContext.AutoSkolaBaza.FirstOrDefault(m => m.MBR == skola.MBR);

                    if (staraSkola != null)
                    {
                        dbContext.AutoSkolaBaza.Remove(staraSkola);
                        dbContext.SaveChanges();
                        dbContext.AutoSkolaBaza.Add(skola);
                        dbContext.SaveChanges();
                        Logger.LogServer("\nUspesno izmenjena skola: " + skola.naziv, DateTime.Now);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<AutoSkola> ListaSvihSkola()
        {
            using (var dbContext = new DataBaseContext())
            {
                List<AutoSkola> skole = dbContext.AutoSkolaBaza.ToList();
                skole = skole.OrderBy(x => x.MBR).ToList();
                return skole;
            }
        }

        public BindingList<AutoSkola> SveSkole()
        {
            using (var baza = new DataBaseContext())
            {
                return new BindingList<AutoSkola>(baza.AutoSkolaBaza.ToList());
            }

        }

        public bool ObrisiSkolu(AutoSkola skola)
        {
            using (var dbContext = new DataBaseContext())
            {
                try
                {
                    dbContext.AutoSkolaBaza.Attach(skola);
                    dbContext.AutoSkolaBaza.Remove(skola);
                    dbContext.SaveChanges();
                    Logger.LogServer("\nUspesno obrisana skola: " + skola.naziv, DateTime.Now);
                    return true;

                }
                catch
                {
                    return false;
                }

            }
        }

        public bool DuplicateSchool(AutoSkola ss)
        {
            int idnovePL;

            using (var baza = new DataBaseContext())
            {
                try
                {
                    var OldSch = baza.AutoSkolaBaza.Find(ss.IDSkole);
                    if (OldSch != null)
                    {
                        baza.AutoSkolaBaza.Add(OldSch);
                        baza.SaveChanges();
                        idnovePL = OldSch.IDSkole;
                       
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }


        public bool Probaj(AutoSkola skolaa)
        {
            using (var baza = new DataBaseContext())
            {
                var oldSch = baza.AutoSkolaBaza.Find(skolaa.IDSkole);
                if (oldSch == null)
                {
                    return false;
                }
                else return true;
            }
        }

        public bool AddInsturktor(string name, int idPL, VrstaObrazovanja oznaka, string prezime)
        {

            Instruktor ra = new Instruktor(name, idPL, oznaka, prezime);
            using (var baza = new DataBaseContext())
            {
                try
                {
                    baza.Instruktori.Add(ra);
                    baza.SaveChanges();

                    var helperFreeMT = baza.Instruktori.ToList().Find(x => x.ime == name);
                    if (helperFreeMT == null)
                    {
                        baza.Instruktori.Add(new Instruktor(name, idPL, oznaka, prezime));
                        baza.SaveChanges();
                        Logger.LogServer("\nUspesno dodat instruktor: " + name, DateTime.Now);

                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<Instruktor> SviInstruktori(int id)
        {
            List<Instruktor> pomocna = new List<Instruktor>();
            using (var baza = new DataBaseContext())
            {
                foreach (var mt in baza.Instruktori.ToList())
                {
                    if (id == mt.IDSK)
                        pomocna.Add(mt);
                }
            }
            return pomocna;
        }

        public bool IzmeniInstruktora(Instruktor ra)
        {
            using (var baza = new DataBaseContext())
            {
                try
                {
                    var oldRA = baza.Instruktori.Find(ra.IDInstruktor);
                    ra.IDInstruktor = oldRA.IDInstruktor;
                    if (oldRA != null)
                    {
                        baza.Instruktori.Remove(oldRA);
                        baza.SaveChanges();
                        baza.Instruktori.Add(ra);
                        baza.SaveChanges();
                        Logger.LogServer("\nUspesno izmenjen instruktor: " + ra.ime, DateTime.Now);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool IzbrisiInstruktora(Instruktor RA)
        {
            using (var baza = new DataBaseContext())
            {
                try
                {
                    var oldRA = baza.Instruktori.Find(RA.IDInstruktor);
                    if (oldRA != null)
                    {
                        baza.Instruktori.Remove(oldRA);
                        baza.SaveChanges();
                        Logger.LogServer("\nUspesno obrisan instruktor: " + RA.ime, DateTime.Now);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<Dozvola> SveDozvole(int id)
        {
            List<Dozvola> pomocna = new List<Dozvola>();
            using (var baza = new DataBaseContext())
            {
                foreach (var mt in baza.Dozvole.ToList())
                {
                    if (id == mt.IDSkole)
                        pomocna.Add(mt);
                }
            }
            return pomocna;
        }

        public bool AddDozvola(string name, int idPL, VrstaDozvole oznaka)
        {

            Dozvola ra = new Dozvola(name, idPL, oznaka);
            using (var baza = new DataBaseContext())
            {
                try
                {
                    baza.Dozvole.Add(ra);
                    baza.SaveChanges();
                    Logger.LogServer("\nUspesno dodata dozvola: " + name, DateTime.Now);


                    var helperFreeMT = baza.Dozvole.ToList().Find(x => x.nazivDozvole == name);
                    if (helperFreeMT == null)
                    {
                        baza.Dozvole.Add(new Dozvola(name, idPL, oznaka));
                        baza.SaveChanges();
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool IzbrisiDozvolu(Dozvola RA)
        {
            using (var baza = new DataBaseContext())
            {
                try
                {
                    var oldRA = baza.Dozvole.Find(RA.IDDozvole);
                    if (oldRA != null)
                    {
                        baza.Dozvole.Remove(oldRA);
                        baza.SaveChanges();
                        Logger.LogServer("\nUspesno izbrisana dozvola: " + RA.nazivDozvole, DateTime.Now);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool IzmeniDozvolu(Dozvola ra)
        {
            using (var baza = new DataBaseContext())
            {
                try
                {
                    var oldRA = baza.Dozvole.Find(ra.IDDozvole);
                    ra.IDDozvole = oldRA.IDDozvole;
                    if (oldRA != null)
                    {
                        baza.Dozvole.Remove(oldRA);
                        baza.SaveChanges();
                        baza.Dozvole.Add(ra);
                        baza.SaveChanges();
                        Logger.LogServer("\nUspesno izmenjena dozvola: " + ra.nazivDozvole, DateTime.Now);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        //public bool pokusajizmenuskole(autoskola skolaa)
        //{
        //    using (var baza = new databasecontext())
        //    {
        //        var oldsch = baza.autoskolabaza.find(skolaa.idskole);

        //        if (oldsch.lastchange != skolaa.lastchange)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            oldsch.naziv = skolaa.naziv;
        //            oldsch.opis = skolaa.opis;
        //            oldsch.lastchange = datetime.now;

        //            baza.savechanges();
        //            return true;
        //        }
        //    }
        //}

    }

}
