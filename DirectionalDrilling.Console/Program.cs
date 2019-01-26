using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DirectionalDrilling.Model;
using DirectionalDrilling.Model.Database;
using DirectionalDrilling.Model.Models;
using Survey = DirectionalDrilling.Model.Models.Survey;
using Well = DirectionalDrilling.Model.Models.Well;

namespace DirectionalDrilling.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DirectionalDrillingContext())
            {
                System.Console.WriteLine(context.Wells.Count());
            }
        }

        private static void LoadExampleData(DirectionalDrillingContext context)
        {
            var newPlatform = new Platform {Name = "PlatformA"};
            var newWell = new Well {Name = "WellA", Platform = newPlatform};
            var newWellbore = new Wellbore {Name = "WellboreA", Well = newWell};
            var newSurvey = new Survey {VerticalSectionDirection = 0, Wellbore = newWellbore};
            var newSurveyTieIn = new SurveyTieIn {MeasuredDepth = 100, Survey = newSurvey};

            context.SurveyTieIns.Add(newSurveyTieIn);
            context.SaveChanges();
        }
    }
}
