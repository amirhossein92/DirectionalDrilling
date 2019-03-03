using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm.POCO;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Printing;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.DataAccess.Report;
using DirectionalDrilling.Model.Models;
using DirectionalDrilling.UI.Base;
using DirectionalDrilling.UI.Commands;
using DirectionalDrilling.UI.DataProviders;
using DirectionalDrilling.UI.Events;
using DirectionalDrilling.UI.UserControls.Graph.View;
using DirectionalDrilling.UI.UserControls.Report;
using Prism.Events;

namespace DirectionalDrilling.UI.UserControls.Graph.ViewModel
{
    class SectionViewModel : UserControlViewModelBase
    {
        private ObservableCollection<SectionViewGraph> _surveyItems;
        private int _selectedSurveyId;
        private IUnitOfWork _unitOfWork;
        private IEventAggregator _eventAggregator;

        public SectionViewModel(SectionView sectionView,
            int selectedSurveyId,
            IUnitOfWork unitOfWork,
            IEventAggregator eventAggregator)
        {
            UserControlView = sectionView;
            _selectedSurveyId = selectedSurveyId;
            _unitOfWork = unitOfWork;
            _eventAggregator = eventAggregator;

            PrintCommand = new RelayCommand(OnPrintCommand);
        }


        public ICommand PrintCommand { get; private set; }
        public ObservableCollection<SectionViewGraph> SurveyItems
        {
            get => _surveyItems;
            set => SetProperty(ref _surveyItems, value);
        }
        //public ObservableCollection<SectionViewGraph> SurveyItems
        //{
        //    get => _surveyItems;
        //    set => SetProperty(ref _surveyItems, value);
        // //}

        public void OnLoaded()
        {
            SurveyItems = new ObservableCollection<SectionViewGraph>();
            var surveyItems = _unitOfWork.SurveyItemService.GetSurveyItemsBySurveyId(_selectedSurveyId).OrderBy(item => item.TrueVerticalDepth);
            var text = "";
            foreach (var surveyItem in surveyItems)
            {
                // TODO: ADD VERTICAL SECTION
                SurveyItems.Add(new SectionViewGraph(surveyItem.VerticalSection, surveyItem.TrueVerticalDepth));
                text += $"{surveyItem.VerticalSection}, {surveyItem.TrueVerticalDepth}{Environment.NewLine}";

                //{
                //    MeasuredDepth = surveyItem.MeasuredDepth,
                //    TrueVerticalDepth = surveyItem.TrueVerticalDepth,
                //    Northing = surveyItem.Northing,
                //    Easting = surveyItem.Easting,
                //    VerticalSection = surveyItem.VerticalSection
                //});
            }
            File.WriteAllText("D:\\a.txt", text);
        }

        private void OnPrintCommand()
        {
            var sectionViewXtraReport = new SectionViewXtraReport("Teeee");

            _eventAggregator.GetEvent<OpenReportEvent>().Publish(sectionViewXtraReport);

            //ISectionViewReportService myReportService = new SectionViewReportService();

            //sectionViewXtraReport.DataSource = myReportService.GetSectionViewReportModels(_selectedSurveyId);
            //PrintHelper.ShowRibbonPrintPreview(this, sectionViewXtraReport);
        }
    }
}
