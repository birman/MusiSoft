using MusiSoft.Data.EF.Context;
using MusiSoft.Repositories.Base;
using MusiSoft.Repositories.Contract.Contract;

namespace MusiSoft.Repositories.Impl
{
    public class CustomerRepository : EFBaseRepository, ICustomerRepository
    {
        public CustomerRepository(MusiSoftBDEntities dbContext)
        {
            _context = dbContext;
        }
    }
}