using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.DataAccess.Formation
{
    public interface IFormationService
    {
        void Add(Model.Models.Formation formation);
        Model.Models.Formation GetformationById(int id);
        List<Model.Models.Formation> Getformations();
        List<Model.Models.Formation> GetformationsByWellboreId(int id);
        void Update(Model.Models.Formation formation);
        void Delete(Model.Models.Formation formation);
    }
}
