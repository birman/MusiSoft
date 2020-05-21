using MusiSoft.Entities;
using System.Collections.Generic;

namespace MusiSoft.Services.Contract.Contract
{
    public interface ICompanyService
    {
        void AddCompany(CompanyViewModel companyViewModel);

        void EditCompany(CompanyViewModel companyViewModel);

        void DeleteCompany(int ompanyId);

        IEnumerable<CompanyViewModel> GetCompanies();
    }
}