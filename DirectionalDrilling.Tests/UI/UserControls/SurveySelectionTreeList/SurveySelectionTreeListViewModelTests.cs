using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.DataAccess.Company;
using DirectionalDrilling.DataAccess.Formation;
using DirectionalDrilling.DataAccess.Platform;
using DirectionalDrilling.DataAccess.PlatformRig;
using DirectionalDrilling.DataAccess.Rig;
using DirectionalDrilling.DataAccess.Survey;
using DirectionalDrilling.DataAccess.SurveyItem;
using DirectionalDrilling.DataAccess.SurveyTieIn;
using DirectionalDrilling.DataAccess.Well;
using DirectionalDrilling.DataAccess.Wellbore;
using DirectionalDrilling.UI.Events;
using DirectionalDrilling.UI.UserControls.SurveySelectionTreeList;
using Prism.Events;
using Xunit;

namespace DirectionalDrilling.Tests.UI.UserControls.SurveySelectionTreeList
{
    public class SurveySelectionTreeListViewModelTests
    {

        [Fact]
        public void IsDataLoaded()
        {
            //Arrange:
            var eventAggregator = new EventAggregator();
            eventAggregator.GetEvent<TreeListSelectionChangeEvent>();
            var unitOfWorkMock = new UnitOfWorkMock();
            //var surveySelectionTreeListViewModel = new SurveySelectionTreeListViewModel(eventAggregator, unitOfWorkMock);

            
            //Act:

            //Assert:

        }
    }

    public class UnitOfWorkMock : IUnitOfWork
    {
        public ICompanyService CompanyService { get; }
        public IPlatformService PlatformService { get; }
        public IPlatformRigService PlatformRigService { get; }
        public IRigService RigService { get; }
        public ISurveyService SurveyService { get; }
        public ISurveyItemService SurveyItemService { get; }
        public ISurveyTieInService SurveyTieInService { get; }
        public IWellService WellService { get; }
        public IWellboreService WellboreService { get; }
        public IFormationService FormationService { get; }
    }

}
