using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Xpf.Grid;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.DataAccess.Platform;
using DirectionalDrilling.DataAccess.Survey;
using DirectionalDrilling.DataAccess.Well;
using DirectionalDrilling.DataAccess.Wellbore;
using DirectionalDrilling.Model;
using DirectionalDrilling.Model.Models;
using DirectionalDrilling.UI.Commands;
using DirectionalDrilling.UI.DataProviders;
using DirectionalDrilling.UI.Events;
using Prism.Events;

namespace DirectionalDrilling.UI.ViewModels
{
    public class SurveySelectionTreeListViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<TreeListLookUpItem> _surveyList;
        private UnitOfWork _unitOfWork;
        private IEventAggregator _eventAggregator;
        private ISurveyService _surveyService;
        private IWellboreService _wellboreService;
        private IWellService _wellService;
        private IPlatformService _platformService;
        private int _selectedSurveyId;
        private TreeListLookUpItem _selectedSurvey;

        public SurveySelectionTreeListViewModel(IEventAggregator eventAggregator)
        {
            _unitOfWork = new UnitOfWork();
            _surveyList = new ObservableCollection<TreeListLookUpItem>();
            _surveyService = _unitOfWork.SurveyService;
            _wellboreService = _unitOfWork.WellboreService;
            _wellService = _unitOfWork.WellService;
            _platformService = _unitOfWork.PlatformService;
            _selectedSurvey = new TreeListLookUpItem();
            _eventAggregator = eventAggregator;

            LoadSurveyList();
        }

        public ObservableCollection<TreeListLookUpItem> SurveyList
        {
            get => _surveyList;
            set
            {
                _surveyList = value;
                OnPropertyChanged();

            }
        }

        public int SelectedSurveyId
        {
            get => _selectedSurveyId;
            set
            {
                _selectedSurveyId = value;
                OnPropertyChanged();
            }
        }

        public TreeListLookUpItem SelectedSurvey
        {
            get => _selectedSurvey;
            set
            {
                _selectedSurvey = value;
                OnPropertyChanged();
                if(_selectedSurvey != null)
                    _eventAggregator.GetEvent<TreeListSelectionChangeEvent>().Publish(_selectedSurvey.SurveyId);
                else
                {
                    _eventAggregator.GetEvent<TreeListSelectionChangeEvent>().Publish(0);
                }

            }
        }

        public void LoadSurveyList(){
            _surveyList.Clear();
            int platformId = 1;
            int wellId = _platformService.GetPlatforms().Count + platformId;
            int wellboreId = _wellService.GetWells().Count + wellId;
            int surveyId = _wellboreService.GetWellbores().Count + wellboreId;

            foreach (var platform in _platformService.GetPlatforms())
            {
                _surveyList.Add(new TreeListLookUpItem { Id = platformId, Name = platform.Name });

                foreach (var well in _wellService.GetWells().Where(item => item.Platform.Id == platform.Id).ToList())
                {
                    _surveyList.Add(new TreeListLookUpItem { Id = wellId, Name = well.Name, ParentId = platformId });
                    foreach (var wellbore in _wellboreService.GetWellbores().Where(item => item.Well.Id == well.Id)
                        .ToList())
                    {
                        _surveyList.Add(new TreeListLookUpItem
                        {
                            Id = wellboreId,
                            Name = wellbore.Name,
                            ParentId = wellId
                        });
                        foreach (var survey in _surveyService.GetSurveys()
                            .Where(item => item.Wellbore.Id == wellbore.Id).ToList())
                        {
                            _surveyList.Add(new TreeListLookUpItem
                            {
                                Id = surveyId,
                                Name = survey.Name,
                                ParentId = wellboreId,
                                SurveyId = survey.Id
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


    }
}
