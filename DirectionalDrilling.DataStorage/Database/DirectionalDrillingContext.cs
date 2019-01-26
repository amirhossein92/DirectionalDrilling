using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.DataStorage;
using DirectionalDrilling.DataStorage.Configuration;
using DirectionalDrilling.DataStorage.Migrations;
using DirectionalDrilling.Model.Models;

namespace DirectionalDrilling.Model.Database
{
    public class DirectionalDrillingContext : DbContext
    {
        public DirectionalDrillingContext() : base("name=DirectionalDrillingDBConnectionString")
        {
            System.Data.Entity.Database.SetInitializer (new MigrateDatabaseToLatestVersion
                            <DirectionalDrillingContext,
                DirectionalDrillingDbContextMigrationConfiguration>());
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<PlatformRig> PlatformRigs { get; set; }
        public DbSet<Rig> Rigs { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyTieIn> SurveyTieIns { get; set; }
        public DbSet<SurveyItem> SurveyItems { get; set; }
        public DbSet<Well> Wells { get; set; }
        public DbSet<Wellbore> Wellbores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new SurveyEntityConfiguration());

        }
    }
}
