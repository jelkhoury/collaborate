using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;

namespace SABISCollaborate.Registration.Core.Model
{
    public class User : Entity
    {
        #region Properties
        public int Id { get; private set; }

        public string Username { get; protected set; }

        public string PasswordHash { get; protected set; }

        public string IdentifierEmail { get; set; }

        public UserProfile Profile { get; protected set; }

        public DateTime CreatedDate { get; protected set; }
        #endregion

        #region Constructors
        private User()
        {
        }

        public User(string username, string password, string email, UserProfile profile)
            : this(default(int), username, password, email, profile)
        {

        }

        public User(int id, string username, string password, string email, UserProfile profile)
        {
            this.Id = id;

            if (String.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("username");
            }

            if (String.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("email");
            }

            if (profile == null)
            {
                throw new ArgumentNullException("profile");
            }

            this.Username = username;
            this.IdentifierEmail = email;
            this.Profile = profile;
            this.CreatedDate = DateTime.Now;
            this.SetPassword(password);
        }
        #endregion

        #region Methods
        public void SetPassword(string password)
        {
            if (String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("password");
            }

            this.PasswordHash = $"a+b=*{password}*b+a";
        }
        #endregion
    }
}
