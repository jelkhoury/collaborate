using SABISCollaborate.Management.Core.Registration.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Management.Core.Registration.Repositories
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
    }
}
