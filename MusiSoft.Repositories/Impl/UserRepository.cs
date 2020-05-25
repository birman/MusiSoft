using MusiSoft.Data.EF.Context;
using MusiSoft.Repositories.Base;
using MusiSoft.Repositories.Contract.Contract;
using System.Linq;

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

        public Users GetUserByNickNameAndPassword(string nickName, string password)
        {
            return _context.Users.Where(x => x.Nickname == nickName && x.Password == password).FirstOrDefault();
        }
    }
}