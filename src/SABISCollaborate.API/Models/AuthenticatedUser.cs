using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Models
{
    public class AuthenticatedUser
    {
        #region Fields
        private ClaimsIdentity _claims;
        private int _userId = 0;
        private string _username = String.Empty;
        #endregion

        #region Properties
        public int UserId
        {
            get
            {
                if (this._userId == 0)
                {
                    this._userId = int.Parse(this._claims.FindFirst("id").Value);
                }

                return this._userId;
            }
        }

        public string Username
        {
            get
            {
                if (String.IsNullOrWhiteSpace(this._username))
                {
                    this._username = this._claims.FindFirst("username").Value;
                }
                return this._username;
            }
        }
        #endregion

        #region Constructors
        public AuthenticatedUser(ClaimsIdentity claims)
        {
            this._claims = claims;
        } 
        #endregion
    }
}
