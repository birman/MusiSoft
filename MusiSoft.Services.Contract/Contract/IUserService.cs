using MusiSoft.Entities;
using System.Collections.Generic;

namespace MusiSoft.Services.Contract.Contract
{
    public interface IUserService
    {
        void AddUser(UserViewModel userViewModel);

        void EditUser(UserViewModel userViewModel);

        void DeleteUser(int userId);

        IEnumerable<UserViewModel> Getusers();
    }
}