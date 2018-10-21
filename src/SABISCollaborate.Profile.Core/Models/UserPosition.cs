using SABISCollaborate.SharedKernel;

namespace SABISCollaborate.Users.Core.Models
{
    public class UserPosition : ValueObject
    {
        #region Properties
        public int DepartmentId { get; private set; }

        public int PositionId { get; private set; } 
        #endregion

        #region Constructors
        private UserPosition()
        {

        } 
        #endregion
    }
}
