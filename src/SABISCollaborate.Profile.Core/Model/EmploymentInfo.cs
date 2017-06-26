using SABISCollaborate.SharedKernel.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Profile.Core.Model
{
    public class EmploymentInfo
    {
        #region Properties
        public List<int> DepartmentIds { get; protected set; }

        public List<Department> Departments { get; private set; }

        public int PositionId { get; protected set; }

        public Position Position { get; private set; }

        public DateTime EmploymentDate { get; private set; }
        #endregion

        #region Constructors
        private EmploymentInfo()
        {

        }
        #endregion
    }
}
