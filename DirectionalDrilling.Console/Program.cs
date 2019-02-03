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

            foreach (var item in unitOfWork.WellService.GetWells())
            {
                System.Console.WriteLine(item.Name);
            }

            System.Console.ReadKey();
        }

    }
}
