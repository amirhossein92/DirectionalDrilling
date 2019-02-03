using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.DataAccess.Rig
{
    public interface IRigService
    {
        void Add(Model.Models.Rig rig);
        Model.Models.Rig GetRigById(int id);
        List<Model.Models.Rig> GetRigs();
        void Update(Model.Models.Rig rig);
        void Delete(Model.Models.Rig rig);
    }
}
