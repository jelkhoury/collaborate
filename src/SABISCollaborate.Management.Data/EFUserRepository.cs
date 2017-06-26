using SABISCollaborate.Registration.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using SABISCollaborate.Registration.Core.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SABISCollaborate.Registration.Data
{
    public class EFUserRepository : IUserRepository
    {
        #region Fields
        private readonly RegistrationDbContext _registrationDb;
        #endregion

        #region Constructors
        public EFUserRepository(RegistrationDbContext registrationDb)
        {
            this._registrationDb = registrationDb;
        }
        #endregion

        #region Methods
        public User GetUser(int userId)
        {
            return this._registrationDb.User.FirstOrDefault(u => u.Id == userId);
        }

        public User GetUser(string username, string passwordHash)
        {
            string trimmedUsername = username.ToLower().Trim();

            User result = this._registrationDb.User.FirstOrDefault(u => String.Compare(u.Username, trimmedUsername, true) == 0 && String.Compare(u.PasswordHash, passwordHash, false) == 0);

            return result;
        }

        public User GetUserByUsernameOrEmail(string username, string email)
        {
            string trimmedUsername = username.ToLower().Trim();
            string trimmedEmail = email.ToLower().Trim();

            User result = this._registrationDb.User.FirstOrDefault(u => String.Compare(u.Username, trimmedUsername, true) == 0 || String.Compare(u.IdentifierEmail, trimmedEmail, true) == 0);

            return result;
        }

        public void Save(User user)
        {
            if (user.Id == default(int))
            {
                // add
                this._registrationDb.User.Add(user);
            }
            else
            {
                // update
                EntityEntry<User> trackedUser = this._registrationDb.Entry(user);
                trackedUser.State = EntityState.Modified;
            }

            this._registrationDb.SaveChanges();
        } 
        #endregion
    }
}
