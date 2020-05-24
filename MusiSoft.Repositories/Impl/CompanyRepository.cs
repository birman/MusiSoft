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

        public Companies GetCompanyById(int companyId)
        {
            return _context.Companies.Find(companyId);
        }
    }
}