using MusiSoft.Entities;
using System.Collections.Generic;

namespace MusiSoft.Services.Contract.Contract
{
    public interface ICompanyService
    {
        bool AddCompany(CompanyViewModel companyViewModel);

        bool EditCompany(CompanyViewModel companyViewModel);

        bool DeleteCompany(int companyId);

        IEnumerable<CompanyViewModel> GetCompanies();

        CompanyViewModel GetCompanyById(int companyId);
    }
}