using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectionalDrilling.DataAccess;
using DirectionalDrilling.DataAccess.Company;
using DirectionalDrilling.Model.Models;
using Xunit;

namespace DirectionalDrilling.Tests
{
    public class CompanyServiceTest
    {
        [Fact]
        public void IsAddFunctionWorks()
        {
            //Arrange:
            var unitOfWork = new UnitOfWork();

            var myCompany = new Company {Name = "CompanyTest"};

            unitOfWork.CompanyService.Add(myCompany);

            var companyList = unitOfWork.CompanyService.GetCompanies();
            var resultedCompany = companyList.FirstOrDefault(item => item.Name == myCompany.Name);

            Assert.NotNull(resultedCompany);

        }
    }
}
