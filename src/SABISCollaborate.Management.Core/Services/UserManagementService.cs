using SABISCollaborate.Registration.Core.Exceptions;
using SABISCollaborate.Registration.Core.Model;
using SABISCollaborate.Registration.Core.Repositories;
using SABISCollaborate.SharedKernel.Exceptions;
using System.Collections.Generic;

namespace SABISCollaborate.Registration.Core.Services
{
    public class UserManagementService : IUserManagementService
    {
        #region Fields
        private IUserRepository _userRepository;
        #endregion

        #region ctor
        public UserManagementService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        #endregion

        /// <summary>
        /// Get all users and related profiles
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            return this._userRepository.GetAll();
        }

        public User Register(string username, string password, string email, UserProfile profile)
        {
            // validate username is unique + email is unique
            if (!this.IsUsernameAndEmailUnique(username, email))
            {
                throw new ValidationException(Constants.ExceptionCode.UsernameAlreadyInUse);
            }

            // create user model
            User user = new User(username, password, email, profile);
            this._userRepository.SaveUser(user);

            return user;
        }

        #region Helpers
        private bool IsUsernameAndEmailUnique(string username, string email)
        {
            bool result = this._userRepository.GetUserByUsernameOrEmail(username, email) == null;

            return result;
        }
        #endregion
    }
}
