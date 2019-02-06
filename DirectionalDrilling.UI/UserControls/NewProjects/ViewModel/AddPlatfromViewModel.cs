using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Data.Filtering.Helpers;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.Model.Models;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI.UserControls.NewProjects.ViewModel
{
    class AddPlatfromViewModel : BindableBase, IUserControlViewModel
    {
        private UnitOfWork _unitOfWork;
        private Platform _platform;

        public AddPlatfromViewModel(UnitOfWork unitOfWork)
        {
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

        private void OnCancelCommand()
        {
            throw new NotImplementedException();
        }

        private bool CanSave()
        {
            return Platform.Name != null;
        }

        private void OnSaveCommand()
        {
            _unitOfWork.PlatformService.Add(Platform);
            
        }

    }
}
