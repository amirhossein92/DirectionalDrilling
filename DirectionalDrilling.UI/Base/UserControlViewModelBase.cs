using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.UI.Events;
using Humanizer;
using Prism.Events;

namespace DirectionalDrilling.UI.Base
{
    public abstract class UserControlViewModelBase : Prism.Mvvm.BindableBase
    {
        protected IEventAggregator EventAggregator;
        
        private UserControlViewBase _userControlView;
        public UserControlViewBase UserControlView
        {
            get => _userControlView;
            protected set
            {
                SetProperty(ref _userControlView, value);
                _userControlView.DataContext = this;
                _userControlView.Instantiated();
            }
        }

        protected void CloseTab()
        {
            EventAggregator.GetEvent<CloseTabEvent>().Publish();
        }

        protected void RefreshTreeListData()
        {
            EventAggregator.GetEvent<TreeListDataChangedEvent>().Publish();
        }

    }
}
