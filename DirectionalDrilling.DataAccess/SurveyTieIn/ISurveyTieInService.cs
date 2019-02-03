using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.DataAccess.SurveyTieIn
{
    public interface ISurveyTieInService
    {
        void Add(Model.Models.SurveyTieIn surveyTieIn);
        Model.Models.SurveyTieIn GetSurveyTieInById(int id);
        List<Model.Models.SurveyTieIn> GetSurveyTieIns();
        void Update(Model.Models.SurveyTieIn surveyTieIn);
        void Delete(Model.Models.SurveyTieIn surveyTieIn);
    }
}
