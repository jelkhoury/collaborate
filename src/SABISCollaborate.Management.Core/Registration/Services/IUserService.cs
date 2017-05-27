using SABISCollaborate.Management.Core.Registration.Model;
using System.Collections.Generic;

namespace SABISCollaborate.Management.Core.Registration.Services
{
    public interface IUserService
    {
        List<User> GetAll();

        User Register(string username, string password, string email);
    }
}