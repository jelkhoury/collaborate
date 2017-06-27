using SABISCollaborate.SharedKernel;

namespace SABISCollaborate.System.Core.Model
{
    public class Department : Entity
    {
        public int Id { get; protected set; }

        public string Name { get; set; }

        private Department()
        {

        }

        public Department(string name) : this()
        {
            this.Name = name;
        }
    }
}
