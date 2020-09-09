using Client.Komande;
using Client.View;
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
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            PrijavaKomanda = new PrijavaKomanda(this);
        }

        public Window Window { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }

        private ILogger logger = new Logger();

        public ILogger Logger { get => logger; set => logger = value; }
        public ICommand PrijavaKomanda
        {
            get;
            private set;
        }

        public bool DozvoljenaPrijava
        {
            get
            {
                return !String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(Password);
            }
        }

        public void Prijavi()
        {
            try
            {
               Konekcija.Instance.korisnikServisi.ProveriKorisnika("admin", "admin");

               Korisnik user = Konekcija.Instance.korisnikServisi.Get(UserName);
                if (user != null)
                {
                    if (user.Sifra == Password)
                    {
                        MessageBox.Show("Dobro dosli " + UserName + "!", " ugodno koriscenje aplikacije", MessageBoxButton.OK, MessageBoxImage.Information);
                        Logger.LogKlijent("\nUspesno prijavljen korisnik: " + UserName, DateTime.Now);
                        new Pocetna(user).Show();
                        Window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Pogresna sifra!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Korisnik ne postoji!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Greska u komunikaciji", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
