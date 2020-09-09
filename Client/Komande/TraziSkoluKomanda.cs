using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    public class TraziSkoluKomanda : ICommand
    {
        private PocetnaViewModel model;

        public TraziSkoluKomanda(PocetnaViewModel hwvm)
        {
            this.model = hwvm;
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
            return model.CanSearchSchool;
        }

        public void Execute(object parameter)
        {
            model.SearchSchool();
        }
    }
}
