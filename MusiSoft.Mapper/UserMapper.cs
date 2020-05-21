using MusiSoft.Data.EF.Context;
using MusiSoft.Entities;
using System.Collections.Generic;

namespace MusiSoft.Mapper
{
    public static class UserMapper
    {
        public static UserViewModel EntityToModel(this Users user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                CompanyId = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Identification = user.Identification,
                Phone = user.Phone,
                Email = user.Email,
                Nickname = user.Nickname,
                Password = user.Password
            };
        }

        public static IEnumerable<UserViewModel> EntityToModel(this IEnumerable<Users> users)
        {
            if (users == null) yield return null;
            else
                foreach (var user in users)
                {
                    yield return EntityToModel(user);
                }
        }

        public static Users ModelToEntity(this UserViewModel userViewModel)
        {
            return new Users
            {
                Id = userViewModel.Id,
                CompanyId = userViewModel.Id,
                Name = userViewModel.Name,
                LastName = userViewModel.LastName,
                Identification = userViewModel.Identification,
                Phone = userViewModel.Phone,
                Email = userViewModel.Email,
                Nickname = userViewModel.Nickname,
                Password = userViewModel.Password
            };
        }

        public static IEnumerable<Users> ModelToEntity(this IEnumerable<UserViewModel> usersViewModel)
        {
            if (usersViewModel == null) yield return null;
            else
                foreach (var user in usersViewModel)
                {
                    yield return ModelToEntity(user);
                }
        }
    }
}