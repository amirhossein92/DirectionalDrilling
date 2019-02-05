using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Grid;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.DataAccess.Survey;
using DirectionalDrilling.DataAccess.SurveyItem;
using DirectionalDrilling.Model;
using DirectionalDrilling.Model.Models;
using DirectionalDrilling.UI.Commands;
using DirectionalDrilling.UI.Events;
using Prism.Events;

namespace DirectionalDrilling.UI.ViewModels
{
    public class SurveyItemGridViewModel : NotifyPropertyChanged
    {
        private UnitOfWork _unitOfWork;
        private ISurveyItemService _surveyItemService;
        private ISurveyService _surveyService;
        private ObservableCollection<SurveyItem> _surveyItems = new ObservableCollection<SurveyItem>();
        private SurveyItem _surveyItem;
        private int _selectedSurveyId;
        private MainWindowViewModel _mainWindowViewModel;
        private IEventAggregator _eventAggregator;
        private string _surveyDescription = String.Empty;

        public SurveyItemGridViewModel(MainWindowViewModel mainWindowViewModel, IEventAggregator eventAggregator)
        {
            _unitOfWork = new UnitOfWork();
            _surveyItemService = _unitOfWork.SurveyItemService;
            _surveyService = _unitOfWork.SurveyService;
            _mainWindowViewModel = mainWindowViewModel;
            _selectedSurveyId = mainWindowViewModel.SelectedSurveyId;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<TreeListSelectionChangeEvent>().Subscribe(RefreshData);
        }

        private void RefreshData(int selectedSurveyId)
        {
            LoadSurveyItems(selectedSurveyId);
            SurveyDescription = _surveyService.GetSurveyDescription(selectedSurveyId);
        }
        private void LoadSurveyItems(int selectedSurveyId)
        {
            _surveyItems.Clear();
            foreach (var surveyItem in _surveyItemService.GetSurveyItems().Where(item => item.SurveyId == selectedSurveyId))
            {
                _surveyItems.Add(surveyItem);
            }
        }

        public SurveyItem SurveyItem { get => _surveyItem; }
        public ObservableCollection<SurveyItem> SurveyItems
        {
            get => _surveyItems;
            set
            {
                _surveyItems = value;
                OnPropertyChanged();
            }
        }
        public string SurveyDescription
        {
            get => _surveyDescription;
            set
            {
                _surveyDescription = value;
                OnPropertyChanged();
            }
        }

    }
}
