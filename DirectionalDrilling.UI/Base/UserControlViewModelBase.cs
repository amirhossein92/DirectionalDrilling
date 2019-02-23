using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.UI.Base
{
    public abstract class UserControlViewModelBase : Prism.Mvvm.BindableBase
    {
        public UserControlViewModelBase()
        {
        }

        private UserControlViewBase _userControlView;
        public UserControlViewBase UserControlView
        {
            get => _userControlView;
            set
            {
                SetProperty(ref _userControlView, value);
                _userControlView.DataContext = this;
                _userControlView.Instantiated();
            }
        }


    }
}
