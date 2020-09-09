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

namespace Client.ViewModel
{
    public class DodajInstruktoreViewModel : INotifyPropertyChanged
    {
        public DodajInstruktoreViewModel()
        {
            DodajInstruktoraKomanda = new DodajInstruktoraKomanda(this);
            //NewMusicTrack = new MusicTrack();
        }

        public Window Window { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Vrsta { get; set; }
        public VrstaObrazovanja Obrazovanje { get; set; }

        private ILogger logger = new Logger();

        public ILogger Logger { get => logger; set => logger = value; }

        public static ObservableCollection<Instruktor> Persons;




        public int IdInstruktora { get; set; }

        private bool[] checkBoxs = new bool[3] { false, false, false };

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
        public ICommand DodajInstruktoraKomanda
        {
            get;
            private set;
        }


        public bool CanAddInstruktora
        {
            get
            {
                return !String.IsNullOrWhiteSpace(Ime) &&
                        !String.IsNullOrWhiteSpace(Prezime) &&

                    (CheckBoxes[0] || CheckBoxes[1] || CheckBoxes[2]);
            }
        }

        public void DodajInstruktora()
        {
            try
            {
                Instruktor r = new Instruktor();
                string[] roles = new string[3] { "Osovno", "Srednje", "Visoko" };
                if (CheckBoxes[0])
                    r.obrazovanje = VrstaObrazovanja.OSNOVNO;
                else if (CheckBoxes[1])
                    r.obrazovanje = VrstaObrazovanja.SREDNJE;
                else
                    r.obrazovanje = VrstaObrazovanja.VISOKO;

                Persons = new ObservableCollection<Instruktor>();
                r.ime = Ime;
                r.prezime = Prezime;
                r.IDSK = IdInstruktora;
                //r.IDInstruktor = IdInstruktora;
                //Instruktor r = new Instruktor(ImeRazreda, IdRazreda, Oznaka, Vrsta);
                Persons.Add(r);
                Konekcija.Instance.korisnikServisi.AddInsturktor(r.ime, IdInstruktora, r.obrazovanje, r.prezime);
                Logger.LogKlijent("\nUspesno ste dodali instruktora: " + r.ime, DateTime.Now);
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
