using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using SABISCollaborate.Identity.Core;
using SABISCollaborate.Profile.Core.Model;
using IdentityServer4.Extensions;
using System.Security.Claims;
using IdentityModel;

namespace SABISCollaborate.Identity
{
    public class ProfileService : IProfileService
    {
        private readonly IUserService _userService;

        public ProfileService(IUserService userService)
        {
            this._userService = userService;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string subjectId = context.Subject.GetSubjectId();
            User user = this._userService.FindById(subjectId);

            List<Claim> claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Email, user.IdentifierEmail),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.Id, user.Id.ToString()),
                        new Claim("username", user.Username),
                        new Claim(JwtClaimTypes.NickName, user.Profile.Nickname),
                        new Claim(JwtClaimTypes.Name, user.Profile.FullName)
                    };
            context.IssuedClaims = claims;

            //context.RequestedClaimTypes.ToList().ForEach(rct =>
            //{
            //});

            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            string subjectId = context.Subject.GetSubjectId();
            User user = this._userService.FindById(subjectId);

            context.IsActive = user.IsActive;

            return Task.FromResult(0);
        }
    }
}
