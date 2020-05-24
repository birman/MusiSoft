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

        public bool AddCompany(CompanyViewModel companyViewModel)
        {
            bool saved = false;

            var _company = companyRepository.GetCompanyById(companyViewModel.Id);

            if ((_company == null))
            {
                var company = companyViewModel.ModelToEntity();
                companyRepository.Add(company, true);
                saved = true;
            }

            return saved;
        }

        public bool DeleteCompany(int companyId)
        {
            bool deleted = false;

            var company = companyRepository.GetCompanyById(companyId);

            if ((company != null))
            {
                companyRepository.Delete(company, true);
                deleted = true;
            }

            return deleted;
        }

        public bool EditCompany(CompanyViewModel companyViewModel)
        {
            bool edited = false;

            var company = companyViewModel.ModelToEntity();

            if ((company != null) && (ExistCompany(company.Id)))
            {
                companyRepository.Edit(company, true);
                edited = true;
            }

            return edited;
        }

        public IEnumerable<CompanyViewModel> GetCompanies()
        {
            return companyRepository.FindAll<Companies>().EntityToModel();
        }

        public CompanyViewModel GetCompanyById(int companyId)
        {
            var company = companyRepository.GetCompanyById(companyId);

            return company != null ? company.EntityToModel() : null;
        }

        private bool ExistCompany(int companyId)
        {
            bool existCompany = false;
            var company = companyRepository.GetCompanyById(companyId);

            if (company != null)
            {
                companyRepository.Detach(company);
                existCompany = true;
            }

            return existCompany;
        }
    }
}