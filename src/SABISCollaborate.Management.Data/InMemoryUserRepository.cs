using SABISCollaborate.Management.Core.Registration.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SABISCollaborate.Management.Core.Registration.Model;

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
            throw new NotImplementedException();
        }

        public User GetUserByUsernameOrEmail(string username, string email)
        {
            throw new NotImplementedException();
        }

        public UserProfile SaveProfile(int userId, UserProfile profile)
        {
            throw new NotImplementedException();
        }

        public User SaveUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
