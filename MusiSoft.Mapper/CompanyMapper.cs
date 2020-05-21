using MusiSoft.Data.EF.Context;
using MusiSoft.Entities;
using System.Collections.Generic;

namespace MusiSoft.Mapper
{
    public static class CompanyMapper
    {
        public static CompanyViewModel EntityToModel(this Companies company)
        {
            return new CompanyViewModel
            {
                Id = company.Id,
                Nit = company.Nit,
                Name = company.Name,
                Address = company.Address,
                Phone = company.Phone,
                Email = company.Email
            };
        }

        public static IEnumerable<CompanyViewModel> EntityToModel(this IEnumerable<Companies> companies)
        {
            if (companies == null) yield return null;
            else
                foreach (var company in companies)
                {
                    yield return EntityToModel(company);
                }
        }

        public static Companies ModelToEntity(this CompanyViewModel companyViewModel)
        {
            return new Companies
            {
                Id = companyViewModel.Id,
                Nit = companyViewModel.Nit,
                Name = companyViewModel.Name,
                Address = companyViewModel.Address,
                Phone = companyViewModel.Phone,
                Email = companyViewModel.Email
            };
        }

        public static IEnumerable<Companies> ModelToEntity(this IEnumerable<CompanyViewModel> companiesViewModel)
        {
            if (companiesViewModel == null) yield return null;
            else
                foreach (var company in companiesViewModel)
                {
                    yield return ModelToEntity(company);
                }
        }
    }
}