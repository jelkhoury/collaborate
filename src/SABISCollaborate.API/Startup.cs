using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SABISCollaborate.API.Chat;
using SABISCollaborate.Chat.Core.Repositories;
using SABISCollaborate.Chat.Data;
using SABISCollaborate.System.Data;
using System;

namespace SABISCollaborate.API
{
    public class Startup
    {
        private MessageDispatcher _dispatcher;

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
            string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SABISCollaborate;Data Source=JOSEPH-LENOVO";

            services.AddSingleton<IGroupRepository, EFGroupRepository>();
            services.AddSingleton<ITextMessageRepository, EFTextMessageRepository>();
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
            this._dispatcher = new MessageDispatcher(serviceProvider.GetService<IConnectionManager>());

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            app.UseSignalR();
        }
    }
}
