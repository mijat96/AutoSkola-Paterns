using Client.Komande;
using Common;
using Common.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client.ViewModel
{
    public class DodajKorisnikaViewModel : INotifyPropertyChanged
    {
        public Window window { get; set; }
        public Korisnik korisnik { get; set; }
        private ILogger logger = new Logger();
        private bool admin = false;
        
        public DodajKorisnikaViewModel()
        {
            korisnik = new Korisnik();
            RegistracijaKorisnikaKomanda = new RegistracijaKorisnikaKomanda(this);
            
        }

        public ICommand RegistracijaKorisnikaKomanda
        {
            get;
            private set;
        }

        public bool ProveraKorisnika
        {
            get
            {
                return !String.IsNullOrEmpty(korisnik.KorisnickoIme) && !String.IsNullOrEmpty(korisnik.Sifra);
            }

        }

        public void Dodaj()
        {
            //Strategy pattern for validation of user
            //Context context = new Context(NewUser);
            if (korisnik != null)
            {
                try
                {
                    if (!Admin)
                        korisnik.VrstaClanstva = Common.Enums.Clanovi.KORISNIK;
                    else
                        korisnik.VrstaClanstva = Common.Enums.Clanovi.ADMIN;
                    if (Konekcija.Instance.korisnikServisi.DodajKorisnika(korisnik))
                    {
                        MessageBox.Show("Uspesno ste dodali korisnika " + korisnik.KorisnickoIme);
                        Logger.LogKlijent("\nUspesno ste dodali korisnika: " + korisnik.KorisnickoIme, DateTime.Now);
                        window.Close();
                    }
                    else
                        MessageBox.Show("Korisnicko ime \"" + korisnik.KorisnickoIme + "\" vec postoji..");
                }
                catch
                {
                    MessageBox.Show("Greska u komunikaciji", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please, fiil all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public ILogger Logger { get => logger; set => logger = value; }

    }
}
