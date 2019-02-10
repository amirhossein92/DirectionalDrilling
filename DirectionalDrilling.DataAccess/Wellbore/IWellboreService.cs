using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.DataAccess.Wellbore
{
    public interface IWellboreService
    {
        void Add(Model.Models.Wellbore wellbore);
        Model.Models.Wellbore GetWellboreById(int id);
        List<Model.Models.Wellbore> GetWellbores();
        List<Model.Models.Wellbore> GetWellboresByWellId(int id);
        void Update(Model.Models.Wellbore wellbore);
        void Delete(Model.Models.Wellbore wellbore);
    }
}
