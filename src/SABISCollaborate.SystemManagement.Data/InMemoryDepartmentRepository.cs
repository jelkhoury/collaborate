using System.Collections.Generic;
using System;
using SABISCollaborate.SystemManagement.Core.Repositories;
using SABISCollaborate.SystemManagement.Core.Model;

namespace SABISCollaborate.SystemManagement.Data
{
    public class InMemoryDepartmentRepository : IDepartmentRepository
    {
        private List<Department> _departments = new List<Department>();

        public InMemoryDepartmentRepository()
        {
            this._departments.Add(new Department("Academics"));
            this._departments.Add(new Department("Books"));
            this._departments.Add(new Department("IT Department"));
            for (int i = 0; i < this._departments.Count; i++)
            {
                this._departments[i].Id = i + 1;
            }
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

       

        public void Delete(int departmentId)
        {
            throw new NotImplementedException();
        }
    }
}
