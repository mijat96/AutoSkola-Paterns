using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    class DodajInstruktoraKomanda : ICommand
    {
        private DodajInstruktoreViewModel model;

        public DodajInstruktoraKomanda(DodajInstruktoreViewModel m)
        {
            model = m;
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
            return model.CanAddInstruktora;
        }

        public void Execute(object parameter)
        {
            model.DodajInstruktora();
        }
    }
}
