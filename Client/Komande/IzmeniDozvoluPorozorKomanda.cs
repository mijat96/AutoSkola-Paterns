﻿using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Komande
{
    class IzmeniDozvoluPorozorKomanda : ICommand
    {
        private DozvoleWievModel model;

        public IzmeniDozvoluPorozorKomanda(DozvoleWievModel m)
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
            return model.CanChangeRazredWindow;
        }

        public void Execute(object parameter)
        {
            model.ChangeRazredWindow();
        }
    }
}
