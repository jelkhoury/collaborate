using SABISCollaborate.Registration.Core.Model;
using System.Collections.Generic;

namespace SABISCollaborate.Registration.Core.Repositories
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
    }
}
