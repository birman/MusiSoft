using MusiSoft.Data.EF.Context;
using MusiSoft.Entities;

namespace MusiSoft.Repositories.Contract.Contract
{
    public interface ICompanyRepository: IEFBaseRepository
    {
        Companies GetCompanyById(int companyId);
    }
}