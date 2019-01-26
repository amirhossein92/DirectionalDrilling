using DirectionalDrilling.Model.Models;

namespace DirectionalDrilling.DataStorage.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class DirectionalDrillingDbContextMigrationConfiguration : DbMigrationsConfiguration<DirectionalDrilling.Model.Database.DirectionalDrillingContext>
    {
        public DirectionalDrillingDbContextMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "DirectionalDrilling.Model.Database.DirectionalDrillingContext";
        }

        protected override void Seed(DirectionalDrilling.Model.Database.DirectionalDrillingContext context)
        {
            //  This method will be called after migrating to the latest version.
            if (!context.PlatformRigs.Any(pr => pr.Id == 1))
            {
                var newCompany = new Company
                {
                    Id = 1,
                    Name = "CompanyA",
                    IsClient = false,
                    IsOperator = false,
                    IsRigContractor = false,
                    IsServiceCompany = false
                };
                var newRig = new Rig { Id = 1, Name = "RigA", Type = "RigTypeA" };
                var newPlatform = new Platform { Id = 1, Name = "PlatformA" };
                var newPlatformRig = new PlatformRig
                {
                    Id = 1,
                    Platform = newPlatform,
                    Rig = newRig,
                    Company = newCompany,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow
                };

                var newWell = new Well { Id = 1, Name = "WellA", Platform = newPlatform };
                var newWellbore = new Wellbore { Id = 1, Name = "WellboreA", Well = newWell };
                var newSurvey = new Survey { Id = 1, VerticalSectionDirection = 0, Wellbore = newWellbore };
                var newSurveyTieIn = new SurveyTieIn { Id = 1, MeasuredDepth = 100, Survey = newSurvey };

                context.PlatformRigs.AddOrUpdate(pr => pr.Id, newPlatformRig);
                context.SurveyTieIns.AddOrUpdate(st => st.Id, newSurveyTieIn);
                context.SaveChanges();
            }

            base.Seed(context);

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
