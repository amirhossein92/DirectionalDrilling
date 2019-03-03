using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using DevExpress.Data.Mask;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Printing;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.DataAccess.Report;
using DirectionalDrilling.DataAccess.Survey;
using DirectionalDrilling.Model;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using DirectionalDrilling.UI.Events;
using DirectionalDrilling.UI.UserControls.Dashboard;
using DirectionalDrilling.UI.UserControls.Graph.ViewModel;
using DirectionalDrilling.UI.UserControls.NewProjects.ViewModel;
using DirectionalDrilling.UI.UserControls.Schematic;
using DirectionalDrilling.UI.UserControls.SurveyManagement.ViewModel;
using DirectionalDrilling.UI.UserControls.SurveySelectionTreeList;
using DirectionalDrilling.UI.WindowManagement;
using Ninject;
using Ninject.Parameters;
using Prism.Commands;
using Prism.Events;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI
{
    public class MainWindowViewModel : UserControlViewModelBase
    {

        private ManageSurveyViewModel _manageSurveyViewModel;

        private IUnitOfWork _unitOfWork;
        private IEventAggregator _eventAggregator;
        private IWindowManagementService _windowManagementService;

        private int _selectedSurveyId;

        public MainWindowViewModel(MainWindow mainWindow,
            IUnitOfWork unitOfWork,
            IEventAggregator eventAggregator,
            IWindowManagementService windowManagementService)
        {
            MainWindow = mainWindow;
            _eventAggregator = eventAggregator;
            _windowManagementService = windowManagementService;
            _unitOfWork = unitOfWork;

            _eventAggregator.GetEvent<TreeListSelectionChangeEvent>().Subscribe(OnSurveySelectionChanged);
            _eventAggregator.GetEvent<TreeListDataChangedEvent>().Subscribe(OnTreeListDataChanged);
            _eventAggregator.GetEvent<CloseTabEvent>().Subscribe(CloseSelectedTab);
            _eventAggregator.GetEvent<OpenReportEvent>().Subscribe(OnOpenReport);
            _eventAggregator.GetEvent<OpenWindowByViewModelEvent>().Subscribe(OnOpenWindowByViewModel);
            _eventAggregator.GetEvent<OpenWindowForEditByViewModelEvent>().Subscribe(OnOpenWindowForEditByViewModel);
            CurrentViews = new ObservableCollection<TabItemBase>();

            AddPlatform = new RelayCommand(OnAddPlatform);
            AddWell = new RelayCommand(OnAddWell);
            AddWellbore = new RelayCommand(OnAddWellbore);
            NewSurvey = new RelayCommand(OnNewSurvey);
            ImportSurvey = new RelayCommand(OnImportSurvey, CanImportSurvey);
            ManageSurvey = new RelayCommand(OnManageSurvey);
            EditSurvey = new RelayCommand(OnEditSurvey);
            SectionView = new RelayCommand(OnSectionView, CanOpenSectionView);
            WellProfile = new RelayCommand(OnWellProfile, CanOpenWellProfile);
            CloseTab = new Prism.Commands.DelegateCommand<object>(OnCloseTab);

            LoadTreeListViewModel();
            LoadDashboardViewModel();
        }

        #region Commands

        public RelayCommand AddPlatform { get; private set; }
        public RelayCommand AddWell { get; private set; }
        public RelayCommand AddWellbore { get; private set; }
        public RelayCommand NewSurvey { get; private set; }
        public RelayCommand ImportSurvey { get; private set; }
        public RelayCommand ManageSurvey { get; private set; }
        public RelayCommand EditSurvey { get; private set; }
        public RelayCommand SectionView { get; private set; }
        public RelayCommand WellProfile { get; private set; }

        public ICommand CloseTab { get; private set; }

        #endregion


        private void LoadDashboardViewModel()
        {
            _windowManagementService.OpenWindowByViewModel<DashboardViewModel>();
        }

        #region Variables
        private MainWindow _mainWindow;
        public MainWindow MainWindow
        {
            get => _mainWindow;
            set
            {
                _mainWindow = value;
                _mainWindow.DataContext = this;
                _mainWindow.MainWindowViewModel = this;
                _mainWindow.Instantiate();

            }
        }

        private UserControlViewModelBase _treeListViewModel;
        public UserControlViewModelBase TreeListViewModel
        {
            get => _treeListViewModel;
            set => SetProperty(ref _treeListViewModel, value);
        }
        public UserControlViewBase TreeListView { get; set; }

        private ObservableCollection<TabItemBase> _currentViews;
        public ObservableCollection<TabItemBase> CurrentViews
        {
            get => _currentViews;
            private set => SetProperty(ref _currentViews, value);
        }

        //RECHECK
        private TabItemBase _currentView = new TabItemBase();
        public TabItemBase CurrentView
        {
            get
            {
                if (_currentView != null)
                {
                    if (_currentView.Content.GetType() == typeof(ManageSurveyViewModel))
                    {
                        _selectedSurveyId = ((ManageSurveyViewModel)_currentView.Content).SelectedSurveyId;
                    }
                }

                SectionView.RaiseCanExecuteChanged();
                ImportSurvey.RaiseCanExecuteChanged();
                WellProfile.RaiseCanExecuteChanged();
                return _currentView;
            }
            set
            {
                if (value != null)
                {
                    if (value.Content.GetType() == typeof(ManageSurveyViewModel))
                    {
                        _selectedSurveyId = ((ManageSurveyViewModel)value.Content).SelectedSurveyId;
                    }
                }

                SectionView.RaiseCanExecuteChanged();
                ImportSurvey.RaiseCanExecuteChanged();
                WellProfile.RaiseCanExecuteChanged();
                SetProperty(ref _currentView, value);
            }
        }

        private bool _isGridEdittable;
        public bool IsGridEdittable
        {
            get => _isGridEdittable;
            set
            {
                SetProperty(ref _isGridEdittable, value);
                _manageSurveyViewModel.ChangeGridEdittable(value);
            }
        }

        #endregion

        #region TreeList

        private void LoadTreeListViewModel()
        {
            _windowManagementService.OpenWindowByViewModel<SurveySelectionTreeListViewModel>(0);
        }

        private void OnSurveySelectionChanged(TreeListSelectionItem selectionItem)
        {
            switch (selectionItem.SelectedObject)
            {
                case DataProviders.TreeListStatus.IsPlatform:
                    _windowManagementService.OpenWindowForEditByViewModel<EditPlatfromViewModel>(selectionItem.SelectedObjectId);
                    break;
                case DataProviders.TreeListStatus.IsWell:
                    _windowManagementService.OpenWindowForEditByViewModel<EditWellViewModel>(selectionItem.SelectedObjectId);
                    break;
                case DataProviders.TreeListStatus.IsWellbore:
                    _windowManagementService.OpenWindowForEditByViewModel<EditWellboreViewModel>(selectionItem.SelectedObjectId);
                    break;
                case DataProviders.TreeListStatus.IsSurvey:
                    _selectedSurveyId = selectionItem.SelectedObjectId;
                    _windowManagementService.OpenWindowForEditByViewModel<ManageSurveyViewModel>(selectionItem.SelectedObjectId);
                    break;
            }
        }

        private void OnTreeListDataChanged()
        {
            ((SurveySelectionTreeListViewModel)_treeListViewModel).OnRefreshData();
        }


        #endregion

        #region OpenAndCloseTab

        private void OnOpenWindowByViewModel(UserControlViewModelBase viewModel)
        {
            if (viewModel.GetType() == typeof(SurveySelectionTreeListViewModel))
            {
                _treeListViewModel = viewModel;
                TreeListView = viewModel.UserControlView;
            }
            else
            {
                var header = viewModel.UserControlView.Header;
                if (CurrentViews.Any(item => item.Content.GetType() == viewModel.UserControlView.GetType()))
                {
                    CurrentView = CurrentViews
                        .FirstOrDefault(item => item.Content.GetType() == viewModel.UserControlView.GetType());
                }
                else
                {
                    CurrentView = new TabItemBase
                    {
                        Content = viewModel.UserControlView,
                        Header = header
                    };
                    CurrentViews.Add(CurrentView);

                }
            }

            if (viewModel.GetType() == typeof(ManageSurveyViewModel))
            {
                _manageSurveyViewModel = ((ManageSurveyViewModel)viewModel);
                _manageSurveyViewModel.LoadData(_selectedSurveyId);
            }

        }

        private List<Tuple<int, string, int>> OpenedWindowsForEdit = new List<Tuple<int, string, int>>();
        private int _incrementalNumber = 0;
        private void OnOpenWindowForEditByViewModel(ViewModelForEdit viewModelForEdit)
        {
            var viewModel = viewModelForEdit.ViewModel;
            ((IEdittableUserControlViewModel)viewModel).LoadData(viewModelForEdit.Id);
            var objectName = ((IEdittableUserControlViewModel)viewModel).ObjectName;
            var header = String.IsNullOrEmpty(objectName) ? viewModel.UserControlView.Header : viewModel.UserControlView.Header + " - " + objectName;

            if (OpenedWindowsForEdit.Any(item =>
                item.Item3 == viewModelForEdit.Id && item.Item2 == viewModel.GetType().ToString()))
            {
                var openedWindow = OpenedWindowsForEdit.FirstOrDefault(item =>
                    item.Item3 == viewModelForEdit.Id && item.Item2 == viewModel.GetType().ToString());
                CurrentView = CurrentViews.FirstOrDefault(item => item.Id == openedWindow.Item1);
            }
            else
            {
                CurrentView = new TabItemBase
                {
                    Id = _incrementalNumber + 1,
                    Content = viewModel.UserControlView,
                    Header = header

                };
                CurrentViews.Add(CurrentView);
                OpenedWindowsForEdit.Add(new Tuple<int, string, int>(CurrentView.Id, viewModel.GetType().ToString(), viewModelForEdit.Id));
            }

            if (viewModel.GetType() == typeof(ManageSurveyViewModel))
            {
                _manageSurveyViewModel = ((ManageSurveyViewModel)viewModel);
            }

            _incrementalNumber++;

        }

        public Action<XtraReportBase> ReportBaseAction { get; set; }
        private void OnOpenReport(XtraReportBase reportBase)
        {
            ISectionViewReportService myReportService = new SectionViewReportService(_unitOfWork);

            reportBase.DataSource = myReportService.GetSectionViewReportModels(_selectedSurveyId);
            reportBase.ReportTitle = $"Survey: {_unitOfWork.SurveyService.GetSurveyById(_selectedSurveyId).Name}";

            ReportBaseAction?.Invoke(reportBase);
        }

        private void OnCloseTab(object selectedTab)
        {
            var tabItemBase = (TabItemBase)selectedTab;
            CurrentViews.Remove(tabItemBase);
        }

        private void CloseSelectedTab()
        {
            CurrentViews.Remove(CurrentView);
        }

        #endregion


        #region RibbonButtonMethods

        private void OnAddPlatform()
        {
            _windowManagementService.OpenWindowByViewModel<AddPlatfromViewModel>();
        }

        private void OnAddWell()
        {
            _windowManagementService.OpenWindowByViewModel<AddWellViewModel>();
        }

        private void OnAddWellbore()
        {
            _windowManagementService.OpenWindowByViewModel<AddWellboreViewModel>();
        }

        private void OnNewSurvey()
        {
            _windowManagementService.OpenWindowByViewModel<NewSurveyViewModel>(_selectedSurveyId);
        }

        private bool CanImportSurvey()
        {
            // TODO: Update can import
            return _selectedSurveyId != 0;
        }

        private void OnImportSurvey()
        {
            _windowManagementService.OpenWindowByViewModel<ImportSurveyViewModel>(_selectedSurveyId);
        }

        private void OnManageSurvey()
        {
            _windowManagementService.OpenWindowByViewModel<ManageSurveyViewModel>(_selectedSurveyId);
            SectionView.RaiseCanExecuteChanged();
        }

        private void OnEditSurvey()
        {
            _windowManagementService.OpenWindowForEditByViewModel<EditSurveyViewModel>(_selectedSurveyId);
        }

        private bool CanOpenSectionView()
        {
            return _selectedSurveyId != 0;
        }

        private void OnSectionView()
        {
            _windowManagementService.OpenWindowByViewModel<SectionViewModel>(_selectedSurveyId);
        }

        private bool CanOpenWellProfile()
        {
            return _selectedSurveyId != 0;
        }

        private void OnWellProfile()
        {
            _windowManagementService.OpenWindowByViewModel<WellProfileViewModel>(_selectedSurveyId);
        }

        #endregion

    }
}