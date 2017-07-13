﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SABISCollaborate.API.Chat;
using SABISCollaborate.Chat.Core.Repositories;
using SABISCollaborate.Chat.Data;
using SABISCollaborate.Registration.Core.Repositories;
using SABISCollaborate.Registration.Core.Services;
using SABISCollaborate.Registration.Data;
using SABISCollaborate.System.Data;
using System;
using SCSystem = SABISCollaborate.System.Core;
using SCSystemData = SABISCollaborate.System.Data;

namespace SABISCollaborate.API
{
    public class Startup
    {
        #region Fields
        private MessageDispatcher _dispatcher;
        #endregion

        #region Properties
        public IConfigurationRoot Configuration { get; }
        #endregion

        #region Constructors
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        } 
        #endregion

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SABISCollaborate;Data Source=JOSEPH-LENOVO";
            //string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SABISCollaborate;Data Source=.\mssqlserver2012";

            // System Context
            services.AddScoped<SCSystem.Repositories.IDepartmentRepository, SCSystemData.EFDepartmentRepository>();
            services.AddScoped<SCSystem.Repositories.IPositionRepository, SCSystemData.EFPositionRepository>();
            services.AddDbContext<SCSystemData.SystemDbContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

            // Registration Context
            services.AddScoped<IUserRepository, EFUserRepository>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddDbContext<RegistrationDbContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

            services.AddScoped<IGroupRepository, EFGroupRepository>();
            services.AddScoped<ITextMessageRepository, EFTextMessageRepository>();
            services.AddDbContext<ChatDbContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

            services.AddSingleton<IMessageDispatcher>((f) =>
            {
                return this._dispatcher;
            });

            services.AddSignalR();

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            this._dispatcher = new MessageDispatcher(serviceProvider.GetService<IConnectionManager>(), serviceProvider.GetService<IGroupRepository>());

            // cors
            app.UseCors((b) =>
            {
                b.AllowAnyOrigin();
                b.AllowAnyHeader();
                b.AllowAnyMethod();
                b.AllowCredentials();
            });

            // logger
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost:5557",
                RequireHttpsMetadata = false,

                EnableCaching = true,

                ApiName = "sc.api"
            });

            // mvc/api
            app.UseMvc();
            
            // signalr
            app.UseSignalR();
        }
    }
}
