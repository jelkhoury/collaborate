using SABISCollaborate.SharedKernel;
using SABISCollaborate.SharedKernel.Enums;
using System;

namespace SABISCollaborate.Management.Core.Registration.Model
{
    public class UserProfile : Entity
    {
        public int Id { get; protected set; }

        public string Nickname { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public DateTime BirthDate { get; set; }

        public EmploymentInfo EmploymentInfo { get; set; }

        //private UserProfile() { }
    }
}
