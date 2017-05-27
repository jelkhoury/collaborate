using SABISCollaborate.Management.Core.Registration.Exceptions;
using SABISCollaborate.Management.Core.Registration.Interfaces;
using SABISCollaborate.Management.Core.Registration.Model;
using SABISCollaborate.SharedKernel.Exceptions;
using System;
using System.Collections.Generic;

namespace SABISCollaborate.Management.Core.Registration.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public User Register(string username, string password, string email)
        {
            // validate username is unique + email is unique
            if (!this.IsUsernameAndEmailUnique(username, email))
            {
                throw new ValidationException(Constants.ExceptionCode.UsernameAlreadyInUse);
            }
            User user = new User(username, password + "9975", email, null);
            this._userRepository.SaveUser(user);

            return user;
        }

        private bool IsUsernameAndEmailUnique(string username, string email)
        {
            bool result = this._userRepository.GetUserByUsernameOrEmail(username, email) == null;

            return result;
        }

        public List<User> GetAll()
        {
            return this._userRepository.GetAll();
        }
    }
}
