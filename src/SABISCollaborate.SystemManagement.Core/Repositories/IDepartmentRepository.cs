using SABISCollaborate.SystemManagement.Core.Model;
using System.Collections.Generic;

namespace SABISCollaborate.SystemManagement.Core.Repositories
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();

        Department AddDepartment(string departmentName);

        void Delete(int departmentId);
    }
}
