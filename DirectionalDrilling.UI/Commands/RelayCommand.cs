using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Properties;

namespace DirectionalDrilling.UI.Commands
{
    public class RelayCommand : DelegateCommand
    {
        public RelayCommand(Action executeMethod) : base(executeMethod)
        {
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod) : base(executeMethod, canExecuteMethod)
        {
        }
    }
}
