using SABISCollaborate.Profile.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Profile.Core.Services
{
    public interface IProfileService
    {
        User GetUserById(int userId);

        List<User> GetUsers();

        List<User> GetUsersByIds(List<int> usersIds);

        List<User> GetUsers(string searchText);

        byte[] GetProfilePicture(string pictureId);

        void SetProfilePicture(int userId, byte[] imageBytes);
    }
}
