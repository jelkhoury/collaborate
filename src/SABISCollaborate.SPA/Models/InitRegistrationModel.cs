using SABISCollaborate.SystemManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.SPA.Models
{
    public class InitRegistrationModel
    {
        public List<Department> Departments { get; set; }

        public List<Position> Positions { get; set; }
    }
}
