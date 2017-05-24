using SABISCollaborate.Management.Core.Registration.Interfaces;
using SABISCollaborate.SharedKernel.Enums;

namespace SABISCollaborate.Management.Core.Registration.Model
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
