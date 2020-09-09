using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    class IzmeniSkoluProzorKomanda : ICommand
    {
        private PocetnaViewModel model;

        public IzmeniSkoluProzorKomanda(PocetnaViewModel m)
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
            return model.MozeliSeIzmeniti;
        }

        public void Execute(object parameter)
        {
            model.IzmeniSkolu();
        }
    }
}
