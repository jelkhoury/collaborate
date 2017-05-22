using SABISCollaborate.RegistrationManagement.Core.Interfaces;
using SABISCollaborate.SharedKernel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SABISCollaborate.RegistrationManagement.Core.Model
{
    public class UserProfile : Entity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }
    }
}
