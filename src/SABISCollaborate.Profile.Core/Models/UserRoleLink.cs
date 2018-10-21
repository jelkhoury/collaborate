using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Users.Core.Models
{
    public class UserRoleLink : Entity
    {
        public int Id { get; private set; }

        public int UserId { get; private set; }

        public int RoleId { get; private set; }

        public Role Role { get; set; }

        private UserRoleLink()
        {

        }
    }
}
