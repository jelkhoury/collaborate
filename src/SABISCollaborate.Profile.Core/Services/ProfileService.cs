using SABISCollaborate.Profile.Core.Model;
using SABISCollaborate.Profile.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SABISCollaborate.Profile.Core.Services
{
    public class ProfileService : IProfileService
    {
        #region Fields
        private readonly IUserRepository _userRepository;
        #endregion

        #region ctor
        public ProfileService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        #endregion

        #region Methods
        public User GetUserById(int userId)
        {
            var result = this._userRepository.FindBy(u => u.Id == userId, u => u.Profile).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Get all users and related profiles
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            return this._userRepository.GetAll().ToList();
        }

        public List<User> GetUsersByIds(List<int> usersIds)
        {
            List<User> result = this._userRepository.FindBy(u => usersIds.Contains(u.Id), u => u.Profile).ToList();

            return result;
        }

        public List<User> GetUsers(string searchText)
        {
            return this._userRepository.GetUsers(searchText);
        }

        public byte[] GetProfilePicture(string pictureId)
        {
            return this._userRepository.GetProfilePicture(pictureId);
        }

        public void SetProfilePicture(int userId, byte[] imageBytes)
        {
            this._userRepository.SetProfilePicture(userId, imageBytes);
        }
        #endregion
    }
}
