using SABISCollaborate.Registration.Core.Model;
using System.Collections.Generic;

namespace SABISCollaborate.Registration.Core.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User GetUser(int userId);

        User GetUserByUsernameOrEmail(string username, string email);

        void SaveUser(User user);
    }
}
