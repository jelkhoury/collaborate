using SABISCollaborate.Registration.Core.Exceptions;
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

        public void CommitProfilePicture(string id)
        {
            this._userRepository.CommitProfilePicture(id);
        }

        /// <summary>
        /// Get all users and related profiles
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUser()
        {
            return this._userRepository.GetAll();
        }

        public byte[] GetProfilePicture(string pictureId)
        {
            return this._userRepository.GetProfilePicture(pictureId);
        }

        public byte[] GetTempProfilePicture(string pictureId)
        {
            return this._userRepository.GetTempProfilePicture(pictureId);
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

            // commit profile picture
            if (!String.IsNullOrWhiteSpace(user.Profile.PictureId))
            {
                this.CommitProfilePicture(user.Profile.PictureId);
            }

            return user;
        }

        public void SaveTempProfilePicture(string id, byte[] bytes)
        {
            this._userRepository.SaveTempProfilePicture(id, bytes);
        }

        public bool IsUsernameAvailable(string username)
        {
            return this.IsUsernameAndEmailUnique(username, String.Empty);
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
