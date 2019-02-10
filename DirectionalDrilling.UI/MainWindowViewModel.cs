using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Mask;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.Model;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using DirectionalDrilling.UI.Events;
using DirectionalDrilling.UI.UserControls.Dashboard;
using DirectionalDrilling.UI.UserControls.Graph.ViewModel;
using DirectionalDrilling.UI.UserControls.NewProjects.ViewModel;
using DirectionalDrilling.UI.UserControls.SurveyManagement.ViewModel;
using DirectionalDrilling.UI.UserControls.SurveySelectionTreeList;
using Prism.Events;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI
{
    public class MainWindowViewModel : BindableBase
    {
        private ManageSurveyViewModel _manageSurveyViewModel;
        private SurveySelectionTreeListViewModel _surveySelectionTreeListViewModel;
        private AddPlatfromViewModel _addPlatfromViewModel;
        private AddWellViewModel _addWellViewModel;
        private DashboardViewModel _dashboardViewModel;
        private NewSurveyViewModel _newSurveyViewModel;
        private SectionViewModel _sectionViewModel;
        private ImportSurveyViewModel _importSurveyViewModel;

        private IUserControlViewModel _treeListViewModel;
        private ObservableCollection<TabItemBase> _currentViewModels;
        private TabItemBase _currentViewModel = new TabItemBase();
        private bool _isGridEdittable;

        private UnitOfWork _unitOfWork;
        private IEventAggregator _eventAggregator;

        private int _selectedSurveyId;

        public MainWindowViewModel()
        {
            _eventAggregator = new EventAggregator();
            _eventAggregator.GetEvent<TreeListSelectionChangeEvent>().Subscribe(OnSurveySelectionChanged);
            _eventAggregator.GetEvent<CloseTabEvent>().Subscribe(CloseSelectedTab);
            _unitOfWork = new UnitOfWork();

            AddPlatform = new RelayCommand(OnAddPlatform);
            AddWell = new RelayCommand(OnAddWell);
            NewSurvey = new RelayCommand(OnNewSurvey);
            ImportSurvey = new RelayCommand(OnImportSurvey, CanImportSurvey);
            ManageSurvey = new RelayCommand(OnManageSurvey);
            SectionView = new RelayCommand(OnSectionView, CanOpenSectionView);
            CloseTab = new RelayCommand(OnCloseTab);

            _surveySelectionTreeListViewModel = new SurveySelectionTreeListViewModel(_eventAggregator, _unitOfWork);
            TreeListViewModel = _surveySelectionTreeListViewModel;
            _dashboardViewModel = new DashboardViewModel();
            CurrentViewModels = new ObservableCollection<TabItemBase>();
            //_currentViewModel = new TabItemBase("Dashboard", _dashboardViewModel);
            CreateNewTabFromViewModel("Dashboard", _dashboardViewModel);
        }


        private void OnCloseTab()
        {
            throw new NotImplementedException();
        }

        private void CloseSelectedTab()
        {
            CurrentViewModels.Remove(CurrentViewModel);
        }

        private void OnSurveySelectionChanged(int selectedSurveyId)
        {
            _selectedSurveyId = selectedSurveyId;
            OnManageSurvey();
        }

        public RelayCommand AddPlatform { get; private set; }
        public RelayCommand AddWell { get; private set; }
        public RelayCommand NewSurvey { get; private set; }
        public RelayCommand ImportSurvey { get; private set; }
        public RelayCommand ManageSurvey { get; private set; }
        public RelayCommand SectionView { get; private set; }

        public RelayCommand CloseTab { get; private set; }

        public IUserControlViewModel TreeListViewModel
        {
            get => _treeListViewModel;
            set => SetProperty(ref _treeListViewModel, value);
        }

        public ObservableCollection<TabItemBase> CurrentViewModels { get; private set; }

        public TabItemBase CurrentViewModel
        {
            get
            {
                if (_currentViewModel.Content.GetType() != typeof(ManageSurveyViewModel))
                {
                    _selectedSurveyId = 0;
                }
                else
                {
                    _selectedSurveyId = ((ManageSurveyViewModel)_currentViewModel.Content).SelectedSurveyId;
                }
                SectionView.RaiseCanExecuteChanged();
                ImportSurvey.RaiseCanExecuteChanged();
                return _currentViewModel;
            }
            set
            {
                SetProperty(ref _currentViewModel, value);
                if (value.Content.GetType() != typeof(ManageSurveyViewModel))
                {
                    _selectedSurveyId = 0;
                }
                else
                {
                    _selectedSurveyId = ((ManageSurveyViewModel)_currentViewModel.Content).SelectedSurveyId;
                }
                SectionView.RaiseCanExecuteChanged();
                ImportSurvey.RaiseCanExecuteChanged();
            }
        }

        public bool IsGridEdittable
        {
            get => _isGridEdittable;
            set
            {
                SetProperty(ref _isGridEdittable, value);
                _manageSurveyViewModel.ChangeGridEdittable(value);
            }
        }

        private void OnAddPlatform()
        {
            _addPlatfromViewModel = new AddPlatfromViewModel(_unitOfWork);
            CreateNewTabFromViewModel("Add Platform", _addPlatfromViewModel);
        }

        private void OnAddWell()
        {
            _addWellViewModel = new AddWellViewModel(_unitOfWork);
            CreateNewTabFromViewModel("Add Well", _addWellViewModel);
        }

        private void OnNewSurvey()
        {
            _newSurveyViewModel = new NewSurveyViewModel(_unitOfWork, _eventAggregator);
            CreateNewTabFromViewModel("Add Survey", _newSurveyViewModel);
        }

        private bool CanImportSurvey()
        {
            // TODO: Update can import
            return _selectedSurveyId != 0;
        }

        private void OnImportSurvey()
        {
            _importSurveyViewModel = new ImportSurveyViewModel(_selectedSurveyId, _unitOfWork);
            CreateNewTabFromViewModel("Import Survey", _importSurveyViewModel);
        }

        private void OnManageSurvey()
        {
            _manageSurveyViewModel = new ManageSurveyViewModel(_selectedSurveyId, _unitOfWork);
            _manageSurveyViewModel.LoadData();
            CreateNewTabFromViewModel("Manage Survey", _manageSurveyViewModel);
            SectionView.RaiseCanExecuteChanged();
        }

        private bool CanOpenSectionView()
        {
            return _selectedSurveyId != 0;
        }

        private void OnSectionView()
        {
            _sectionViewModel = new SectionViewModel();
            CreateNewTabFromViewModel("Section View", _sectionViewModel);
        }

        private void CreateNewTabFromViewModel(string header, BindableBase currentViewModel)
        {
            CurrentViewModel = new TabItemBase
            {
                Content = currentViewModel,
                Header = header
            };
            CurrentViewModels.Add(CurrentViewModel);
           
        }
    }
}