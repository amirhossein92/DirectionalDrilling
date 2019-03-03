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
using DirectionalDrilling.UI.UserControls.SurveyManagement.View;
using Prism.Events;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI.UserControls.SurveyManagement.ViewModel
{
    class EditSurveyViewModel : UserControlViewModelBase, IEdittableUserControlViewModel
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

        public EditSurveyViewModel(EditSurveyView view,
            IUnitOfWork unitOfWork,
            IEventAggregator eventAggregator)
        {
            UserControlView = view;
            _unitOfWork = unitOfWork;
            EventAggregator = eventAggregator;
            GetPlatforms();
            _eventAggregator = eventAggregator;

            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }



        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CancelCommand { get; private set; }

        public void LoadData(int selectedId)
        {
            Survey = _unitOfWork.SurveyService.GetSurveyById(selectedId);
            SurveyTieIn = Survey.SurveyTieIn;
            SelectedWellboreId = Survey.WellboreId;
            SelectedWellId = Survey.Wellbore.WellId;
            SelectedPlatformId = Survey.Wellbore.Well.PlatformId;
            SelectedId = selectedId;
            ObjectName = Survey.Name;

        }

        public string ObjectName { get; set; }
        public int SelectedId { get; set; }

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


        private void OnCancel()
        {
            CloseTab();
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
            _unitOfWork.SurveyService.Update(Survey);

            CloseTab();
            RefreshTreeListData();
        }

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
    }
}
