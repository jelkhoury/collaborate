using SABISCollaborate.SharedKernel;

namespace SABISCollaborate.SharedKernel.Core.Model
{
    /// <summary>
    /// Read-only Department, in the registration context we can only consume a department.
    /// </summary>
    public class Department : Entity
    {
        public int Id { get; protected set; }

        public string Name { get; protected set; }

        private Department() {
        }
    }
}
