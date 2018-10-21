using SABISCollaborate.SharedKernel.Interfaces;
using SABISCollaborate.Users.Core.Models;
using System.Collections.Generic;

namespace SABISCollaborate.Users.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<User> GetUsers(string searchText);

        byte[] GetProfilePicture(string id);

        void SetProfilePicture(int userId, byte[] bytes);
    }
}
