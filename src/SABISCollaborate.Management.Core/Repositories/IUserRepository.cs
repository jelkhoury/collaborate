using SABISCollaborate.Registration.Core.Model;
using System.Collections.Generic;

namespace SABISCollaborate.Registration.Core.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();

        List<User> GetUsers(string searchText);

        User GetUser(int userId);

        User GetUser(string username, string passwordHash);

        User GetUserByUsernameOrEmail(string username, string email);

        byte[] GetTempProfilePicture(string id);

        byte[] GetProfilePicture(string id);

        void SaveTempProfilePicture(string id, byte[] bytes);

        void CommitProfilePicture(string id);

        void SaveUser(User user);
    }
}
