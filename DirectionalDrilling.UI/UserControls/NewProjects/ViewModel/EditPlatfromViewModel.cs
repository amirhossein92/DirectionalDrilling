using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Mvvm.POCO;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.Model.Models;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using DirectionalDrilling.UI.Events;
using DirectionalDrilling.UI.UserControls.NewProjects.View;
using Prism.Events;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI.UserControls.NewProjects.ViewModel
{
    class EditPlatfromViewModel : UserControlViewModelBase, IEdittableUserControlViewModel
    {
        private IUnitOfWork _unitOfWork;
        private Platform _platform;
        //private IEventAggregator _eventAggregator;

        public EditPlatfromViewModel(EditPlatfromView editPlatfromView,
            IUnitOfWork unitOfWork,
            IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            UserControlView = editPlatfromView;
            _unitOfWork = unitOfWork;
            GetPlatform();

            SaveCommand = new RelayCommand(OnSaveCommand, CanSave);
            CancelCommand = new RelayCommand(OnCancelCommand);
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public Platform Platform
        {
            get => _platform;
            set => SetProperty(ref _platform, value);
        }

        private void GetPlatform()
        {
            Platform = new Platform{Name = "Platform Jadid"};
        }

        public void LoadData(int selectedId)
        {
            Platform = _unitOfWork.PlatformService.GetPlatformById(selectedId);
            SelectedId = selectedId;
            ObjectName = Platform.Name;
        }

        public string ObjectName { get; set; }
        public int SelectedId { get; set; }

        private void OnCancelCommand()
        {
            CloseTab();
        }

        private bool CanSave()
        {
            return Platform.Name != null;
        }

        private void OnSaveCommand()
        {
            if (Platform.Id != 0)
            {
                _unitOfWork.PlatformService.Update(Platform);
            }

            CloseTab();
            RefreshTreeListData();
        }
    }
}