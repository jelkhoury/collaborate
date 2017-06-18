﻿using SABISCollaborate.SharedKernel;
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

        public User(string username, string passwordHash, string email, UserProfile profile)
            : this(default(int), username, passwordHash, email, profile)
        {

        }

        public User(int id, string username, string passwordHash, string email, UserProfile profile)
        {
            this.Id = id;

            if (String.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("username");
            }

            if (String.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentNullException("passwordHash");
            }

            if (String.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException("email");
            }

            this.Profile = profile ?? throw new ArgumentNullException("profile");

            this.Username = username;
            this.IdentifierEmail = email;
            this.CreatedDate = DateTime.Now;
            this.SetPassword(passwordHash);
        }
        #endregion

        #region Methods
        public void SetPassword(string passwordHash)
        {
            if (String.IsNullOrWhiteSpace(passwordHash))
            {
                throw new ArgumentNullException("passwordHash");
            }

            this.PasswordHash = passwordHash;
        }
        #endregion
    }
}
