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
    public class ProzorIzmeneInstruktoraViewModel : INotifyPropertyChanged
    {
        public ProzorIzmeneInstruktoraViewModel()
        {
            IzmeniInstruktora = new IzmeniInstruktora(this);
            ChangeRa = new Instruktor();
        }

        public Window Window { get; set; }
        public Instruktor ChangeRa { get; set; }

        private ILogger logger = new Logger();

        public ILogger Logger { get => logger; set => logger = value; }

        public ICommand IzmeniInstruktora
        {
            get;
            private set;
        }


        public bool CanChangeRa
        {
            get
            {
                return !String.IsNullOrWhiteSpace(ChangeRa.ime) && !String.IsNullOrWhiteSpace(ChangeRa.prezime);
            }
        }


        public void ChangeCurrentRa()
        {
            try
            {
                Konekcija.Instance.korisnikServisi.IzmeniInstruktora(ChangeRa);
                Logger.LogKlijent("\nUspesno izmenjen instruktor: " + ChangeRa.ime, DateTime.Now);
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
