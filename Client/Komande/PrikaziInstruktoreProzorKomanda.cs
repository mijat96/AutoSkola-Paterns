using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    class PrikaziInstruktoreProzorKomanda : ICommand
    {
        private PocetnaViewModel model;

        public PrikaziInstruktoreProzorKomanda(PocetnaViewModel m)
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
            return model.ProzorInstruktori;
        }

        public void Execute(object parameter)
        {
            this.model.PrikaziInstruktoreProzor();
        }
    }
}
