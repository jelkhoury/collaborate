using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SABISCollaborate.Identity.Core
{
    public class UserService : IUserService
    {
        public User AutoProvisionUser(string provider, string userId, List<Claim> claims)
        {
            throw new NotImplementedException();
        }

        public User FindByExternalProvider(string provider, string userId)
        {
            throw new NotImplementedException();
        }

        public User FindBySubjectId(string subjectId)
        {
            throw new NotImplementedException();
        }

        public User FindByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public bool ValidateCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
