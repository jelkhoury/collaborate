using SABISCollaborate.Management.Core.Registration.Interfaces;
using SABISCollaborate.SharedKernel.Enums;
using System;

namespace SABISCollaborate.Management.Core.Registration.Model
{
    public class UserProfile : Entity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
