using MusiSoft.Entities;
using System.Collections.Generic;

namespace MusiSoft.Services.Contract.Contract
{
    public interface ICustomerService
    {
        void AddCustomer(CustomerViewModel customerViewModel);

        void EditCustomer(CustomerViewModel customerViewModel);

        void DeleteCustomer(int customerId);

        IEnumerable<CustomerViewModel> GetCustomers();
    }
}