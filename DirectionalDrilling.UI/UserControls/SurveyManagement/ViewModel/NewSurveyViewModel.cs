using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.Model.Models;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using DirectionalDrilling.UI.Events;
using Prism.Events;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI.UserControls.SurveyManagement.ViewModel
{
    class NewSurveyViewModel : UserControlViewModelBase
    {
        private IUnitOfWork _unitOfWork;
        private Survey _survey = new Survey();
        private SurveyTieIn _surveyTieIn = new SurveyTieIn();
        private ObservableCollection<Platform> _platforms;
        private ObservableCollection<Well> _wells;
        private ObservableCollection<Wellbore> _wellbores;
        private int _selectedPlatformId;
        private int _selectedWellId;
        private int _selectedWellboreId;
        private IEventAggregator _eventAggregator;

        public NewSurveyViewModel(IUnitOfWork unitOfWork, IEventAggregator eventAggregator)
        {
            _unitOfWork = unitOfWork;
            GetPlatforms();
            _eventAggregator = eventAggregator;

            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        private void GetWellbores()
        {
            Wellbores = new ObservableCollection<Wellbore>(
                _unitOfWork.WellboreService.GetWellboresByWellId(SelectedWellId));
        }

        private void GetWells()
        {
            Wells = new ObservableCollection<Well>(_unitOfWork.WellService.GetWellsByPlatformId(SelectedPlatformId));
        }

        private void GetPlatforms()
        {
            Platforms = new ObservableCollection<Platform>(_unitOfWork.PlatformService.GetPlatforms());
        }


        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public Survey Survey
        {
            get => _survey;
            set => SetProperty(ref _survey, value);
        }
        public SurveyTieIn SurveyTieIn
        {
            get => _surveyTieIn;
            set => SetProperty(ref _surveyTieIn, value);
        }
        public ObservableCollection<Platform> Platforms
        {
            get => _platforms;
            set => SetProperty(ref _platforms, value);
        }
        public ObservableCollection<Well> Wells
        {
            get => _wells;
            set => SetProperty(ref _wells, value);
        }
        public ObservableCollection<Wellbore> Wellbores
        {
            get => _wellbores;
            set => SetProperty(ref _wellbores, value);
        }
        public int SelectedPlatformId
        {
            get => _selectedPlatformId;
            set
            {
                SetProperty(ref _selectedPlatformId, value);
                GetWells();
            }
        }
        public int SelectedWellId
        {
            get => _selectedWellId;
            set
            {
                SetProperty(ref _selectedWellId, value);
                GetWellbores();
            }
        }
        public int SelectedWellboreId
        {
            get => _selectedWellboreId;
            set
            {
                SetProperty(ref _selectedWellboreId, value);
                SaveCommand.RaiseCanExecuteChanged();
            }
        }

        private void OnCancel()
        {
            _eventAggregator.GetEvent<CloseTabEvent>().Publish();
        }

        private bool CanSave()
        {
            // TODO: Can Save Function
            return (SelectedWellboreId != 0);
        }

        private void OnSave()
        {
            Survey.SurveyTieIn = SurveyTieIn;
            Survey.WellboreId = SelectedWellboreId;
            _unitOfWork.SurveyService.Add(Survey);
        }
    }
}
