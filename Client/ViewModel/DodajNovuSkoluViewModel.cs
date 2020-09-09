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
    public class DodajNovuSkoluViewModel : INotifyPropertyChanged
    {
        public Window Window { get; set; }
        public Korisnik Korisnik { get; set; }
        public AutoSkola NovaSkola { get; set; }

        private ILogger logger = new Logger();

        public ILogger Logger { get => logger; set => logger = value; }

        public DodajNovuSkoluViewModel()
        {
            DodajSkoluKomanda = new DodajSkoluKomanda(this);
            Korisnik = new Korisnik();
            NovaSkola = new AutoSkola();
        }

        public ICommand DodajSkoluKomanda
        {
            get;
            private set;
        }

        public bool MozeliNovaSkola
        {
            get
            {
                return !String.IsNullOrWhiteSpace(NovaSkola.naziv) &&
                        !String.IsNullOrWhiteSpace(NovaSkola.PIB);
            }
        }

        public void DodajSkolu()
        {
            try
            {
                //UndoRedoDatabase.Undo.Add(new UndoRedo(NovaSkola, "ADD"));
                BindingList<AutoSkola> skole = Konekcija.Instance.korisnikServisi.SveSkole();
                bool postoji = false;
                foreach (AutoSkola s in skole)
                {
                    if (s.MBR == NovaSkola.MBR || s.naziv == NovaSkola.naziv || s.PIB == NovaSkola.PIB)
                        postoji = true;
                }
                if(postoji)
                    return;
                Konekcija.Instance.korisnikServisi.DodajSkolu(NovaSkola);
                Logger.LogKlijent("\nUspesno ste dodali skolu: " + NovaSkola.naziv, DateTime.Now);
                Window.Close();


            }
            catch
            {
                MessageBox.Show(Window, "Can't connect on server.");
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
    }
}
