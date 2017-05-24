using SABISCollaborate.Management.Core.Registration.Model;
using System.Collections.Generic;

namespace SABISCollaborate.Management.Core.Registration.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User GetUser(int userId);

        User GetUserByUsernameOrEmail(string username, string email);

        User SaveUser(User user);

        UserProfile SaveProfile(int userId, UserProfile profile);
    }
}
