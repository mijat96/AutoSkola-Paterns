using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    class DuplirajSkoluKomanda : ICommand
    {
        private PocetnaViewModel hwvm;

        public DuplirajSkoluKomanda(PocetnaViewModel hwvm)
        {
            this.hwvm = hwvm;
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
            return this.hwvm.CanDuplicateSchool;
        }

        public void Execute(object parameter)
        {
            this.hwvm.DuplicateCurrentSchool();
        }
    }
}
