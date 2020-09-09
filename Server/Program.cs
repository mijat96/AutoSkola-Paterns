using Common;
using Common.access;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataBaseContext>());
            DataBaseContext db = new DataBaseContext();
            //db.Database.Delete();
            //db.Database.Create();
            Database.SetInitializer<DataBaseContext>(null);
            Konekcija konekcija = new Konekcija();

            using (var db1 = new DataBaseContext())
            {
                if (!db1.AutoSkolaBaza.Any())
                {
                    // The table is empty
                    Console.WriteLine("Baza je prazna");
                    AutoSkola a = new AutoSkola();
                    a.naziv = "Pocetna";
                    a.MBR = "prviMBR";
                    a.PIB = "prviPIB";
                    db1.AutoSkolaBaza.Add(a);
                    db1.SaveChanges();
                }
                //else
                //{
                //    Console.WriteLine("Baza auto skole je popunjena");
                //}
                if (!db1.Dozvole.Any())
                {
                    Dozvola d = new Dozvola();
                    AutoSkola a = new AutoSkola();
                    IEnumerable<AutoSkola> lista = db1.AutoSkolaBaza.ToList();
                    a = lista.First();
                    d.IDSkole = a.IDSkole;
                    d.nazivDozvole = "auto dozvola";
                    
                    db1.Dozvole.Add(d);
                    db1.SaveChanges();
                }
                if (!db1.Instruktori.Any())
                {
                    Instruktor i = new Instruktor();
                    AutoSkola a = new AutoSkola();
                    a = db1.AutoSkolaBaza.First();
                    i.IDSK = a.IDSkole;
                    i.ime = "Pocetnik";
                    i.obrazovanje = Enums.VrstaObrazovanja.OSNOVNO;
                    i.prezime = "Pripravnik";
                    db1.Instruktori.Add(i);
                    db1.SaveChanges();
                }

            }

            konekcija.Otvori();

            Console.ReadLine();
        }
    }
}
