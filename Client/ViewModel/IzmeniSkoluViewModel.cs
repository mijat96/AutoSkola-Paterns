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
    public class IzmeniSkoluViewModel : INotifyPropertyChanged
    {
        public Window Window { get; set; }
        public AutoSkola Skola { get; set; }

        private ILogger logger = new Logger();

        public ILogger Logger { get => logger; set => logger = value; }

        public IzmeniSkoluViewModel()
        {
            IzmeniSkoluKomanda = new IzmeniSkoluKomanda(this);
            Skola = new AutoSkola();
        }
        public event PropertyChangedEventHandler PropertyChanged;


        public bool MozeLiPromena
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Skola.naziv) && !String.IsNullOrWhiteSpace(Skola.MBR) && !String.IsNullOrWhiteSpace(Skola.PIB);
            }
        }

        public void IzmeniAutoSkolu()
        {

            try
            {
                if (!Konekcija.Instance.korisnikServisi.Probaj(Skola))
                {
                    MessageBox.Show("Škola je u medjuvremenu izbrisana tako da je nemoguće menjati podatke!", "Greška", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else //if (!Konekcija.Instance.korisnikServisi.TryChangeSchool(Skola))
                {
                    if (MessageBox.Show("Škola je promenjena. Da li želite da promenite podatke?", " Window ", System.Windows.MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Konekcija.Instance.korisnikServisi.IzmeniSkolu(Skola);
                        Logger.LogKlijent("\nUspesno ste izmenili skolu: " + Skola.naziv, DateTime.Now);
                    }
                }
                Window.Close();
            }
            catch
            {
                MessageBox.Show(Window, "Can't connect to server.");
            }
        }

        public ICommand IzmeniSkoluKomanda
        {
            get;
            private set;
        }
    }
}
