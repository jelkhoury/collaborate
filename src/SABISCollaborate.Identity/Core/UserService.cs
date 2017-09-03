using Microsoft.EntityFrameworkCore;
using SABISCollaborate.Profile.Core.Model;
using SABISCollaborate.Profile.Core.Repositories;
using SABISCollaborate.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.Identity.Core
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public User FindByExternalProvider(string provider, string userId)
        {
            throw new NotImplementedException();
        }

        public User FindById(string id)
        {
            //return this._userRepository.GetSingle(int.Parse(id), u => u.Profile);
            return this._userRepository.FindBy(u => u.Id == int.Parse(id), u => u.Profile, u => u.UserRoleLinks).Include("UserRoleLinks.Role").FirstOrDefault();
        }

        public User FindByUsername(string username)
        {
            return this._userRepository.FindBy(u => u.Username.ToLowerInvariant() == username.Trim().ToLowerInvariant())
                .FirstOrDefault();
        }

        public bool ValidateCredentials(string username, string password)
        {
            password = password.PasswordHash();

            User user = this._userRepository.FindBy(u => u.Username.ToLowerInvariant() == username.Trim().ToLowerInvariant())
                .Where(u => u.PasswordHash == password)
                .FirstOrDefault();

            return user != null;
        }
    }
}
