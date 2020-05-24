using MusiSoft.Entities;
using System.Collections.Generic;

namespace MusiSoft.Services.Contract.Contract
{
    public interface ICustomerService
    {
        bool AddCustomer(CustomerViewModel customerViewModel);

        bool EditCustomer(CustomerViewModel customerViewModel);

        bool DeleteCustomer(int customerId);

        IEnumerable<CustomerViewModel> GetCustomers();

        CustomerViewModel GetCustomerById(int customerId);
    }
}