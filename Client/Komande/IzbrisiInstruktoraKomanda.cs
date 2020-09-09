using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    class IzbrisiInstruktoraKomanda : ICommand
    {
        private PrikaziInstruktoreViewModel model;

        public IzbrisiInstruktoraKomanda(PrikaziInstruktoreViewModel m)
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
            return this.model.CanDeleteRa;
        }

        public void Execute(object parameter)
        {
            this.model.DeleteCurentRa();
        }
    }
}
