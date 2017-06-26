using SABISCollaborate.Profile.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Profile.Core.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();

        List<User> GetUsers(string searchText);

        byte[] GetProfilePicture(string id);

        void SetProfilePicture(int userId, byte[] bytes);
    }
}
