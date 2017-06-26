using SABISCollaborate.SharedKernel.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Registration.Core.Model
{
    public class UserPosition : ValueObject
    {
        public int DepartmentId { get; private set; }

        public int PositionId { get; private set; }

        private UserPosition()
        {

        }

        public UserPosition(int departmentId, int positionId)
        {
            this.DepartmentId = departmentId;
            this.PositionId = positionId;
        }
    }
}
