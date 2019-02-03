using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.DataAccess.Platform
{
    public interface IPlatformService
    {
        void Add(Model.Models.Platform platform);
        Model.Models.Platform GetPlatformById(int id);
        List<Model.Models.Platform> GetPlatforms();
        void Update(Model.Models.Platform platform);
        void Delete(Model.Models.Platform platform);

    }
}
