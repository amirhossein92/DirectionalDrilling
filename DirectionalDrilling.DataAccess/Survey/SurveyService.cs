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
            foreach (var surveyItem in surveyItems.OrderBy(item => item.MeasuredDepth))
            {
                var d1 = MathService.CosDegree(surveyItem.Inclination - preSurveyItem.Inclination) -
                             MathService.SinDegree(surveyItem.Inclination) * MathService.SinDegree(preSurveyItem.Inclination) *
                             (1 - MathService.CosDegree(surveyItem.Azimuth - preSurveyItem.Azimuth));
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
                                       * fc * (MathService.CosDegree(preSurveyItem.Inclination) + MathService.CosDegree(surveyItem.Inclination));

                surveyItem.Northing = preSurveyItem.Northing + (surveyItem.MeasuredDepth - preSurveyItem.MeasuredDepth) / 2 * fc
                                                                                                      * (MathService.SinDegree(surveyItem.Inclination) * MathService.CosDegree(surveyItem.Azimuth) +
                                                                                                         MathService.SinDegree(preSurveyItem.Inclination) * MathService.CosDegree(preSurveyItem.Azimuth));

                surveyItem.Easting = preSurveyItem.Easting + (surveyItem.MeasuredDepth - preSurveyItem.MeasuredDepth) / 2 * fc
                                                                                                      * (MathService.SinDegree(surveyItem.Inclination) * MathService.SinDegree(surveyItem.Azimuth) +
                                                                                                         MathService.SinDegree(preSurveyItem.Inclination) * MathService.SinDegree(preSurveyItem.Azimuth));

                double closureDirection;
                if (surveyItem.Northing < 0.00001 && surveyItem.Northing > -0.00001)
                    closureDirection = 90;
                else
                    closureDirection = MathService.RadiansToDegrees(System.Math.Atan(surveyItem.Easting / surveyItem.Northing));

                double closureDistance =
                    System.Math.Sqrt(System.Math.Pow(surveyItem.Easting, 2) + System.Math.Pow(surveyItem.Northing, 2));

                surveyItem.VerticalSection =
                    MathService.CosDegree(inputSurvey.VerticalSectionDirection - closureDirection) *
                    closureDistance; preSurveyItem = surveyItem;
            }
            _context.SaveChanges();
        }

        public string InterpolateByMdToTvd(int inputSurveyId, double interpolationMd)
        {
            var inputSurvey = GetSurveyById(inputSurveyId);
            ISurveyItemService surveyItemService = new SurveyItemService(_context);
            var surveyItems = surveyItemService.GetSurveyItemsBySurveyId(inputSurveyId);

            int i = 0;
            while (interpolationMd > surveyItems[i].MeasuredDepth)
            {
                i++;
            }

            double beta = System.Math.Acos(
                (
                    (MathService.SinDegree(surveyItems[i - 1].Inclination)
                     * MathService.SinDegree(surveyItems[i].Inclination))
                    * (MathService.SinDegree(surveyItems[i - 1].Azimuth)
                       * MathService.SinDegree(surveyItems[i].Azimuth)
                       + MathService.CosDegree(surveyItems[i - 1].Azimuth)
                       * MathService.CosDegree(surveyItems[i].Azimuth)))
                + (MathService.CosDegree(surveyItems[i - 1].Inclination)
                   * MathService.CosDegree(surveyItems[i].Inclination)));
            double k = beta / 30;

            double resultInclination, ni, t1i, ti, cosazp = 0, resultAzimuth;

            if (k == 0)
            {
                resultInclination = surveyItems[i].Inclination;
            }
            else
            {
                resultInclination = MathService.RadiansToDegrees(System.Math.Acos(
                    MathService.CosDegree(surveyItems[i - 1].Inclination)
                    * System.Math.Cos(k * (interpolationMd - surveyItems[i - 1].MeasuredDepth))
                    + System.Math.Sin(k * (interpolationMd - surveyItems[i - 1].MeasuredDepth))
                    * (MathService.CosDegree(surveyItems[i].Inclination)
                       - MathService.CosDegree(surveyItems[i - 1].Inclination)
                       * System.Math.Cos(beta)) / System.Math.Sin(beta)));

                ni = (MathService.SinDegree(surveyItems[i].Inclination)
                      * MathService.CosDegree(surveyItems[i].Azimuth)
                      - MathService.SinDegree(surveyItems[i - 1].Inclination)
                      * MathService.CosDegree(surveyItems[i - 1].Azimuth)
                      * System.Math.Cos(beta)) / System.Math.Sin(beta);

                t1i = MathService.SinDegree(surveyItems[i - 1].Inclination)
                      * MathService.CosDegree(surveyItems[i - 1].Azimuth);

                ti = t1i * System.Math.Cos(k * (interpolationMd - surveyItems[i - 1].MeasuredDepth))
                     + ni * System.Math.Sin(k * (interpolationMd - surveyItems[i - 1].MeasuredDepth));

                cosazp = ti / MathService.SinDegree(resultInclination);
            }

            if (cosazp > 0.999 && cosazp < 1.001)
            {
                resultAzimuth = 0;
            }
            else
            {
                resultAzimuth = MathService.RadiansToDegrees(System.Math.Acos(cosazp));
            }
            if (((surveyItems[i - 1].Azimuth + surveyItems[i].Azimuth) / 2) > 180 && ((surveyItems[i - 1].Azimuth + surveyItems[i].Azimuth) / 2) < 360)
            {
                resultAzimuth = 360 - resultAzimuth;
            }

            if (resultAzimuth < 0.001)
            {
                resultAzimuth = 0;
            }
            if (resultInclination < 0.001)
            {
                resultInclination = 0;
            }

            var d1 = MathService.CosDegree(resultInclination - surveyItems[i - 1].Inclination) -
                     MathService.SinDegree(resultInclination) * MathService.SinDegree(surveyItems[i - 1].Inclination) *
                     (1 - MathService.CosDegree(resultAzimuth - surveyItems[i - 1].Azimuth));
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

            var resultTrueVerticalDepth = surveyItems[i - 1].TrueVerticalDepth + (interpolationMd - surveyItems[i - 1].MeasuredDepth) / 2
                                           * fc * (MathService.CosDegree(surveyItems[i - 1].Inclination) + MathService.CosDegree(resultInclination));

            return $"{resultTrueVerticalDepth:N} / {resultInclination:N} / {resultAzimuth:N}";

        }
    }
}
