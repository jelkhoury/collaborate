using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;

namespace SABISCollaborate.Identity
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Add identity server setup
            services.AddIdentityServer()
                .AddInMemoryClients(Clients.Get())
                .AddInMemoryIdentityResources(Resources.GetIdentityResources())
                .AddInMemoryApiResources(Resources.GetApiResources())
                .AddTestUsers(Users.Get())
                .AddTemporarySigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }

    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client> {
                new Client {
                    ClientId = "sc.js",
                    ClientName = "SABIS Collaborate",
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:5555/signin-callback"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:5555/"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "username",
                        "token",
                        "scapi"
                    },
                }
            };
        }
    }

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

    internal class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser> {
                new TestUser {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "jek",
                    Password = "1",
                    Claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Email, "joseph.elkhoury@outlook.com"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.Id, "4"),
                        new Claim("username", "jek"),
                        new Claim(JwtClaimTypes.NickName, "jek"),
                        new Claim(JwtClaimTypes.Name, "Joseph El Khoury")
                    }
                },
                new TestUser {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABF",
                    Username = "egh",
                    Password = "1",
                    Claims = new List<Claim> {
                        new Claim(JwtClaimTypes.Email, "eghazal@sabis.net"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                        new Claim(JwtClaimTypes.Id, "5"),
                        new Claim("username", "egh"),
                        new Claim(JwtClaimTypes.NickName, "egh"),
                        new Claim(JwtClaimTypes.Name, "Elias El Ghazal")
                    }
                }
            };
        }
    }
}
