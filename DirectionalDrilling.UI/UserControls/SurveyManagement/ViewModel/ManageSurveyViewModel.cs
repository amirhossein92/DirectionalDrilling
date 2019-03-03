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
using DirectionalDrilling.UI.UserControls.SurveyManagement.View;
using Prism.Events;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI.UserControls.SurveyManagement.ViewModel
{
    public class ManageSurveyViewModel : UserControlViewModelBase, IEdittableUserControlViewModel
    {
        private string _header;
        private IUnitOfWork _unitOfWork;
        private ObservableCollection<SurveyItem> _surveyItems = new ObservableCollection<SurveyItem>();
        private MainWindowViewModel _mainWindowViewModel;
        private IEventAggregator _eventAggregator;
        private string _surveyDescription = String.Empty;
        private int _selectedSurveyId;
        private bool _isReadOnly = true;
        private SurveyItem _selectedSurveyItem;

        public ManageSurveyViewModel(ManageSurveyView manageSurveyView,
            IUnitOfWork unitOfWork)
        {
            UserControlView = manageSurveyView;
            _unitOfWork = unitOfWork;

            AddRow = new RelayCommand(OnAddRow, CanAddRow);
            DeleteRow = new RelayCommand(OnDeleteRow, CanDeleteRow);
            Calculate = new RelayCommand(OnCalculate);
            SaveCommand = new RelayCommand(OnSaveCommand, CanSave);
            InterpolateCommand = new RelayCommand(OnInterpolate);
        }


        public RelayCommand AddRow { get; private set; }
        public RelayCommand DeleteRow { get; private set; }
        public RelayCommand Calculate { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand InterpolateCommand { get; private set; }

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
        public int SelectedSurveyId
        {
            get => _selectedSurveyId;
            set => SetProperty(ref _selectedSurveyId, value);
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


        private string _interpolationMD;
        public string InterpolationMD
        {
            get => _interpolationMD;
            set => SetProperty(ref _interpolationMD, value);
        }

        private string _interpolationTVD;
        public string InterpolationTVD
        {
            get => _interpolationTVD;
            set => SetProperty(ref _interpolationTVD, value);
        }

        private void OnInterpolate()
        {
            double Md = Double.Parse(InterpolationMD);
            InterpolationTVD = _unitOfWork.SurveyService.InterpolateByMdToTvd(SelectedSurveyId, Md);
        }


        public void LoadData(int selectedSurveyId)
        {
            _selectedSurveyId = selectedSurveyId;
            LoadSurveyItems(_selectedSurveyId);
            SurveyDescription = _unitOfWork.SurveyService.GetSurveyDescription(_selectedSurveyId);
            Header = _selectedSurveyId.ToString();
            SelectedId = selectedSurveyId;
            ObjectName = _unitOfWork.SurveyService.GetSurveyById(selectedSurveyId).Name;
        }

        public string ObjectName { get; set; }
        public int SelectedId { get; set; }

        private void LoadSurveyItems(int selectedSurveyId)
        {
            _surveyItems.Clear();
            foreach (var surveyItem in _unitOfWork.SurveyItemService.GetSurveyItems().Where(item => item.SurveyId == selectedSurveyId))
            {
                _surveyItems.Add(surveyItem);
            }
        }

        public void ChangeGridEdittable(bool canEdit)
        {
            if (canEdit)
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
            SaveCommand.RaiseCanExecuteChanged();
        }
        private void OnDeleteRow()
        {
            // TODO: Remove from database too!
            SurveyItems.Remove(SelectedSurveyItem);
        }

        private bool CanSave()
        {
            return (SurveyItems != null) && (SurveyItems.Count > 0);
        }

        private void OnSaveCommand()
        {
            foreach (var surveyItem in SurveyItems)
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
            // TODO: Implement Calculate Button
            _unitOfWork.SurveyService.MinimumCurvatureMethod(_selectedSurveyId);
        }
        }
}
