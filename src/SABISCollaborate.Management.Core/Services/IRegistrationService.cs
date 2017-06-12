using SABISCollaborate.Registration.Core.Model;
using System.Collections.Generic;

namespace SABISCollaborate.Registration.Core.Services
{
    public interface IRegistrationService
    {
        List<User> GetAllUser();

        User Register(string username, string password, string email, UserProfile profile);

        //User Register(string username, string password, string email, string firstName, string lastName, Gender gender, DateTime birthDate);

        //UserProfile UpdateUserProfile(int userId, UserProfile profile);
    }
}