using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.Model;
using DirectionalDrilling.Model.Models;
using Survey = DirectionalDrilling.Model.Models.Survey;
using Well = DirectionalDrilling.Model.Models.Well;

namespace DirectionalDrilling.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.FormationService.Add(new Formation{Name = "NewFormation", WellboreId = 1, FormationBottomTrueVerticalDepth = 100, FormationTopTrueVerticalDepth = 100});
            foreach (var item in unitOfWork.FormationService.Getformations())
            {
                System.Console.WriteLine(item.Name);}

            System.Console.ReadKey();
        }

    }
}
