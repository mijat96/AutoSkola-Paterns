using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    class DodajNovogKorisnikaKomanda : ICommand
    {
        private PocetnaViewModel pocetna;

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

        public DodajNovogKorisnikaKomanda(PocetnaViewModel model)
        {
            this.pocetna = model;
        }

        public bool CanExecute(object parameter)
        {
            return pocetna.TypeOfUser;
        }

        public void Execute(object parameter)
        {
            pocetna.DodajKorisnika();
        }
    }
}
