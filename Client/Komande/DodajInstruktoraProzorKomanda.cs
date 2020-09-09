using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    public class DodajInstruktoraProzorKomanda : ICommand
    {

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

        private PrikaziInstruktoreViewModel smtwm;

        public DodajInstruktoraProzorKomanda(PrikaziInstruktoreViewModel smtwm)
        {
            this.smtwm = smtwm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            smtwm.DodajInstruktoraProzor();
        }
    }
}
