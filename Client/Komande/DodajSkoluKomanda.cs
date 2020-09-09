using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    public class DodajSkoluKomanda : ICommand
    {
        private DodajNovuSkoluViewModel model;

        public DodajSkoluKomanda(DodajNovuSkoluViewModel m)
        {
            this.model = m;
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
            return this.model.MozeliNovaSkola;
        }

        public void Execute(object parameter)
        {
            this.model.DodajSkolu();
        }
    }
}
