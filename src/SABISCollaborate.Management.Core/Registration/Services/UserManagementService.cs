﻿using SABISCollaborate.Management.Core.Registration.Exceptions;
using SABISCollaborate.Management.Core.Registration.Model;
using SABISCollaborate.Management.Core.Registration.Repositories;
using SABISCollaborate.SharedKernel.Enums;
using SABISCollaborate.SharedKernel.Exceptions;
using System;
using System.Collections.Generic;

namespace SABISCollaborate.Management.Core.Registration.Services
{
    public class UserManagementService : IUserManagementService
    {
        #region Fields
        private IUserRepository _userRepository;
        #endregion

        #region ctor
        public UserManagementService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        #endregion

        /// <summary>
        /// Get all users and related profiles
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            return this._userRepository.GetAll();
        }

        public User Register(string username, string password, string email, UserProfile profile)
        {
            // validate username is unique + email is unique
            if (!this.IsUsernameAndEmailUnique(username, email))
            {
                throw new ValidationException(Constants.ExceptionCode.UsernameAlreadyInUse);
            }

            // create user model
            User user = new User(username, password, email, profile);
            this._userRepository.SaveUser(user);

            return user;
        }

        //public User Register(string username, string password, string email, string firstName, string lastName, Gender gender, DateTime birthDate)
        //{
        //    // validation
        //    if (String.IsNullOrWhiteSpace(firstName))
        //    {
        //        throw new ArgumentNullException("firstName");
        //    }
        //    if (String.IsNullOrWhiteSpace(lastName))
        //    {
        //        throw new ArgumentNullException("lastName");
        //    }
        //    if (birthDate.Year < 1910)
        //    {
        //        throw new ArgumentOutOfRangeException("birthDate", "birthDate should be greater than 1910");
        //    }
        //    // validate username is unique + email is unique
        //    if (!this.IsUsernameAndEmailUnique(username, email))
        //    {
        //        throw new ValidationException(Constants.ExceptionCode.UsernameAlreadyInUse);
        //    }


        //    string passwordHash = this.HashPassword(password);
        //    UserProfile profile = new UserProfile
        //    {
        //        FirstName = firstName,
        //        LastName = lastName,
        //        Gender = gender,
        //        BirthDate = birthDate
        //    };

        //    User user = new User(username, passwordHash, email, profile);
        //    this._userRepository.SaveUser(user);

        //    return user;
        //}

        #region CRUD
        //public UserProfile UpdateUserProfile(int userId, UserProfile profile)
        //{
        //    // validation
        //    if (String.IsNullOrWhiteSpace(profile.FirstName))
        //    {
        //        throw new ArgumentNullException("FirstName");
        //    }
        //    if (String.IsNullOrWhiteSpace(profile.LastName))
        //    {
        //        throw new ArgumentNullException("LastName");
        //    }
        //    if (profile.BirthDate.Year < 1910)
        //    {
        //        throw new ArgumentOutOfRangeException("BirthDate", "BirthDate should be greater than 1910");
        //    }

        //    profile = this._userRepository.SaveProfile(profile);

        //    return profile;
        //}
        #endregion

        #region Helpers
        private bool IsUsernameAndEmailUnique(string username, string email)
        {
            bool result = this._userRepository.GetUserByUsernameOrEmail(username, email) == null;

            return result;
        }
        #endregion
    }
}
