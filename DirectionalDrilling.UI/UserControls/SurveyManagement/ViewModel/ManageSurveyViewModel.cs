using System;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Mvvm.POCO;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.DataAccess.Survey;
using DirectionalDrilling.DataAccess.SurveyItem;
using DirectionalDrilling.Model;
using DirectionalDrilling.Model.Models;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using DirectionalDrilling.UI.Events;
using Prism.Events;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI.UserControls.SurveyManagement.ViewModel
{
    public class ManageSurveyViewModel : BindableBase, IUserControlViewModel
    {
        private string _header;
        private UnitOfWork _unitOfWork;
        private ObservableCollection<SurveyItem> _surveyItems = new ObservableCollection<SurveyItem>();
        private MainWindowViewModel _mainWindowViewModel;
        private IEventAggregator _eventAggregator;
        private string _surveyDescription = String.Empty;
        private int _selectedSurveyId;
        private bool _isReadOnly = true;
        private SurveyItem _selectedSurveyItem;

        public ManageSurveyViewModel(int selectedSurveyId, UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _selectedSurveyId = selectedSurveyId;

            AddRow = new RelayCommand(OnAddRow, CanAddRow);
            DeleteRow = new RelayCommand(OnDeleteRow, CanDeleteRow);
            Calculate = new RelayCommand(OnCalculate);
            SaveCommand = new RelayCommand(OnSaveCommand, CanSave);
        }



        public RelayCommand AddRow { get; private set; }
        public RelayCommand DeleteRow { get; private set; }
        public RelayCommand Calculate { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public string Header
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }
        public ObservableCollection<SurveyItem> SurveyItems
        {
            get => _surveyItems;
            set => SetProperty(ref _surveyItems, value);
        }
        public string SurveyDescription
        {
            get => _surveyDescription;
            set => SetProperty(ref _surveyDescription, value);
        }
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set
            {
                SetProperty(ref _isReadOnly, value);
                DeleteRow.RaiseCanExecuteChanged();
                AddRow.RaiseCanExecuteChanged();
            }
        }
        public SurveyItem SelectedSurveyItem
        {
            get => _selectedSurveyItem;
            set
            {
                SetProperty(ref _selectedSurveyItem, value);
                DeleteRow.RaiseCanExecuteChanged();
            }
        }

        public void LoadData()
        {
            LoadSurveyItems(_selectedSurveyId);
            SurveyDescription = _unitOfWork.SurveyService.GetSurveyDescription(_selectedSurveyId);
            Header = _selectedSurveyId.ToString();
        }

        private void LoadSurveyItems(int selectedSurveyId)
        {
            _surveyItems.Clear();
            foreach (var surveyItem in _unitOfWork.SurveyItemService.GetSurveyItems().Where(item => item.SurveyId == selectedSurveyId))
            {
                _surveyItems.Add(surveyItem);
            }
        }

        public void ChangeGridEdittable(bool CanEdit)
        {
            if (CanEdit)
            {
                IsReadOnly = false;
            }
            else
            {
                IsReadOnly = true;
            }
        }

        private bool CanAddRow()
        {
            return !IsReadOnly;
        }

        private bool CanDeleteRow()
        {
            return !IsReadOnly && (SelectedSurveyItem != null);
        }

        private void OnAddRow()
        {
            var newSurveyItem = new SurveyItem();
            SurveyItems.Add(newSurveyItem);
        }
        private void OnDeleteRow()
        {
            SurveyItems.Remove(SelectedSurveyItem);
        }

        private bool CanSave()
        {
            return (_surveyItems != null) && (_surveyItems.Count > 0);
        }

        private void OnSaveCommand()
        {
            foreach (var surveyItem in _surveyItems)
            {
                if (surveyItem.SurveyId == 0)
                {
                    surveyItem.SurveyId = _selectedSurveyId;
                    _unitOfWork.SurveyItemService.Add(surveyItem);
                }
                else
                {
                    _unitOfWork.SurveyItemService.Update(surveyItem);
                }
            }
        }

        private void OnCalculate()
        {
            throw new NotImplementedException();
        }

    }
}
