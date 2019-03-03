using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Events;
using Ninject;
using Ninject.Parameters;
using Prism.Events;

namespace DirectionalDrilling.UI.WindowManagement
{
    public class WindowManagementService : IWindowManagementService
    {
        private IEventAggregator _eventAggregator;
        private IKernel _kernel;
        private List<UserControlViewModelBase> _viewModels = new List<UserControlViewModelBase>();
        private List<UserControlViewModelBase> _editViewModels = new List<UserControlViewModelBase>();

        public WindowManagementService(IEventAggregator eventAggregator,
            IKernel kernel)
        {
            _eventAggregator = eventAggregator;
            _kernel = kernel;
        }

        public void OpenWindowByViewModel<T>(int selectedSurveyId) where T : UserControlViewModelBase
        {
            //var viewModel = _kernel.Get<T>(new ConstructorArgument("selectedSurveyId", selectedSurveyId));
            var viewModel = _kernel.Get<T>();
            _eventAggregator.GetEvent<OpenWindowByViewModelEvent>().Publish(viewModel);
        }

        public void OpenWindowByViewModel<T>() where T : UserControlViewModelBase
        {
            T viewModel;
            if (_viewModels.Any(item => item.GetType() == typeof(T)))
            {
                viewModel = (T)_viewModels.FirstOrDefault(item => item.GetType() == typeof(T));
            }
            else
            {
                viewModel = _kernel.Get<T>();
            }
            _eventAggregator.GetEvent<OpenWindowByViewModelEvent>().Publish(viewModel);

        }

        public void OpenWindowForEditByViewModel<T>(int id) where T : UserControlViewModelBase
        {
            var viewModel = _kernel.Get<T>();
            _eventAggregator.GetEvent<OpenWindowForEditByViewModelEvent>().Publish(new ViewModelForEdit(viewModel, id));

        }
    }
}
