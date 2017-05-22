using SABISCollaborate.RegistrationManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SABISCollaborate.RegistrationManagement.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int userId);

        User GetUserByUsernameOrEmail(string username, string email);

        User SaveUser(User user);

        UserProfile SaveProfile(int userId, UserProfile profile);
    }
}
