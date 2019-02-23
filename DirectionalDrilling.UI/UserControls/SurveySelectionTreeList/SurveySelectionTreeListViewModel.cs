using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Xpf.Grid;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.DataAccess.Platform;
using DirectionalDrilling.DataAccess.Survey;
using DirectionalDrilling.DataAccess.Well;
using DirectionalDrilling.DataAccess.Wellbore;
using DirectionalDrilling.Model;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using DirectionalDrilling.UI.DataProviders;
using DirectionalDrilling.UI.Events;
using Prism.Events;
using BindableBase = Prism.Mvvm.BindableBase;

namespace DirectionalDrilling.UI.UserControls.SurveySelectionTreeList
{
    public class SurveySelectionTreeListViewModel : UserControlViewModelBase
    {
        private ObservableCollection<TreeListLookUpItem> _surveyList;
        private IUnitOfWork _unitOfWork;
        private IEventAggregator _eventAggregator;
        private int _selectedSurveyId;
        private TreeListLookUpItem _selectedSurvey;

        public SurveySelectionTreeListViewModel(SurveySelectionTreeListView surveySelectionTreeListView, 
            IEventAggregator eventAggregator,
            IUnitOfWork unitOfWork)
        {
            UserControlView = surveySelectionTreeListView;
            _unitOfWork = unitOfWork;
            _surveyList = new ObservableCollection<TreeListLookUpItem>();
            _selectedSurvey = new TreeListLookUpItem();
            _eventAggregator = eventAggregator;

            LoadSurveyList();

            RefreshData = new RelayCommand(OnRefreshData);
        }


        public ObservableCollection<TreeListLookUpItem> SurveyList
        {
            get => _surveyList;
            set => SetProperty(ref _surveyList, value);
        }
        public int SelectedSurveyId
        {
            get => _selectedSurveyId;
            set => SetProperty(ref _selectedSurveyId, value);
        }
        public TreeListLookUpItem SelectedSurvey
        {
            get => _selectedSurvey;
            set => SetProperty(ref _selectedSurvey, value);
        }
        public RelayCommand RefreshData { get; private set; }

        public void LoadSurveyList()
        {
            SurveyList.Clear();
            int platformId = 1;
            int wellId = _unitOfWork.PlatformService.GetPlatforms().Count + platformId;
            int wellboreId = _unitOfWork.WellService.GetWells().Count + wellId;
            int surveyId = _unitOfWork.WellboreService.GetWellbores().Count + wellboreId;

            foreach (var platform in _unitOfWork.PlatformService.GetPlatforms())
            {
                SurveyList.Add(new TreeListLookUpItem { Id = platformId, Name = platform.Name, ObjectRealId = platform.Id ,Status = TreeListStatus.IsPlatform });

                foreach (var well in _unitOfWork.WellService.GetWells().Where(item => item.Platform.Id == platform.Id).ToList())
                {
                    SurveyList.Add(new TreeListLookUpItem { Id = wellId, Name = well.Name, ParentId = platformId,ObjectRealId=well.Id, Status = TreeListStatus.IsWell });
                    foreach (var wellbore in _unitOfWork.WellboreService.GetWellbores().Where(item => item.Well.Id == well.Id)
                        .ToList())
                    {
                        SurveyList.Add(new TreeListLookUpItem
                        {
                            Id = wellboreId,
                            Name = wellbore.Name,
                            ParentId = wellId,
                            ObjectRealId = wellbore.Id,
                            Status = TreeListStatus.IsWellbore
                        });
                        foreach (var survey in _unitOfWork.SurveyService.GetSurveys()
                            .Where(item => item.Wellbore.Id == wellbore.Id).ToList())
                        {
                            SurveyList.Add(new TreeListLookUpItem
                            {
                                Id = surveyId,
                                Name = survey.Name,
                                ParentId = wellboreId,
                                ObjectRealId = survey.Id,
                                Status = TreeListStatus.IsSurvey
                            });
                            surveyId++;
                        }

                        wellboreId++;
                    }

                    wellId++;
                }

                platformId++;
            }

        }

        public void OnSelectionChanged()
        {
            if (SelectedSurvey.Status == TreeListStatus.IsSurvey)
            {
                SelectedSurveyId = SelectedSurvey.ObjectRealId;
                _eventAggregator.GetEvent<TreeListSelectionChangeEvent>().Publish(_selectedSurvey.ObjectRealId);
            }

            if (SelectedSurvey.Status == TreeListStatus.IsPlatform)
            {

            }


        }

        private void OnRefreshData()
        {
            LoadSurveyList();
        }


    }
}
