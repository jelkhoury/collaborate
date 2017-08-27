using IdentityModel;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.Identity.Implementation
{
    internal class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource {
                    Name = "role",
                    UserClaims = new List<string> { "role" }
                },
                new IdentityResource {
                    Name = "username",
                    UserClaims = new List<string> { "username" }
                },
                new IdentityResource {
                    Name = "id",
                    UserClaims = new List<string> { "id" }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
                new ApiResource {
                    Name = "sc.api",
                    DisplayName = "SABIS Collaborate API",
                    Description = "SABIS Collaborate API",
                    UserClaims = new List<string> {
                        JwtClaimTypes.Id,
                        "username"
                    },
                    ApiSecrets = new List<Secret> {
                        new Secret("scopeSecret".Sha256())
                    },
                    Scopes = new List<Scope> {
                        new Scope("scapi"),
                    }
                }
            };
        }
    }
}
