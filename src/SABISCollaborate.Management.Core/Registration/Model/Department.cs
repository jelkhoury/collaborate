using SABISCollaborate.SharedKernel;

namespace SABISCollaborate.Management.Core.Registration.Model
{
    /// <summary>
    /// Read-only Department, in the registration context we can only consume a department.
    /// </summary>
    public class Department : Entity
    {
        public int Id { get; protected set; }

        public string Title { get; protected set; }

        private Department() { }
    }
}
