using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    class DodajProzorNoveSkoleKomanda : ICommand
    {
        private PocetnaViewModel model;
        public DodajProzorNoveSkoleKomanda(PocetnaViewModel m)
        {
            this.model = m;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return model.MozeliDodati;
        }

        public void Execute(object parameter)
        {
            model.DodajSkoluProzor();
        }
    }
}
