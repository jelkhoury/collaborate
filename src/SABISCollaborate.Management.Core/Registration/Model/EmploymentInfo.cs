using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Management.Core.Registration.Model
{
    public class EmploymentInfo
    {
        #region Properties
        //public List<int> DepartmentIds { get; protected set; }

        public List<Department> Departments { get; protected set; }

        //public int PositionId { get; protected set; }

        public Position Position { get; protected set; }

        public DateTime EmploymentDate { get; set; }
        #endregion

        #region Constructors
        private EmploymentInfo()
        {

        }

        public EmploymentInfo(List<Department> departments, Position position, DateTime employmentDate)
        {
            if (departments == null)
            {
                throw new ArgumentNullException("departments");
            }
            if (departments.Count == 0)
            {
                throw new ArgumentOutOfRangeException("A user cannot exists without department");
            }
            this.AddDepartments(departments.ToArray());

            if (position == null)
            {
                throw new ArgumentNullException("position");
            }
            this.Position = position;
            this.EmploymentDate = employmentDate;
        }
        #endregion

        #region Methods
        public void AddDepartments(params Department[] departments)
        {
            if (departments == null)
            {
                throw new ArgumentNullException("departments");
            }

            foreach (Department department in Departments)
            {
                if (this.Departments.Find(d => d.Id == department.Id) != null)
                {
                    throw new ArgumentException($"user is already in department {department.Description}");
                }
                this.Departments.Add(department);
            }
        } 
        #endregion
    }
}
