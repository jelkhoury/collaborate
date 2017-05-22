﻿using SABISCollaborate.RegistrationManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SABISCollaborate.RegistrationManagement.Core.Model
{
    public class User : Entity
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string IdentifierEmail { get; private set; }
        public UserProfile Profile { get; private set; }
        public string PasswordHash { get; private set; }

        private User()
        {
        }

        public User(string username, string password, string email, UserProfile profile)
        {
            this.Username = username;
            this.IdentifierEmail = email;
            this.Profile = profile;
            this.PasswordHash = this.ComputePasswordHash(password);
        }

        private string ComputePasswordHash(string password)
        {
            return password + "123";
        }
    }
}
