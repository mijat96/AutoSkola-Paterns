using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    public class PrijavaKomanda : ICommand
    {
        private MainWindowViewModel model;

        public PrijavaKomanda(MainWindowViewModel m)
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
            return model.DozvoljenaPrijava;
        }

        public void Execute(object parameter)
        {
            model.Prijavi();
        }
    }
}
