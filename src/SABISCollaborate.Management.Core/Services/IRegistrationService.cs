using SABISCollaborate.Registration.Core.Model;
using System.Collections.Generic;

namespace SABISCollaborate.Registration.Core.Services
{
    public interface IRegistrationService
    {
        List<User> GetAllUsers();

        User GetUser(string username);

        User GetUserByEmail(string email);

        //User GetUser(string username, string passowrd);

        //List<User> GetUsers(string searchText);

        //byte[] GetTempProfilePicture(string pictureId);

        //byte[] GetProfilePicture(string pictureId);

        void Save(User user);

        User Register(string username, string password, string email, UserProfile profile);

        //void SaveTempProfilePicture(string id, byte[] bytes);

        //void CommitProfilePicture(string id);
    }
}