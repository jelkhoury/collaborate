using SABISCollaborate.Registration.Core.Model;
using System.Collections.Generic;

namespace SABISCollaborate.Registration.Core.Services
{
    public interface IRegistrationService
    {
        List<User> GetAllUsers();

        User GetUser(string username, string passowrd);

        List<User> GetUsers(string searchText);

        User Register(string username, string password, string email, UserProfile profile);

        byte[] GetTempProfilePicture(string pictureId);

        byte[] GetProfilePicture(string pictureId);

        bool IsUsernameAvailable(string username);

        User GetUserByEmail(string email);

        void SaveTempProfilePicture(string id, byte[] bytes);

        void CommitProfilePicture(string id);
    }
}