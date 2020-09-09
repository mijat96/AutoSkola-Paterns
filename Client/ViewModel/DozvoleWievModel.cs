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
    public class DozvoleWievModel : INotifyPropertyChanged
    {
        public Window Window { get; set; }
        public AutoSkola Skola { get; set; }
        private List<Dozvola> binding;
        public Dozvola IzabranaDozvola { get; set; }

        private ILogger logger = new Logger();

        public ILogger Logger { get => logger; set => logger = value; }

        public DozvoleWievModel(AutoSkola s)
        {
            DodajDozvoluProzorKomanda = new DodajDozvoluProzorKomanda(this);
            OsveziDozvoleKomanda = new OsveziDozvoleKomanda(this);
            IzmeniDozvoluPorozorKomanda = new IzmeniDozvoluPorozorKomanda(this);
            IzbrisiDozvoluKomanda = new IzbrisiDozvoluKomanda(this);
            Skola = s;
            //Skola.IDSkole = s.IDSkole;

            Binding = Konekcija.Instance.korisnikServisi.SveDozvole(s.IDSkole);
        }

        public List<Dozvola> Binding
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


        public ICommand DodajDozvoluProzorKomanda
        {
            get;
            private set;
        }

        public void DodajDozvolu()
        {
            try
            {
                new View.DodajDozvolu(Skola.IDSkole).Show();

            }
            catch
            {
                MessageBox.Show(Window, "Can't connect on server.");
            }
        }

        #region Osvezavanje
        public ICommand OsveziDozvoleKomanda
        {
            get;
            private set;
        }

        public void Osvezi()
        {
            try
            {
                Binding = Konekcija.Instance.korisnikServisi.SveDozvole(Skola.IDSkole);
            }
            catch
            {
                MessageBox.Show(Window, "Can't connect on server.");
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        #region Izmena
        public ICommand IzmeniDozvoluPorozorKomanda
        {
            get;
            private set;
        }

        public bool CanChangeRazredWindow
        {
            get
            {
                if (IzabranaDozvola == null)
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
                Window w = new View.IzmeniDozvolu();
                w.DataContext = new ProzorIzmeneDozvoleViewModel() { Window = w, ChangeRa = this.IzabranaDozvola };
                w.ShowDialog();

            }
            catch
            {
                MessageBox.Show(Window, "Can't connect on server.");
            }
        }
        #endregion
        #region Briasnje
        public ICommand IzbrisiDozvoluKomanda
        {
            get;
            private set;
        }

        public bool CanDeleteRa
        {
            get
            {
                if (IzabranaDozvola == null)
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
                Konekcija.Instance.korisnikServisi.IzbrisiDozvolu(IzabranaDozvola);
                Logger.LogKlijent("\nUspesno ste izbrisali dozvolu: " + IzabranaDozvola.nazivDozvole, DateTime.Now);
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
