using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Management.Core.Registration.Model
{
    public class EmploymentInfo
    {
        #region Properties
        public List<int> DepartmentIds { get; protected set; }

        public List<Department> Departments { get; private set; }

        public int PositionId { get; protected set; }

        public Position Position { get; private set; }

        public DateTime EmploymentDate { get; set; }
        #endregion

        #region Constructors
        private EmploymentInfo()
        {

        }

        //public EmploymentInfo(List<Department> departments, Position position, DateTime employmentDate)
        //{
        //    if (departments == null)
        //    {
        //        throw new ArgumentNullException("departments");
        //    }
        //    if (departments.Count == 0)
        //    {
        //        throw new ArgumentOutOfRangeException("A user cannot exists without department");
        //    }
        //    this.AddDepartments(departments.ToArray());

        //    if (position == null)
        //    {
        //        throw new ArgumentNullException("position");
        //    }
        //    this.Position = position;
        //    this.EmploymentDate = employmentDate;
        //}

        public EmploymentInfo(List<int> departmentsIds, int positionId, DateTime employmentDate)
        {
            if (departmentsIds == null)
            {
                throw new ArgumentNullException("departmentsIds");
            }
            if (departmentsIds.Count == 0)
            {
                throw new ArgumentOutOfRangeException("A user cannot exists without department");
            }
            this.AddDepartments(departmentsIds.ToArray());

            if (positionId == default(int))
            {
                throw new ArgumentNullException("positionId");
            }
            this.PositionId = positionId;
            this.EmploymentDate = employmentDate;
        }
        #endregion

        #region Methods
        public void AddDepartments(params int[] ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException("ids");
            }

            foreach (int newId in ids)
            {
                if (this.DepartmentIds.Contains(newId))
                {
                    throw new ArgumentException($"user is already in department {newId}");
                }
                this.DepartmentIds.Add(newId);
            }
        }

        //public void AddDepartments(params Department[] departments)
        //{
        //    if (departments == null)
        //    {
        //        throw new ArgumentNullException("departments");
        //    }

        //    foreach (Department department in Departments)
        //    {
        //        if (this.Departments.Find(d => d.Id == department.Id) != null)
        //        {
        //            throw new ArgumentException($"user is already in department {department.Title}");
        //        }
        //        this.Departments.Add(department);
        //        this.DepartmentIds.Add(department.Id);
        //    }
        //} 
        #endregion
    }
}
