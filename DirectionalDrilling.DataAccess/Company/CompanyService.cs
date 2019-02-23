using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.DataStorage.Database;
using DirectionalDrilling.Model.Database;

namespace DirectionalDrilling.DataAccess.Company
{
    public class CompanyService : ICompanyService
    {
        private DirectionalDrillingContext _context;

        public CompanyService(DirectionalDrillingContext Context)
        {
            _context = Context;
        }

        public void Add(Model.Models.Company company)
        {
            try
            {
                _context.Companies.Add(company);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error Adding Company - " + e.Message);
            }
        }

        public Model.Models.Company GetCompanyById(int id)
        {
            return _context.Companies.FirstOrDefault(item => item.Id == id);
        }

        public List<Model.Models.Company> GetCompanies()
        {
            return _context.Companies.ToList();
        }

        public void Update(Model.Models.Company company)
        {
            var foundCompany = GetCompanyById(company.Id);
            if (foundCompany != null)
            {
                foundCompany = company;
                _context.SaveChanges();
            }
        }

        public void Delete(Model.Models.Company company)
        {
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }
    }
}
