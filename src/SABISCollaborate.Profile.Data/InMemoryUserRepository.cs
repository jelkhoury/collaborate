using SABISCollaborate.Profile.Core.Repositories;
using System;
using SABISCollaborate.Profile.Core.Model;
using System.Collections.Generic;

namespace SABISCollaborate.Profile.Data
{
    public class InMemoryUserRepository : IUserRepository
    {
        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers(string searchText)
        {
            throw new NotImplementedException();
        }

        public byte[] GetProfilePicture(string id)
        {
            throw new NotImplementedException();
        }

        public void SetProfilePicture(int userId, byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}
