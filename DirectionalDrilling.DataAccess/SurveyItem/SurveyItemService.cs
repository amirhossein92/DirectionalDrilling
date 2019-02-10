using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.Model.Database;

namespace DirectionalDrilling.DataAccess.SurveyItem
{
    public class SurveyItemService : ISurveyItemService
    {
        private DirectionalDrillingContext _context;

        public SurveyItemService(DirectionalDrillingContext Context)
        {
            _context = Context;
        }

        public void Add(Model.Models.SurveyItem surveyItem)
        {
            try
            {
                _context.SurveyItems.Add(surveyItem);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding SurveyItem - " + e.Message);
            }
        }

        public Model.Models.SurveyItem GetSurveyItemById(int id)
        {
            return _context.SurveyItems.FirstOrDefault(item => item.Id == id);
        }

        public List<Model.Models.SurveyItem> GetSurveyItems()
        {
            return _context.SurveyItems.ToList();
        }

        public List<Model.Models.SurveyItem> GetSurveyItemsBySurveyId(int id)
        {
            return _context.SurveyItems.Where(item => item.Survey.Id == id).ToList();
        }

        public void Update(Model.Models.SurveyItem surveyItem)
        {
            var foundSurveyItem = GetSurveyItemById(surveyItem.Id);
            if (foundSurveyItem != null)
            {
                foundSurveyItem = surveyItem;
                _context.SaveChanges();
            }
        }

        public void Delete(Model.Models.SurveyItem surveyItem)
        {
            _context.SurveyItems.Remove(surveyItem);
            _context.SaveChanges();
        }
    }
}
