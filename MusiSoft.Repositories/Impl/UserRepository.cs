using MusiSoft.Data.EF.Context;
using MusiSoft.Repositories.Base;
using MusiSoft.Repositories.Contract.Contract;

namespace MusiSoft.Repositories.Impl
{
    public class UserRepository : EFBaseRepository, IUserRepository
    {
        public UserRepository(MusiSoftBDEntities dbContext)
        {
            _context = dbContext;
        }

        public Users GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }
    }
}