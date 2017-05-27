using SABISCollaborate.Management.Core.Registration.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SABISCollaborate.Management.Core.Registration.Model;
using System.Linq;

namespace SABISCollaborate.Management.Data
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<User> _users = new List<User>();

        public InMemoryUserRepository()
        {
            this._users.Add(new User("jek", "1", "joseph.elkhoury@outlook.com", null));
            this._users.Add(new User("hri", "1", "hrizk@outlook.com", null));
            this._users.Add(new User("egh", "1", "eghazal@outlook.com", null));
        }

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

        public UserProfile SaveProfile(int userId, UserProfile profile)
        {
            throw new NotImplementedException();
        }

        public User SaveUser(User user)
        {
            User resultUser = this.GetUserByUsernameOrEmail(user.Username, user.IdentifierEmail);

            if (resultUser == null)
            {
                int id = this._users.Max(u => u.Id);
                resultUser = new User(id, user.Username, user.PasswordHash, user.IdentifierEmail, user.Profile);

                this._users.Add(resultUser);
            }

            return resultUser;
        }
    }
}
