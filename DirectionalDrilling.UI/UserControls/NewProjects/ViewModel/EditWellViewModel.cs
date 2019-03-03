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
using DirectionalDrilling.UI.UserControls.NewProjects.View;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI.UserControls.NewProjects.ViewModel
{
    class EditWellViewModel : UserControlViewModelBase, IEdittableUserControlViewModel
    {
        private IUnitOfWork _unitOfWork;
        private Well _well;
        private ObservableCollection<Platform> _platforms;

        public EditWellViewModel(EditWellView editWellView,
            IUnitOfWork unitOfWork)
        {
            UserControlView = editWellView;
            _unitOfWork = unitOfWork;
            GetWell();
            GetPlatforms();

            SaveCommand = new RelayCommand(OnSaveCommand);
            CancelCommand = new RelayCommand(OnCancel);
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public ObservableCollection<Platform> Platforms
        {
            get => _platforms;
            set => SetProperty(ref _platforms, value);
        }
        public Well Well
        {
            get => _well;
            set => SetProperty(ref _well, value);
        }
        
        public void LoadData(int selectedId)
        {
            Well = _unitOfWork.WellService.GetWellById(selectedId);
            SelectedId = selectedId;
            ObjectName = Well.Name;
        }

        public string ObjectName { get; set; }
        public int SelectedId { get; set; }

        private void GetWell()
        {
            Well = new Well { Name = "Well Jadid" };
        }

        private void GetPlatforms()
        {
            Platforms = new ObservableCollection<Platform>(_unitOfWork.PlatformService.GetPlatforms());
        }

        private void OnSaveCommand()
        {
            _unitOfWork.WellService.Update(Well);
            RefreshTreeListData();
            CloseTab();
        }

        private void OnCancel()
        {
            CloseTab();
        }

    }
}
