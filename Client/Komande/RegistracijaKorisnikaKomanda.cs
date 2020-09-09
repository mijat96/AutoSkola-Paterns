using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    class RegistracijaKorisnikaKomanda : ICommand
    {
        DodajKorisnikaViewModel dodajKorisnikaViewModel;

        public RegistracijaKorisnikaKomanda(DodajKorisnikaViewModel dodaj)
        {
            this.dodajKorisnikaViewModel = dodaj;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }


        public bool CanExecute(object parameter)
        {
            return dodajKorisnikaViewModel.ProveraKorisnika;
        }

        public void Execute(object parameter)
        {
            dodajKorisnikaViewModel.Dodaj();
        }
    }
}
