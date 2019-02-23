using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using DirectionalDrilling.Model.Database;

namespace DirectionalDrilling.DataAccess
{
    public interface IUnitOfWork
    {
        ICompanyService CompanyService { get; }
        IPlatformService PlatformService { get; }
        IPlatformRigService PlatformRigService { get; }
        IRigService RigService { get; }
        ISurveyService SurveyService { get; }
        ISurveyItemService SurveyItemService { get; }
        ISurveyTieInService SurveyTieInService { get; }
        IWellService WellService { get; }
        IWellboreService WellboreService { get; }
        IFormationService FormationService { get; }
    }
}
