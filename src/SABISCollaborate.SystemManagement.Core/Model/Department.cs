using SABISCollaborate.SharedKernel;

namespace SABISCollaborate.System.Core.Model
{
    public class Department : Entity
    {
        public int Id { get; protected set; }

        public string Title { get; set; }

        private Department()
        {

        }

        public Department(string title) : this()
        {
            this.Title = title;
        }
    }
}
