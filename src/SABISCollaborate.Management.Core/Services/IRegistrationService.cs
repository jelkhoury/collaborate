using SABISCollaborate.Registration.Core.Model;
using System.Collections.Generic;

namespace SABISCollaborate.Registration.Core.Services
{
    public interface IRegistrationService
    {
        User GetUser(string username);

        User GetUserByEmail(string email);

        User GetUser(string username, string passowrd);

        bool IsUsernameAvailable(string username);

        User Register(string username, string password, string email, UserProfile profile);

        void Save(User user);
    }
}