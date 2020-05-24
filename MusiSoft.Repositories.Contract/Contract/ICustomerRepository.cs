using MusiSoft.Data.EF.Context;

namespace MusiSoft.Repositories.Contract.Contract
{
    public interface ICustomerRepository : IEFBaseRepository
    {
        Customers GetCustomerById(int customerId);
    }
}