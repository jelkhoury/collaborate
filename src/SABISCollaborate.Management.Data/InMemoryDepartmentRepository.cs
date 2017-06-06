using SABISCollaborate.Registration.Core.CRUD.Model;
using SABISCollaborate.Registration.Core.CRUD.Repositories;
using System.Collections.Generic;
using System;

namespace SABISCollaborate.Registration.Data
{
    public class InMemoryDepartmentRepository : IDepartmentRepository
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

        public Department SaveDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void Delete(int departmentId)
        {
            throw new NotImplementedException();
        }
    }
}
