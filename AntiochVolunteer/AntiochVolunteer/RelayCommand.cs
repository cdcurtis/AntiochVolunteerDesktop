using System;
using System.Diagnostics;
using System.Windows.Input;

namespace AntiochVolunteer
{

    public class RelayCommand : ICommand
    {   
        private readonly Action _execute;

        private readonly Func<bool> _canExecute;
 
        public RelayCommand(Action execute)
            : this(execute, null)
        { }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _execute();
        }
        public bool CanExecute(object parameter)
        {
            return (_canExecute == null)
            || _canExecute();
        }
        public event EventHandler CanExecuteChanged = delegate { };
        public void RaiseCanExecuteChanged()
        { CanExecuteChanged(this, new EventArgs()); }
    }
}
