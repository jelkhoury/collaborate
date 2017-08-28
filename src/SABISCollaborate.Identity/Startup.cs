using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SABISCollaborate.Identity.Core;
using SABISCollaborate.Identity.Implementation;
using SABISCollaborate.Profile.Core.Repositories;
using SABISCollaborate.Profile.Data;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace SABISCollaborate.Identity
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = this.Configuration.GetConnectionString("SABISCollaborate");

            // Add framework services.
            services.AddMvc();
            services.AddDbContext<ProfileDbContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.Configure<Configuration>(this.Configuration.GetSection("IdentitySettings"));

            // Add identity server setup
            services.AddIdentityServer()
                .AddProfileService<ProfileService>()
                .AddClientStore<ClientStore>()
                .AddInMemoryIdentityResources(Implementation.Resources.GetIdentityResources())
                .AddInMemoryApiResources(Implementation.Resources.GetApiResources())
                .AddTemporarySigningCredential();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
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

            var options = serviceProvider.GetService<IOptions<Configuration>>();
            app.UseCors(policy =>
            {
                policy.WithOrigins("http://localhost:5555");// options.Value.AllowedCorsOrigins.ToArray());
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowCredentials();
            });

            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
