using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.DataAccess.SurveyItem
{
    public interface ISurveyItemService
    {
        void Add(Model.Models.SurveyItem survey);
        Model.Models.SurveyItem GetSurveyItemById(int id);
        List<Model.Models.SurveyItem> GetSurveyItems();
        void Update(Model.Models.SurveyItem surveyItem);
        void Delete(Model.Models.SurveyItem surveyItem);
    }
}
