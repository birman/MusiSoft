using MusiSoft.Data.EF.Context;
using MusiSoft.Entities;
using MusiSoft.Mapper;
using MusiSoft.Repositories.Contract.Contract;
using MusiSoft.Services.Contract.Contract;
using System.Collections.Generic;

namespace MusiSoft.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void AddUser(UserViewModel userViewModel)
        {
            var user = userViewModel.ModelToEntity();
            userRepository.Add(user, true);
        }

        public void DeleteUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void EditUser(UserViewModel userViewModel)
        {
            var user = userViewModel.ModelToEntity();
            userRepository.Edit(user, true);
        }

        public IEnumerable<UserViewModel> Getusers()
        {
            return userRepository.FindAll<Users>().EntityToModel();
        }
    }
}