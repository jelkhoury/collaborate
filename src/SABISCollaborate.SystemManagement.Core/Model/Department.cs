using SABISCollaborate.SharedKernel;

namespace SABISCollaborate.SystemManagement.Core.Model
{
    public class Department : Entity
    {
        public string Title { get; set; }

        public Department(string title)
        {
            this.Title = title;
        }
    }
}
