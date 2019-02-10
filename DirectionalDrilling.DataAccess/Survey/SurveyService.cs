using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.DataAccess.Math;
using DirectionalDrilling.DataAccess.SurveyItem;
using DirectionalDrilling.DataAccess.SurveyTieIn;
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
            return _context.Surveys.Find(id);
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

        public string GetSurveyDescription(int id)
        {
            var survey = _context.Surveys
                .Include("Wellbore.Well.Platform")
                .FirstOrDefault(item => item.Id == id);
            var wellboreName = "?";
            var wellName = "?";
            var platformName = "?";
            if (survey != null)
            {
                wellboreName = survey.Wellbore.Name;
                wellName = survey.Wellbore.Well.Name;
                platformName = survey.Wellbore.Well.Platform.Name;
                return $"Platform: {platformName}, Well: {wellName}, Wellbore: {wellboreName} - {survey.Name}";
            }

            return "No Valid Data Is Selected";
        }

        public void MinimumCurvatureMethod(int inputSurveyId)
        {
            var inputSurvey = GetSurveyById(inputSurveyId);
            ISurveyTieInService surveyTieInService = new SurveyTieInService(_context);
            var inputSurveyTieIn = surveyTieInService.GetSurveyTieInById(inputSurveyId);
            ISurveyItemService surveyItemService = new SurveyItemService(_context);
            var surveyItems = surveyItemService.GetSurveyItemsBySurveyId(inputSurveyId);

            Model.Models.SurveyItem preSurveyItem = new Model.Models.SurveyItem
            {
                MeasuredDepth = inputSurveyTieIn.MeasuredDepth,
                Inclination = inputSurveyTieIn.Inclination,
                Azimuth = inputSurveyTieIn.Azimuth,
                TrueVerticalDepth = inputSurveyTieIn.TrueVerticalDepth,
                Northing = inputSurveyTieIn.Northing,
                Easting = inputSurveyTieIn.Easting

            };
            foreach (var surveyItem in surveyItems.OrderByDescending(item => item.MeasuredDepth))
            {
                var d1 = MathService.CalculateRadiansCos(surveyItem.Inclination - preSurveyItem.Inclination) -
                             MathService.CalculateRadiansSin(surveyItem.Inclination) * MathService.CalculateRadiansSin(preSurveyItem.Inclination) *
                             (1 - MathService.CalculateRadiansCos(surveyItem.Azimuth - preSurveyItem.Azimuth));
                double d2;
                if (System.Math.Abs(d1) < .0001)
                    d2 = MathService.DegreesToRadians(90);
                else
                    d2 = System.Math.Atan(System.Math.Sqrt(System.Math.Pow(1 / d1, 2) - 1));

                double fc;
                if (System.Math.Abs(d2) < .0001)
                    fc = 1;
                else
                    fc = 2 / d2 * System.Math.Tan(d2 / 2);

                surveyItem.TrueVerticalDepth = preSurveyItem.TrueVerticalDepth + (surveyItem.MeasuredDepth - preSurveyItem.MeasuredDepth) / 2
                                       * fc * (MathService.CalculateRadiansCos(preSurveyItem.Inclination) + MathService.CalculateRadiansCos(surveyItem.Inclination));

                surveyItem.Northing = preSurveyItem.Northing + (surveyItem.MeasuredDepth - preSurveyItem.MeasuredDepth) / 2 * fc
                                                                                                      * (MathService.CalculateRadiansSin(surveyItem.Inclination) * MathService.CalculateRadiansCos(surveyItem.Azimuth) +
                                                                                                         MathService.CalculateRadiansSin(preSurveyItem.Inclination) * MathService.CalculateRadiansCos(preSurveyItem.Azimuth));

                surveyItem.Easting = preSurveyItem.Easting + (surveyItem.MeasuredDepth - preSurveyItem.MeasuredDepth) / 2 * fc
                                                                                                      * (MathService.CalculateRadiansSin(surveyItem.Inclination) * MathService.CalculateRadiansSin(surveyItem.Azimuth) +
                                                                                                         MathService.CalculateRadiansSin(preSurveyItem.Inclination) * MathService.CalculateRadiansSin(preSurveyItem.Azimuth));

                double cDir;

                preSurveyItem = surveyItem;
            }
            _context.SaveChanges();
        }
    }
}
