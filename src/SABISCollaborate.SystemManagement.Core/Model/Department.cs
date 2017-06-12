using SABISCollaborate.SharedKernel;

namespace SABISCollaborate.SystemManagement.Core.Model
{
    public class Department : Entity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Department()
        {

        }

        public Department(string title) : this()
        {
            this.Title = title;
        }
    }
}
