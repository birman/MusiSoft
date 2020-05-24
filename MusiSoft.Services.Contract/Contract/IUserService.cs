using MusiSoft.Entities;
using System.Collections.Generic;

namespace MusiSoft.Services.Contract.Contract
{
    public interface IUserService
    {
        bool AddUser(UserViewModel userViewModel);

        bool EditUser(UserViewModel userViewModel);

        bool DeleteUser(int userId);

        IEnumerable<UserViewModel> GetUsers();

        UserViewModel GetUserById(int userId);
    }
}