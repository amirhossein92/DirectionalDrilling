using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DirectionalDrilling.UI.Commands
{
    public class RelayCommand : ICommand
    {
        private Action _targetExecuteMethod;
        private Func<bool> _targetCanExecuteMethod;

        public RelayCommand(Action targetExecuteMethod)
        {
            _targetExecuteMethod = targetExecuteMethod;
        }

        public RelayCommand(Action targetExecuteMethod, Func<bool> targetCanExecuteMethod)
        {
            _targetExecuteMethod = targetExecuteMethod;
            _targetCanExecuteMethod = targetCanExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            if (_targetCanExecuteMethod != null)
                return _targetCanExecuteMethod();
            if (_targetExecuteMethod != null)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            if (_targetExecuteMethod != null)
                _targetExecuteMethod();

        }

        public event EventHandler CanExecuteChanged;
    }
}
