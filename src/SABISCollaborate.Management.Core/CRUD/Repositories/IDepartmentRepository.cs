using SABISCollaborate.Registration.Core.CRUD.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Registration.Core.CRUD.Repositories
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();

        Department SaveDepartment(Department department);

        void Delete(int departmentId);
    }
}
