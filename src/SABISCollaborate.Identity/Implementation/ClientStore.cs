using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Microsoft.Extensions.Options;
using IdentityServer4;

namespace SABISCollaborate.Identity
{
    public class ClientStore : IClientStore
    {
        private readonly Configuration _options;

        //public ClientStore()
        //{
        //    this._options = new Configuration();
        //}

        public ClientStore(IOptions<Configuration> options)
        {
            this._options = options.Value;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            if (clientId == "sc.js")
            {
                Client client = new Client
                {
                    ClientId = "sc.js",
                    ClientName = "SABIS Collaborate",
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    RedirectUris = this._options.RedirectUris,
                    PostLogoutRedirectUris = this._options.PostLogoutRedirectUris,
                    AllowedCorsOrigins = this._options.AllowedCorsOrigins,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "id",
                        "username",
                        "token",
                        "scapi"
                    },
                };
                return Task.FromResult(client);
            }

            return null;
        }
    }
}
