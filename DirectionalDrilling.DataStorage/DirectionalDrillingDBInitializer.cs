using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.Model.Database;
using DirectionalDrilling.Model.Models;

namespace DirectionalDrilling.DataStorage
{
    /// <summary>
    /// It can be used for developing!
    /// </summary>
    public class DirectionalDrillingDbInitializer : DropCreateDatabaseAlways<DirectionalDrillingContext>
    {
        public override void InitializeDatabase(DirectionalDrillingContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction,
                $"ALTER DATABASE [{context.Database.Connection.Database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");

            base.InitializeDatabase(context);
        }

        protected override void Seed(DirectionalDrillingContext context)
        {
            var newCompany = new Company{Name = "CompanyA", IsClient = false, IsOperator = false, IsRigContractor = false, IsServiceCompany = false};
            var newRig = new Rig{Name = "RigA", Type = "RigTypeA"};
            var newPlatform = new Platform { Name = "PlatformA" };
            var newPlatformRig = new PlatformRig {Platform = newPlatform, Rig = newRig, Company = newCompany, StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow};

            var newWell = new Well { Name = "WellA", Platform = newPlatform };
            var newWellbore = new Wellbore { Name = "WellboreA", Well = newWell };
            var newSurvey = new Survey { VerticalSectionDirection = 0, Wellbore = newWellbore };
            var newSurveyTieIn = new SurveyTieIn { MeasuredDepth = 100, Survey = newSurvey };

            context.PlatformRigs.Add(newPlatformRig);
            context.SurveyTieIns.Add(newSurveyTieIn);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
