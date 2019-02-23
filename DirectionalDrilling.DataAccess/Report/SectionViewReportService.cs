using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.DataAccess.Report.Models.SectionView;
using DirectionalDrilling.DataAccess.Survey;
using DirectionalDrilling.DataAccess.SurveyItem;

namespace DirectionalDrilling.DataAccess.Report
{
    public class SectionViewReportService : ISectionViewReportService
    {
        private IUnitOfWork _unitOfWork;
        private ISurveyItemService _surveyItemService;

        public SectionViewReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ObservableCollection<SectionViewReportModel> GetSectionViewReportModels(int surveyId)
        {
            var myList = new ObservableCollection<SectionViewReportModel>();

            var reportParameter = new SectionViewReportModel();

            var survey = _unitOfWork.SurveyService.GetSurveyById(surveyId);
            var surveyItems = _unitOfWork.SurveyItemService.GetSurveyItemsBySurveyId(surveyId);
            reportParameter.PlatformName = survey.Wellbore.Well.Platform.Name;
            reportParameter.WellName = survey.Wellbore.Well.Name;
            reportParameter.WellboreName = survey.Wellbore.Name;
            reportParameter.VerticalSectionDirection = survey.VerticalSectionDirection;
            var chartDatas = new List<SectionViewReportModelChart>();
            foreach (var surveyItem in surveyItems)
            {
                chartDatas.Add(new SectionViewReportModelChart
                {
                    TrueVerticalDepth = surveyItem.TrueVerticalDepth,
                    VeritcalSection = surveyItem.VerticalSection
                });
            }

            reportParameter.SectionViewReportModelCharts = chartDatas;

            myList.Add(reportParameter);

            return myList;
        }
    }
}
