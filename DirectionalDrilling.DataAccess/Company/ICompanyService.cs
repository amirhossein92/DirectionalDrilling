using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectionalDrilling.DataAccess.Company
{
    public interface ICompanyService
    {
        void Add(Model.Models.Company company);
        Model.Models.Company GetCompanyById(int id);
        List<Model.Models.Company> GetCompanies();
        void Update(Model.Models.Company company);
        void Delete(Model.Models.Company company);

    }
}
