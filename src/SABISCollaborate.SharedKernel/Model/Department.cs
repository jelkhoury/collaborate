using SABISCollaborate.SharedKernel;

namespace SABISCollaborate.SharedKernel.Core.Model
{
    /// <summary>
    /// Read-only Department, in the registration context we can only consume a department.
    /// </summary>
    public class Department : Entity
    {
        public int Id { get; protected set; }

        public string Title { get; protected set; }

        public Department(int id, string title) {
            this.Id = id;
            this.Title = title;
        }
    }
}
