using SABISCollaborate.Profile.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.Identity.Core
{
    public interface IUserService
    {
        User FindByExternalProvider(string provider, string userId);

        User FindById(string id);

        User FindByUsername(string username);

        bool ValidateCredentials(string username, string password);
    }
}
