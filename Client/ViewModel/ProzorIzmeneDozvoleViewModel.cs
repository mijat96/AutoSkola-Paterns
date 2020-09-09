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
    class ProzorIzmeneDozvoleViewModel : INotifyPropertyChanged
    {
        public ProzorIzmeneDozvoleViewModel()
        {
            IzmeniDozvolu = new IzmeniDozvolu(this);
            ChangeRa = new Dozvola();
        }

        public Window Window { get; set; }
        public Dozvola ChangeRa { get; set; }

        private ILogger logger = new Logger();

        public ILogger Logger { get => logger; set => logger = value; }

        public ICommand IzmeniDozvolu
        {
            get;
            private set;
        }


        public bool CanChangeRa
        {
            get
            {
                return !String.IsNullOrWhiteSpace(ChangeRa.nazivDozvole);
            }
        }


        public void ChangeCurrentRa()
        {
            try
            {
                Konekcija.Instance.korisnikServisi.IzmeniDozvolu(ChangeRa);
                Logger.LogKlijent("\nUspesno izmenjena dozvola: " + ChangeRa.nazivDozvole, DateTime.Now);
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
