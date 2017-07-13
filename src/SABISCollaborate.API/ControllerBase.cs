using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API
{
    public class ControllerBase : Controller
    {
        private AuthenticatedUser _currentUser = null;

        public AuthenticatedUser CurrentUser
        {
            get
            {
                if (this._currentUser == null)
                {
                    this._currentUser = new AuthenticatedUser(base.User.Identities.First());
                }

                return this._currentUser;
            }
        }
    }
}
