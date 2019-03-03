using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.DataAccess.Survey
{
    public interface ISurveyService
    {
        // CRUD
        void Add(Model.Models.Survey survey);
        Model.Models.Survey GetSurveyById(int id);
        List<Model.Models.Survey> GetSurveys();
        void Update(Model.Models.Survey survey);
        void Delete(Model.Models.Survey survey);
        // UI
        string GetSurveyDescription(int id);
        // Calculation
        void MinimumCurvatureMethod(int inputSurveyId);

        string InterpolateByMdToTvd(int inputSurveyId, double interpolationMd);
    }
}
