using SABISCollaborate.SharedKernel.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Registration.Core.Model
{
    public class EmploymentInfo : ValueObject
    {
        #region Properties
        public ICollection<UserPosition> Positions { get; private set; }

        public DateTime EmploymentDate { get; private set; }
        #endregion

        #region Constructors
        private EmploymentInfo() { }

        public EmploymentInfo(DateTime employmentDate, ICollection<UserPosition> positions)
        {
            if (positions == null)
            {
                throw new ArgumentNullException("positions");
            }
            if (positions.Count == 0)
            {
                throw new ArgumentOutOfRangeException("A user cannot exists without department");
            }

            //user is already in department {newId}

            this.Positions = positions;
            this.EmploymentDate = employmentDate;
        }
        #endregion

        #region Methods
        public EmploymentInfo WithEmploymentDate(DateTime employmentDate)
        {
            return new EmploymentInfo(employmentDate, this.Positions);
        }

        public void Enroll(UserPosition position)
        {
            if (position == null)
            {
                throw new ArgumentNullException("position");
            }
            this.Positions.Add(position);
        }
        #endregion
    }
}
