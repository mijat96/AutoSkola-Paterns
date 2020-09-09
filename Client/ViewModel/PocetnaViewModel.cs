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
    public class PocetnaViewModel : INotifyPropertyChanged
    {
        public Window window { get; set; }
        public Korisnik korisnik { get; set; }

        private BindingList<AutoSkola> bindingSkola;
        public AutoSkola ChoosedList { get; set; }

        public AutoSkola IzabranaSkola { get; set; }

        private ILogger logger = new Logger();

        public ILogger Logger { get => logger; set => logger = value; }

        public string SearchText { get; set; }

        public PocetnaViewModel()
        {
            DodajNovogKorisnikaKomanda = new DodajNovogKorisnikaKomanda(this);
            PregledKorisnikaKomanda = new PregledKorisnikaKomanda(this);
            OsveziListKomanda = new OsveziListKomanda(this);
            DodajProzorNoveSkoleKomanda = new DodajProzorNoveSkoleKomanda(this);
            OdjavaKomanda = new OdjavaKomanda(this);
            IzmeniSkoluProzorKomanda = new IzmeniSkoluProzorKomanda(this);
            PrikaziInstruktoreProzorKomanda = new PrikaziInstruktoreProzorKomanda(this);
            ProzorPrikazaDozvolaKomanda = new ProzorPrikazaDozvolaKomanda(this);
            DuplirajSkoluKomanda = new DuplirajSkoluKomanda(this);
            TraziSkoluKomanda = new TraziSkoluKomanda(this);
            BindingSkola = Konekcija.Instance.korisnikServisi.SveSkole();
        }
        #region DodajKorisnika
        public string ButtonContent
        {
            get
            {
                if (korisnik.VrstaClanstva == Common.Enums.Clanovi.ADMIN)
                    return "Dodaj korisnika";
                else
                    return "Nisi admin";
            }
        }

        public ICommand DodajNovogKorisnikaKomanda//AddNewUserCommand
        {
            get;
            private set;
        }

        public bool TypeOfUser
        {
            get
            {
                if (korisnik.VrstaClanstva == Common.Enums.Clanovi.ADMIN)
                    return true;
                return false;
            }

        }

        public void DodajKorisnika()
        {
            Window w = new DodajKorisnika();
            w.DataContext = new DodajKorisnikaViewModel() { window = w };
            w.ShowDialog();
        }
        #endregion

        #region PregledKorisnika
        public ICommand PregledKorisnikaKomanda
        {
            get;
            private set;
        }

        public void PogledajKorisnika()
        {
            Window w = new KorisnikPromeni(korisnik);
            w.DataContext = new PregledKorisnikaViewModel(korisnik, w);
            w.ShowDialog();
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public BindingList<AutoSkola> BindingSkola
        {
            get
            {
                return bindingSkola;
            }
            set
            {
                bindingSkola = value;
                OnPropertyChanged("BindingSkola");
            }
        }
        public bool CanDuplicateSchool
        {
            get
            {
                if (ChoosedList == null)
                {
                    return false;
                }
                return true;
            }
        }

        

        public bool CanChangeSchool
        {
            get
            {
                if (ChoosedList == null)
                {
                    return false;
                }
                return true;

            }
        }

        public bool MozeLiDozvola
        {
            get
            {
                if (ChoosedList == null)
                {
                    return false;
                }
                return true;
            }
        }

        public void PrikazDozvola()
        {
            try
            {
                new PrikaziDozvole(ChoosedList).Show();

            }
            catch
            {
                MessageBox.Show(window, "Greska u konekciji sa serverom");
            }
        }

        public ICommand OsveziListKomanda
        {
            get;
            private set;
        }

        public void Osvezi()
        {
            try
            {

                BindingSkola = Konekcija.Instance.korisnikServisi.SveSkole();
            }
            catch
            {
                MessageBox.Show(window, "Greska u konekciji sa serverom");
            }
        }

        public ICommand DodajProzorNoveSkoleKomanda
        {
            get;
            private set;
        }

        public bool MozeliDodati
        {
            get
            {

                return true;

            }
        }

        #region Odjava
        public ICommand OdjavaKomanda
        {
            get;
            private set;
        }

        public void OdjaviSe()
        {
            new MainWindow().Show();
            Logger.LogKlijent("\nUspesno ste se odjavili " + korisnik.KorisnickoIme, DateTime.Now);
            window.Close();
        }
        #endregion

        #region IzmeniSkolu

        public ICommand IzmeniSkoluProzorKomanda
        {
            get;
            private set;
        }
        public bool MozeliSeIzmeniti
        {
            get
            {
                if (ChoosedList != null)
                    return true;
                return false;
            }
        }

        public void IzmeniSkolu()
        {
            try
            {
                new IzmeniSkoluProzor(ChoosedList).Show();

            }
            catch
            {
                MessageBox.Show(window, "Greska u konekciji sa serverom");
            }
        }
        #endregion

        #region Prikaz Indstruktora
        public ICommand PrikaziInstruktoreProzorKomanda
        {
            get;
            private set;
        }
        public bool ProzorInstruktori
        {
            get
            {
                if (ChoosedList == null)
                {
                    return false;
                }
                return true;
            }
        }

        public void PrikaziInstruktoreProzor()
        {
            try
            {
                new InstruktoriProzor(ChoosedList).Show();

            }
            catch
            {
                MessageBox.Show(window, "Greska u konekciji sa serverom.");
            }
        }

        #endregion

        public ICommand ProzorPrikazaDozvolaKomanda
        {
            get;
            private set;
        }

        public ICommand DuplirajSkoluKomanda
        {
            get;
            private set;
        }


        public void DuplicateCurrentSchool()
        {
            try
            {
                
                Logger.LogKlijent("\nUspesno ste duplirali skolu sa imenom: " + ChoosedList.naziv, DateTime.Now);
                Konekcija.Instance.korisnikServisi.DuplicateSchool(ChoosedList);

            }
            catch
            {
                MessageBox.Show(window, "Greska u konekciji sa serverom");
            }
        }

        public void DodajSkoluProzor()
        {
            try
            {

                Window w = new ProzorSkola();
                w.DataContext = new DodajNovuSkoluViewModel() { Window = w, Korisnik = this.korisnik };
                w.Show();
            }
            catch
            {
                MessageBox.Show(window, "Greska u konekciji sa serverom");
            }
        }

        #region pretraga
        public ICommand TraziSkoluKomanda
        {
            get;
            private set;
        }

        public bool CanSearchSchool
        {
            get
            {
                if (SearchText == null && (CheckBoxes[0] || CheckBoxes[1]))
                {
                    return false;
                }
                return true;
            }
        }


        public void SearchSchool()
        {
            try
            {
                BindingList<AutoSkola> TempList = new BindingList<AutoSkola>();
                if (CheckBoxes[0])
                    foreach (var sk in BindingSkola)
                    {
                        string s = sk.naziv;
                        s.Replace(" ", string.Empty);
                        if (s.Contains(SearchText))
                        {
                            TempList.Add(sk);
                        }
                    }   
                else if (CheckBoxes[1])
                    foreach (var sk in BindingSkola)
                    {
                        string s = sk.MBR;
                        s.Replace(" ", string.Empty);
                        if (s.Contains(SearchText))
                        {
                            TempList.Add(sk);
                        }
                    }

                BindingSkola = TempList;
            }
            catch
            {
                MessageBox.Show(window, "Greska u konekciji sa serverom");
            }
        }

        private bool[] checkBoxs = new bool[2] { false, false };

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
        #endregion
    }
}
