using SABISCollaborate.Management.Core.Registration.Model;
using SABISCollaborate.Management.Core.Registration.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SABISCollaborate.Management.Data
{
    public class InMemoryUserRepository : IUserRepository
    {
        #region Fields
        private List<User> _users;
        #endregion

        #region ctor
        public InMemoryUserRepository()
        {
            this._users = new List<User>();
            this.SaveUser(new User("jek", "1", "joseph.elkhoury@outlook.com", new UserProfile
            {
                FirstName = "Joseph",
                LastName = "El Khoury"
            }));
            this.SaveUser(new User("hri", "1", "hrizk@outlook.com", new UserProfile
            {
                FirstName = "Hiba",
                LastName = "Rizk"
            }));
            this.SaveUser(new User("egh", "1", "eghazal@outlook.com", new UserProfile
            {
                FirstName = "Elie",
                LastName = "Ghazal"
            }));
            this.SaveUser(new User("rbr", "1", "ralphbouraad@outlook.com", new UserProfile
            {
                FirstName = "Ralph",
                LastName = "Bou Raad"
            }));
        }
        #endregion

        #region Users
        public List<User> GetAll()
        {
            return this._users;
        }

        public User GetUser(int userId)
        {
            return this._users.Find(u => u.Id == userId);
        }

        public User GetUserByUsernameOrEmail(string username, string email)
        {
            return this._users.Find(u => String.Compare(u.Username, username, true) == 0
             || String.Compare(u.IdentifierEmail, email, true) == 0);
        }

        public void SaveUser(User user)
        {
            User result = this.GetUser(user.Id);

            int newId = 1;

            // remove old user
            if (result != null)
            {
                newId = result.Id;
                this._users.Remove(result);
            }
            else if (this._users.Count > 0)
            {
                newId = this._users.Max(u => u.Id);
            }

            // create new user with id
            result = new User(newId, user.Username, user.PasswordHash, user.IdentifierEmail, user.Profile);

            this._users.Add(result);
        }

        public UserProfile UpdateProfile(int userId, UserProfile profile)
        {
            return profile;
        }
        #endregion

    }
}
