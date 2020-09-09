using Client.Komande;
using Common;
using Common.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModel
{
    class PregledKorisnikaViewModel
    {
        public Window window { get; set; }
        public Korisnik korisnik { get; set; }

        private ILogger logger = new Logger();

        public ILogger Logger { get => logger; set => logger = value; }

        public PregledKorisnikaViewModel(Korisnik k, Window w)
        {
            korisnik = k;
            window = w;
            IzmeniKorisnikaKomanda = new IzmeniKorisnikaKomanda(this);
        }

        public ICommand IzmeniKorisnikaKomanda
        {
            get;
            private set;
        }

        public bool Provera
        {
            get
            {
                return true;
            }
        }

        public void Izmeni()
        {
            //Context context = new Context(CurrentUser);
            if (korisnik != null)//(context.ChackValidation())
            {
                try
                {
                    if (Konekcija.Instance.korisnikServisi.PromeniKorisnikovaPolja(korisnik))
                    {
                        MessageBox.Show("Uspesno");
                        Logger.LogKlijent("\nUspesno izmenjen korisnik: " + korisnik.KorisnickoIme, DateTime.Now);
                        window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Falied");
                    }
                }
                catch
                {
                    MessageBox.Show("Connection failed", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please, fiil all fields!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
    }
}
