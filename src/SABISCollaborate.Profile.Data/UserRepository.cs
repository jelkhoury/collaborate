using SABISCollaborate.SharedKernel;
using SABISCollaborate.Users.Core.Models;
using SABISCollaborate.Users.Core.Repositories;
using System;
using System.Collections.Generic;

namespace SABISCollaborate.Users.Infrastructure
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProfileDbContext context) : base(context)
        {
        }

        public byte[] GetProfilePicture(string id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers(string searchText)
        {
            throw new NotImplementedException();
        }

        public void SetProfilePicture(int userId, byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}
