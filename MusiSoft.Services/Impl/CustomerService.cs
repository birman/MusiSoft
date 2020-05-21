using MusiSoft.Data.EF.Context;
using MusiSoft.Entities;
using MusiSoft.Mapper;
using MusiSoft.Repositories.Contract.Contract;
using MusiSoft.Services.Contract.Contract;
using System.Collections.Generic;

namespace MusiSoft.Services.Impl
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void AddCustomer(CustomerViewModel customerViewModel)
        {
            var customer = customerViewModel.ModelToEntity();
            customerRepository.Add(customer, true);
        }

        public void DeleteCustomer(int customerId)
        {
            throw new System.NotImplementedException();
        }

        public void EditCustomer(CustomerViewModel customerViewModel)
        {
            var customer = customerViewModel.ModelToEntity();
            customerRepository.Edit(customer, true);
        }

        public IEnumerable<CustomerViewModel> GetCustomers()
        {
            return customerRepository.FindAll<Customers>().EntityToModel();
        }
    }
}