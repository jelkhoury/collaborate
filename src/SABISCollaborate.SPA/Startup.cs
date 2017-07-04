using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SABISCollaborate.Registration.Core.Repositories;
using SABISCollaborate.Registration.Core.Services;
using SABISCollaborate.Registration.Data;
using SCSystem = SABISCollaborate.System.Core;
using SCSystemData = SABISCollaborate.System.Data;

namespace SABISCollaborate_SPA
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SABISCollaborate;Data Source=JOSEPH-LENOVO";

            // System Context
            services.AddSingleton<SCSystem.Repositories.IGroupRepository, SCSystemData.EFDepartmentRepository>();
            services.AddSingleton<SCSystem.Repositories.IPositionRepository, SCSystemData.EFPositionRepository>();
            services.AddDbContext<SCSystemData.SystemDbContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

            // Registration Context
            services.AddSingleton<IUserRepository, EFUserRepository>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddDbContext<RegistrationDbContext>(o =>
            {
                o.UseSqlServer(connectionString);
            });

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
