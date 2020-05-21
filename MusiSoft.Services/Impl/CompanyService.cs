using MusiSoft.Data.EF.Context;
using MusiSoft.Entities;
using MusiSoft.Mapper;
using MusiSoft.Repositories.Contract.Contract;
using MusiSoft.Services.Contract.Contract;
using System.Collections.Generic;

namespace MusiSoft.Services.Impl
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public void AddCompany(CompanyViewModel companyViewModel)
        {
            var company = companyViewModel.ModelToEntity();
            companyRepository.Add(company, true);
        }

        public void DeleteCompany(int ompanyId)
        {
            throw new System.NotImplementedException();
        }

        public void EditCompany(CompanyViewModel companyViewModel)
        {
            var company = companyViewModel.ModelToEntity();
            companyRepository.Edit(company, true);
        }

        public IEnumerable<CompanyViewModel> GetCompanies()
        {
            return companyRepository.FindAll<Companies>().EntityToModel();
        }
    }
}