using Client.Komande;
using Common;
using Common.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static Common.Enums;

namespace Client.View
{
    class DodajDozvoleViewModel : INotifyPropertyChanged
    {
        public DodajDozvoleViewModel()
        {
            DodajDozvoluKomanda = new DodajDozvoluKomanda(this);
            //NewMusicTrack = new MusicTrack();
        }

        public Window Window { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Vrsta { get; set; }
        public VrstaDozvole Obrazovanje { get; set; }

        private ILogger logger = new Logger();

        public ILogger Logger { get => logger; set => logger = value; }

        public static ObservableCollection<Dozvola> Persons;




        public int IdInstruktora { get; set; }

        private bool[] checkBoxs = new bool[5] { false, false, false, false, false };

        public bool[] CheckBoxes
        {
            get
            {
                return checkBoxs;
            }

            set
            {
                checkBoxs = value;
            }
        }
        public ICommand DodajDozvoluKomanda
        {
            get;
            private set;
        }


        public bool CanAddInstruktora
        {
            get
            {

                return !String.IsNullOrWhiteSpace(Ime) &&

                    (CheckBoxes[0] || CheckBoxes[1] || CheckBoxes[2] || CheckBoxes[3] || CheckBoxes[4]);
            }
        }

        public void DodajInstruktora()
        {
            try
            {
                Dozvola r = new Dozvola();

                if (CheckBoxes[0])
                    r.vrstaDozvole = VrstaDozvole.A;
                else if (CheckBoxes[1])
                    r.vrstaDozvole = VrstaDozvole.B;
                else if (CheckBoxes[2])
                    r.vrstaDozvole = VrstaDozvole.C;
                else if (CheckBoxes[3])
                    r.vrstaDozvole = VrstaDozvole.D;
                else
                    r.vrstaDozvole = VrstaDozvole.F;

                Persons = new ObservableCollection<Dozvola>();
                r.nazivDozvole = Ime;
                r.IDSkole = IdInstruktora;
                //r.IDInstruktor = IdInstruktora;
                //Instruktor r = new Instruktor(ImeRazreda, IdRazreda, Oznaka, Vrsta);
                Persons.Add(r);
                Konekcija.Instance.korisnikServisi.AddDozvola(r.nazivDozvole, IdInstruktora, r.vrstaDozvole);
                Logger.LogKlijent("\nUspesno ste dodali dozvolu: " + r.nazivDozvole, DateTime.Now);
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
