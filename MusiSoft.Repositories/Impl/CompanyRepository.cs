using MusiSoft.Data.EF.Context;
using MusiSoft.Repositories.Base;
using MusiSoft.Repositories.Contract.Contract;

namespace MusiSoft.Repositories.Impl
{
    public class CompanyRepository : EFBaseRepository, ICompanyRepository
    {
        public CompanyRepository(MusiSoftBDEntities dbContext)
        {
            _context = dbContext;
        }
    }
}