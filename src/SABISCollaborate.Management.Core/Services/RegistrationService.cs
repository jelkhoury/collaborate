using SABISCollaborate.Registration.Core.Model;
using SABISCollaborate.Registration.Core.Repositories;
using SABISCollaborate.SharedKernel.Exceptions;
using System.Collections.Generic;
using System;

namespace SABISCollaborate.Registration.Core.Services
{
    public class RegistrationService : IRegistrationService
    {
        #region Fields
        private IUserRepository _userRepository;
        #endregion

        #region ctor
        public RegistrationService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        #endregion

        public User GetUser(string username)
        {
            return this._userRepository.GetUserByUsernameOrEmail(username, String.Empty);
        }

        public User GetUserByEmail(string email)
        {
            return this._userRepository.GetUserByUsernameOrEmail(String.Empty, email);
        }

        public User GetUser(string username, string passowrd)
        {
            string passwordHash = this.HashPassword(passowrd);

            return this._userRepository.GetUser(username, passwordHash);
        }

        public bool IsUsernameAvailable(string username)
        {
            return this.IsUsernameAndEmailUnique(username, String.Empty);
        }

        public User Register(string username, string password, string email, UserProfile profile)
        {
            // validate username is unique + email is unique
            if (!this.IsUsernameAndEmailUnique(username, email))
            {
                throw new ValidationException(Constants.ExceptionCode.UsernameOrEmailAlreadyInUse);
            }

            // hash the password
            string passwordHash = this.HashPassword(password);

            // create user model
            User user = new User(username, passwordHash, email, profile);
            this._userRepository.Save(user);

            return user;
        }

        public void Save(User user)
        {
            this._userRepository.Save(user);
        }

        #region Helpers
        private bool IsUsernameAndEmailUnique(string username, string email)
        {
            bool result = this._userRepository.GetUserByUsernameOrEmail(username, email) == null;

            return result;
        }

        private string HashPassword(string password)
        {
            return $"a+b=*{password}*b+a";
        }
        #endregion
    }
}
