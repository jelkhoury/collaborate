using SABISCollaborate.Management.Core.Registration.Model;
using SABISCollaborate.SharedKernel.Enums;
using System;
using System.Collections.Generic;

namespace SABISCollaborate.Management.Core.Registration.Services
{
    public interface IUserManagementService
    {
        List<User> GetAll();

        User Register(string username, string password, string email, UserProfile profile);

        //User Register(string username, string password, string email, string firstName, string lastName, Gender gender, DateTime birthDate);

        //UserProfile UpdateUserProfile(int userId, UserProfile profile);
    }
}