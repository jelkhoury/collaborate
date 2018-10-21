using SABISCollaborate.Users.Core.Models;
using SABISCollaborate.Users.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SABISCollaborate.Users.Core.Services
{
    public class UserProfileService : IUserService
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        #endregion

        #region ctor
        public UserProfileService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        #endregion

        #region Methods
        public User Register(string username, string passwordHash, string email, UserProfile profile)
        {
            // validate username is unique + email is unique
            if (!this.IsUsernameAndEmailUnique(username, email))
            {
                throw new ValidationException(Constants.ExceptionCode.UsernameOrEmailAlreadyInUse);
            }

            // create and save user model
            User user = new User(username, passwordHash, email, profile);
            this._userRepository.Add(user);
            this._userRepository.Save();

            return user;
        }
        #endregion

        #region Helpers
        private bool IsUsernameAndEmailUnique(string username, string email)
        {
            bool result = this._userRepository.GetUserByUsernameOrEmail(username, email) == null;

            return result;
        }
        #endregion
    }
}
