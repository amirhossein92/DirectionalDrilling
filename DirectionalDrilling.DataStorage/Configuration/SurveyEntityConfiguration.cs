using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.Model.Models;

namespace DirectionalDrilling.DataStorage.Configuration
{
    public class SurveyEntityConfiguration : EntityTypeConfiguration<Survey>
    {
        public SurveyEntityConfiguration()
        {
            HasRequired(s => s.SurveyTieIn)
                .WithRequiredPrincipal(si => si.Survey)
                .WillCascadeOnDelete(true);
        }
    }
}
