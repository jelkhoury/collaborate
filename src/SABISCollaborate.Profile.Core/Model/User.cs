using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Profile.Core.Model
{
    public class User
    {
        #region Properties
        public int Id { get; private set; }

        public string Username { get; private set; }

        public string PasswordHash { get; private set; }

        public string IdentifierEmail { get; private set; }

        public bool IsActive { get; private set; }

        public int UserProfileId { get; set; }

        public UserProfile Profile { get; set; }

        public DateTime CreatedDate { get; private set; }
        #endregion

        #region Constructors
        private User()
        {
        }
        #endregion
    }
}
