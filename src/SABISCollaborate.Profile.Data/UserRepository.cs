using SABISCollaborate.Profile.Core.Model;
using SABISCollaborate.Profile.Core.Repositories;
using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SABISCollaborate.Profile.Data
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
