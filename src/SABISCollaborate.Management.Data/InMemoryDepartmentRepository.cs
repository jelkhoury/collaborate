using SABISCollaborate.Management.Core.Registration.Interfaces;
using SABISCollaborate.Management.Core.Registration.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Management.Data
{
    public class InMemoryDepartmentRepository: IDepartmentRepository
    {
        private List<Department> _departments = new List<Department>();
        public InMemoryDepartmentRepository()
        {
            this._departments.Add(new Department("Academics"));
            this._departments.Add(new Department("Books"));
            this._departments.Add(new Department("IT Department"));
        }

        public List<Department> GetAll()
        {
            return _departments;
        }

        public Department AddDepartment(string DepartmentName)
        {
            Department newDept = new Department(DepartmentName);
            if (!_departments.Contains(newDept))
            {
                _departments.Add(newDept);
            }
            return newDept;
        }
    }
}
