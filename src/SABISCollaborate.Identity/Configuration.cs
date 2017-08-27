using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.Identity
{
    public class Configuration
    {
        public List<string> RedirectUris { get; set; }

        public List<string> AllowedCorsOrigins { get; set; }

        public List<string> PostLogoutRedirectUris { get; set; }

        //public Configuration()
        //{
        //    this.RedirectUris = new List<string>();
        //    this.RedirectUris.Add("http://localhost:5555/signin-callback");
        //    this.AllowedCorsOrigins = new List<string>();
        //    this.AllowedCorsOrigins.Add("http://localhost:5555/");
        //}
    }
}
