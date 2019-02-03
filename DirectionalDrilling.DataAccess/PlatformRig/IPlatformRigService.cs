using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.DataAccess.PlatformRig
{
    public interface IPlatformRigService
    {
        void Add(Model.Models.PlatformRig platformRig);
        Model.Models.PlatformRig GetPlatformRigById(int id);
        List<Model.Models.PlatformRig> GetPlatformRigs();
        void Update(Model.Models.PlatformRig platformRig);
        void Delete(Model.Models.PlatformRig platformRig);
    }
}
