using MusiSoft.Data.EF.Context;

namespace MusiSoft.Repositories.Contract.Contract
{
    public interface IUserRepository : IEFBaseRepository
    {
        Users GetUserById(int userId);
        Users GetUserByNickNameAndPassword(string nickName, string password);
    }
}