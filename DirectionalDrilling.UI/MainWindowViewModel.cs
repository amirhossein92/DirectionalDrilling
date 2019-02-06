using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Mvvm;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.Model;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using DirectionalDrilling.UI.Events;
using DirectionalDrilling.UI.UserControls.Dashboard;
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
            _unitOfWork = new UnitOfWork();

            _surveySelectionTreeListViewModel = new SurveySelectionTreeListViewModel(_eventAggregator, _unitOfWork);
            TreeListViewModel = _surveySelectionTreeListViewModel;
            _dashboardViewModel = new DashboardViewModel();
            CurrentViewModels = new ObservableCollection<TabItemBase>();
            _currentViewModel = new TabItemBase("Dashboard", _dashboardViewModel);
            CreateNewTabFromViewModel("Dashboard", _dashboardViewModel);

            AddPlatform = new RelayCommand(OnAddPlatform);
            AddWell = new RelayCommand(OnAddWell);
            ManageSurvey = new RelayCommand(OnManageSurvey);
        }


        private void OnSurveySelectionChanged(int selectedSurveyId)
        {
            _selectedSurveyId = selectedSurveyId;
            OnManageSurvey();
        }

        public RelayCommand AddPlatform { get; private set; }
        public RelayCommand AddWell { get; private set; }
        public RelayCommand ManageSurvey { get; private set; }
        public IUserControlViewModel TreeListViewModel
        {
            get => _treeListViewModel;
            set => SetProperty(ref _treeListViewModel, value);
        }
        public ObservableCollection<TabItemBase> CurrentViewModels { get; private set; }
        public TabItemBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
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

        private void OnManageSurvey()
        {
            _manageSurveyViewModel = new ManageSurveyViewModel(_selectedSurveyId, _unitOfWork);
            _manageSurveyViewModel.LoadData();
            CreateNewTabFromViewModel("Manage Survey", _manageSurveyViewModel);
        }

        private void CreateNewTabFromViewModel(string header, IUserControlViewModel currentViewModel)
        {
            CurrentViewModels.Add(new TabItemBase(header, currentViewModel));
            CurrentViewModel.Content = currentViewModel ;
            CurrentViewModel.Header = header;}}
}