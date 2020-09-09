using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    public class OdjavaKomanda : ICommand
    {
        private PocetnaViewModel model;

        public OdjavaKomanda(PocetnaViewModel m)
        {
            model = m;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.model.OdjaviSe();
        }
    }
}
