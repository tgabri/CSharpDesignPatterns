﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetAcademia_CommandWPF
{
    public class SajatParancs : ICommand
    {
        private Action<object> execute = null;
        private Func<object, bool> canExecute = null;

        public SajatParancs(Action<object> execute)
        {
            this.execute = execute;
        }

        public SajatParancs(Action<object> execute, Func<object, bool> canExecute) : this(execute)
        {
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }



        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
