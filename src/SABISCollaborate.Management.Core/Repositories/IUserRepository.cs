using SABISCollaborate.Registration.Core.Model;
using System.Collections.Generic;

namespace SABISCollaborate.Registration.Core.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int userId);

        User GetUser(string username, string passwordHash);

        User GetUserByUsernameOrEmail(string username, string email);

        void Save(User user);
    }
}
