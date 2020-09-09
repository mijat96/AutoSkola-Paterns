using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    class IzmeniInstruktora : ICommand
    {
        private ProzorIzmeneInstruktoraViewModel model;

        public IzmeniInstruktora(ProzorIzmeneInstruktoraViewModel m)
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
            return this.model.CanChangeRa;
        }

        public void Execute(object parameter)
        {
            this.model.ChangeCurrentRa();
        }
    }
}
