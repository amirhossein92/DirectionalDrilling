using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DevExpress.Mvvm.POCO;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.Model.Models;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using DirectionalDrilling.UI.UserControls.NewProjects.View;
using Prism.Events;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI.UserControls.NewProjects.ViewModel
{
    class EditWellboreViewModel : UserControlViewModelBase, IEdittableUserControlViewModel
    {
        private IUnitOfWork _unitOfWork;

        public EditWellboreViewModel(EditWellboreView editWellboreView,
            IUnitOfWork unitOfWork,
            IEventAggregator eventAggregator)
        {
            UserControlView = editWellboreView;
            _unitOfWork = unitOfWork;
            EventAggregator = eventAggregator;

            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);

            GetPlatforms();
            GetWells();
            GetWellbore();
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        private Wellbore _wellbore;
        public Wellbore Wellbore
        {
            get => _wellbore;
            set => SetProperty(ref _wellbore, value);
        }

        private ObservableCollection<Well> _wells;
        public ObservableCollection<Well> Wells
        {
            get => _wells;
            set => SetProperty(ref _wells, value);
        }

        private ObservableCollection<Platform> _platforms;
        public ObservableCollection<Platform> Platforms
        {
            get => _platforms;
            set => SetProperty(ref _platforms, value);
        }

        private int _selectedPlatformId;
        public int SelectedPlatformId
        {
            get => _selectedPlatformId;
            set
            {
                SetProperty(ref _selectedPlatformId, value);
                GetWells();
            }
        }

        public void LoadData(int selectedId)
        {
            Wellbore = _unitOfWork.WellboreService.GetWellboreById(selectedId);
            SelectedPlatformId = Wellbore.Well.PlatformId;
            SelectedId = selectedId;
            ObjectName = Wellbore.Name;

        }

        public string ObjectName { get; set; }
        public int SelectedId { get; set; }

        private void GetPlatforms()
        {
            Platforms = new ObservableCollection<Platform>(_unitOfWork.PlatformService.GetPlatforms());
        }

        private void GetWells()
        {
            Wells = new ObservableCollection<Well>(_unitOfWork.WellService.GetWellsByPlatformId(SelectedPlatformId));
        }

        private void GetWellbore()
        {
            Wellbore = new Wellbore { Name = "Wellbore Jadid" };
            Wellbore.PropertyChanged += WellboreOnPropertyChanged;
        }

        private void WellboreOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private bool CanSave()
        {
            return Wellbore.Name != null && Wellbore.WellId != 0;
        }

        private void OnSave()
        {
            _unitOfWork.WellboreService.Update(Wellbore);

            CloseTab();
            RefreshTreeListData();

        }

        private void OnCancel()
        {
            CloseTab();
        }

    }
}
