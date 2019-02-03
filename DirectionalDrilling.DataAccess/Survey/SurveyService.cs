using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.Model.Database;

namespace DirectionalDrilling.DataAccess.Survey
{
    public class SurveyService : ISurveyService
    {
        private DirectionalDrillingContext _context;

        public SurveyService(DirectionalDrillingContext Context)
        {
            _context = Context;
        }

        public void Add(Model.Models.Survey survey)
        {
            try
            {
                _context.Surveys.Add(survey);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Survey - " + e.Message);
            }
        }

        public Model.Models.Survey GetSurveyById(int id)
        {
            return _context.Surveys.FirstOrDefault(item => item.Id == id);
        }

        public List<Model.Models.Survey> GetSurveys()
        {
            return _context.Surveys.ToList();
        }

        public void Update(Model.Models.Survey survey)
        {
            var foundSurvey = GetSurveyById(survey.Id);
            if (foundSurvey != null)
            {
                foundSurvey = survey;
                _context.SaveChanges();
            }
        }

        public void Delete(Model.Models.Survey survey)
        {
            _context.Surveys.Remove(survey);
            _context.SaveChanges();
        }
    }
}
