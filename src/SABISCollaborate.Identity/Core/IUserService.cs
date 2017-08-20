using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SABISCollaborate.Identity.Core
{
    public interface IUserService
    {
        User AutoProvisionUser(string provider, string userId, List<Claim> claims);

        User FindByExternalProvider(string provider, string userId);

        User FindBySubjectId(string subjectId);

        User FindByUsername(string username);

        bool ValidateCredentials(string username, string password);
    }
}
