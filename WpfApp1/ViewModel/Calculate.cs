using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.ViewModel
{
    internal class Calculate : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public Calculate(Action<object?> execute, Predicate<object?> canExecute)
        {
            _execute = execute;
            _canexecute = canExecute;
        }
        private readonly Action<object?> _execute;
        private readonly Predicate<object?>? _canexecute;

        public bool CanExecute(object? parameter)
        {
            return _canexecute == null || _canexecute.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}

