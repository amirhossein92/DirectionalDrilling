using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.UI.Base;
using Prism.Events;

namespace DirectionalDrilling.UI.Events
{
    public class OpenWindowForEditByViewModelEvent : PubSubEvent<ViewModelForEdit>
    {
    }

    public class ViewModelForEdit
    {
        public UserControlViewModelBase ViewModel { get; set; }
        public int Id { get; set; }

        public ViewModelForEdit(UserControlViewModelBase viewModel, int id)
        {
            ViewModel = viewModel;
            Id = id;
        }
    }
}
