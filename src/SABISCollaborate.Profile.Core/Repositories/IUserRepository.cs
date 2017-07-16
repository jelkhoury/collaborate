using SABISCollaborate.Profile.Core.Model;
using SABISCollaborate.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Profile.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<User> GetUsers(string searchText);

        byte[] GetProfilePicture(string id);

        void SetProfilePicture(int userId, byte[] bytes);
    }
}
