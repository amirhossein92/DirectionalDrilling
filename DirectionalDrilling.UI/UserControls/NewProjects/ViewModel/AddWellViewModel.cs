using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.Model.Models;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI.UserControls.NewProjects.ViewModel
{
    class AddWellViewModel : UserControlViewModelBase
    {
        private IUnitOfWork _unitOfWork;
        private Well _well;
        private ObservableCollection<Platform> _platforms;

        public AddWellViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            GetWell();
            GetPlatforms();

            SaveCommand = new RelayCommand(OnSaveCommand);
        }

        private void GetWell()
        {
            Well = new Well {Name = "Well Jadid"};
        }

        public RelayCommand SaveCommand { get; private set; }

        private void GetPlatforms()
        {
            Platforms = new ObservableCollection<Platform>(_unitOfWork.PlatformService.GetPlatforms());
        }

        public Well Well
        {
            get => _well;
            set => SetProperty(ref _well, value);
        }

        private void OnSaveCommand()
        {
            _unitOfWork.WellService.Add(Well);

        }

        public ObservableCollection<Platform> Platforms
        {
            get => _platforms;
            set => SetProperty(ref _platforms, value);
        }
    }
}
