using MusiSoft.Data.EF.Context;
using MusiSoft.Entities;
using System.Collections.Generic;

namespace MusiSoft.Mapper
{
    public static class CustomerMapper
    {
        public static CustomerViewModel EntityToModel(this Customers customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                CompanyId = customer.CompanyId,
                MusicalGenreId = customer.MusicalGenreId,
                Name = customer.Name,
                LastName = customer.LastName,
                Identification = customer.Identification,
                Address = customer.Address,
                Email = customer.Email,
                Phone = customer.Phone,
                ResidenceCity = customer.ResidenceCity,
                Gender = customer.Gender,
                Age = customer.Age
            };
        }

        public static IEnumerable<CustomerViewModel> EntityToModel(this IEnumerable<Customers> customers)
        {
            if (customers == null) yield return null;
            else
                foreach (var customer in customers)
                {
                    yield return EntityToModel(customer);
                }
        }

        public static Customers ModelToEntity(this CustomerViewModel customerViewModel)
        {
            return new Customers
            {
                Id = customerViewModel.Id,
                CompanyId = customerViewModel.CompanyId,
                MusicalGenreId = customerViewModel.MusicalGenreId,
                Name = customerViewModel.Name,
                LastName = customerViewModel.LastName,
                Identification = customerViewModel.Identification,
                Address = customerViewModel.Address,
                Email = customerViewModel.Email,
                Phone = customerViewModel.Phone,
                ResidenceCity = customerViewModel.ResidenceCity,
                Gender = customerViewModel.Gender,
                Age = customerViewModel.Age
            };
        }

        public static IEnumerable<Customers> ModelToEntity(this IEnumerable<CustomerViewModel> customersViewModel)
        {
            if (customersViewModel == null) yield return null;
            else
                foreach (var customer in customersViewModel)
                {
                    yield return ModelToEntity(customer);
                }
        }
    }
}