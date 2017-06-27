using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;

namespace SABISCollaborate.Profile.Core.Model
{
    public class EmploymentInfo : ValueObject
    {
        #region Properties
        public ICollection<UserPosition> Positions { get; private set; }

        public DateTime EmploymentDate { get; private set; }
        #endregion

        #region Constructors
        private EmploymentInfo() { }
        #endregion
    }
}
