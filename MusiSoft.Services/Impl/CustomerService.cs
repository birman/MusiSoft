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

        public bool AddCustomer(CustomerViewModel customerViewModel)
        {
            bool saved = false;

            var _customer = customerRepository.GetCustomerById(customerViewModel.Id);

            if ((_customer == null))
            {
                var customer = customerViewModel.ModelToEntity();
                customerRepository.Add(customer, true);
                saved = true;
            }

            return saved;
        }

        public bool DeleteCustomer(int customerId)
        {
            bool deleted = false;

            var customer = customerRepository.GetCustomerById(customerId);

            if ((customer != null))
            {
                customerRepository.Delete(customer, true);
                deleted = true;
            }

            return deleted;
        }

        public bool EditCustomer(CustomerViewModel customerViewModel)
        {
            bool edited = false;

            var customer = customerViewModel.ModelToEntity();

            if ((customer != null) && (ExistCustomer(customer.Id)))
            {
                customerRepository.Edit(customer, true);
                edited = true;
            }

            return edited;
        }

        public IEnumerable<CustomerViewModel> GetCustomers()
        {
            return customerRepository.FindAll<Customers>().EntityToModel();
        }

        public CustomerViewModel GetCustomerById(int customerId)
        {
            var customer = customerRepository.GetCustomerById(customerId);

            return customer != null ? customer.EntityToModel() : null;
        }

        private bool ExistCustomer(int customerId)
        {
            bool existCustomer = false;
            var customer = customerRepository.GetCustomerById(customerId);

            if (customer != null)
            {
                customerRepository.Detach(customer);
                existCustomer = true;
            }

            return existCustomer;
        }
    }
}