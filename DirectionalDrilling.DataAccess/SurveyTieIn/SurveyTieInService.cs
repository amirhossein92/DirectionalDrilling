using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.Model.Database;

namespace DirectionalDrilling.DataAccess.SurveyTieIn
{
    public class SurveyTieInService : ISurveyTieInService
    {
        private DirectionalDrillingContext _context;

        public SurveyTieInService(DirectionalDrillingContext Context)
        {
            _context = Context;
        }

        public void Add(Model.Models.SurveyTieIn surveyTieIn)
        {
            try
            {
                _context.SurveyTieIns.Add(surveyTieIn);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding SurveyTieIn - " + e.Message);
            }
        }

        public Model.Models.SurveyTieIn GetSurveyTieInById(int id)
        {
            return _context.SurveyTieIns.FirstOrDefault(item => item.Id == id);
        }

        public List<Model.Models.SurveyTieIn> GetSurveyTieIns()
        {
            return _context.SurveyTieIns.ToList();
        }

        public void Update(Model.Models.SurveyTieIn surveyTieIn)
        {
            var foundSurveyTieIn = GetSurveyTieInById(surveyTieIn.Id);
            if (foundSurveyTieIn != null)
            {
                foundSurveyTieIn = surveyTieIn;
                _context.SaveChanges();
            }
        }

        public void Delete(Model.Models.SurveyTieIn surveyTieIn)
        {
            _context.SurveyTieIns.Remove(surveyTieIn);
            _context.SaveChanges();
        }
    }
}
