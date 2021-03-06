﻿using MusiSoft.Data.EF.Context;
using MusiSoft.Entities;
using MusiSoft.Mapper;
using MusiSoft.Repositories.Contract.Contract;
using MusiSoft.Services.Contract.Contract;
using System;
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

        [System.Obsolete]
        public bool AddUser(UserViewModel userViewModel)
        {
            bool saved = false;

            var _user = userRepository.GetUserById(userViewModel.Id);

            if ((_user == null))
            {
                var user = userViewModel.ModelToEntity();
                var _company = System.Configuration.ConfigurationSettings.AppSettings["company"];
                user.CompanyId = Int32.Parse(_company);
                userRepository.Add(user, true);
                saved = true;
            }

            return saved;
        }

        public bool DeleteUser(int userId)
        {
            bool deleted = false;

            var user = userRepository.GetUserById(userId);

            if ((user != null))
            {
                userRepository.Delete(user, true);
                deleted = true;
            }

            return deleted;
        }

        [Obsolete]
        public bool EditUser(UserViewModel userViewModel)
        {
            bool edited = false;

            var user = userViewModel.ModelToEntity();

            if ((user != null) && (ExistUser(user.Id)))
            {
                var _company = System.Configuration.ConfigurationSettings.AppSettings["company"];
                user.CompanyId = Int32.Parse(_company);
                userRepository.Edit(user, true);
                edited = true;
            }

            return edited;
        }

        public IEnumerable<UserViewModel> GetUsers()
        {
            return userRepository.FindAll<Users>().EntityToModel();
        }

        public UserViewModel GetUserById(int userId)
        {
            var user = userRepository.GetUserById(userId);

            return user != null ? user.EntityToModel() : null;
        }

        private bool ExistUser(int userId)
        {
            bool existUser = false;
            var user = userRepository.GetUserById(userId);

            if (user != null)
            {
                userRepository.Detach(user);
                existUser = true;
            }

            return existUser;
        }

        public UserViewModel GetUser(UserViewModel userViewModel)
        {
            var user = userRepository.GetUserByNickNameAndPassword(userViewModel.Nickname, userViewModel.Password);

            return user != null ? user.EntityToModel() : null;
        }
    }
}