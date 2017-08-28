using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace SABISCollaborate_SPA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();

            if (args != null && args.Length > 0)
            {
                hostBuilder.UseUrls($"http://localhost:{args[0]}");
            }

            hostBuilder.Build().Run();
        }
    }
}
