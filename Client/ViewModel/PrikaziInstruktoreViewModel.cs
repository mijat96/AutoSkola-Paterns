using Client.Komande;
using Client.View;
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
    public class PrikaziInstruktoreViewModel : INotifyPropertyChanged
    {
        public Window Window { get; set; }
        public AutoSkola Skola { get; set; }
        private List<Instruktor> binding;
        public Instruktor IzabraniIsntruktor { get; set; }


        private ILogger logger = new Logger();

        public ILogger Logger { get => logger; set => logger = value; }

        public PrikaziInstruktoreViewModel(AutoSkola s)
        {
            DodajInstruktoraProzorKomanda = new DodajInstruktoraProzorKomanda(this);
            OsveziInstruktoreKomanda = new OsveziInstruktoreKomanda(this);
            IzmeniInstruktoraPorozorKomanda = new IzmeniInstruktoraPorozorKomanda(this);
            IzbrisiInstruktoraKomanda = new IzbrisiInstruktoraKomanda(this);
            Skola = s;
            //Skola.IDSkole = s.IDSkole;

            Binding = Konekcija.Instance.korisnikServisi.SviInstruktori(s.IDSkole);
        }
        #region Dodavanje
        public ICommand DodajInstruktoraProzorKomanda
        {
            get;
            private set;
        }

        public void DodajInstruktoraProzor()
        {
            try
            {
                new DodajInstruktora(Skola.IDSkole).Show();

            }
            catch
            {
                MessageBox.Show(Window, "Can't connect on server.");
            }
        }
        #endregion

        #region Osvezavanje
        public ICommand OsveziInstruktoreKomanda
        {
            get;
            private set;
        }

        public void Osvezi()
        {
            try
            {
                Binding = Konekcija.Instance.korisnikServisi.SviInstruktori(Skola.IDSkole);
            }
            catch
            {
                MessageBox.Show(Window, "Can't connect on server.");
            }
        }

        public List<Instruktor> Binding
        {
            get
            {
                return binding;
            }
            set
            {
                binding = value;
                OnPropertyChanged("Binding");
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        #region Izmena
        public ICommand IzmeniInstruktoraPorozorKomanda
        {
            get;
            private set;
        }

        public bool CanChangeRazredWindow
        {
            get
            {
                if (IzabraniIsntruktor == null)
                {
                    return false;
                }
                return true;
            }
        }


        public void ChangeRazredWindow()
        {
            try
            {
                Window w = new View.IzmeniInstruktora();
                w.DataContext = new ProzorIzmeneInstruktoraViewModel() { Window = w, ChangeRa = this.IzabraniIsntruktor };
                w.ShowDialog();

            }
            catch
            {
                MessageBox.Show(Window, "Can't connect on server.");
            }
        }
        #endregion
        #region Briasnje
        public ICommand IzbrisiInstruktoraKomanda
        {
            get;
            private set;
        }

        public bool CanDeleteRa
        {
            get
            {
                if (IzabraniIsntruktor == null)
                {
                    return false;
                }
                return true;
            }
        }


        public void DeleteCurentRa()
        {
            try
            {
                Konekcija.Instance.korisnikServisi.IzbrisiInstruktora(IzabraniIsntruktor);
                Logger.LogKlijent("\nUspesno izbrisan instruktor: " + IzabraniIsntruktor.ime, DateTime.Now);
            }
            catch
            {
                MessageBox.Show(Window, "Can't connect on server.");
            }
        }

        #endregion

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
