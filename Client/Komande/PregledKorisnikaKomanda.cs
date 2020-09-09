using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    class PregledKorisnikaKomanda : ICommand
    {
        private PocetnaViewModel model;

        public PregledKorisnikaKomanda(PocetnaViewModel p)
        {
            this.model = p;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            model.PogledajKorisnika();
        }
    }
}
