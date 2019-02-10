using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.DataAccess.Well
{
    public interface IWellService
    {
        void Add(Model.Models.Well well);
        Model.Models.Well GetWellById(int id);
        List<Model.Models.Well> GetWells();
        List<Model.Models.Well> GetWellsByPlatformId(int id);
        void Update(Model.Models.Well well);
        void Delete(Model.Models.Well well);
    }
}
