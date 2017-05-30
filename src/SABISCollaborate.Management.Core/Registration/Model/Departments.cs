using SABISCollaborate.Management.Core.Registration.Interfaces;

namespace SABISCollaborate.Management.Core.Registration.Model
{
    public class Department : Entity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Department(string description)
        {
            this.Description = description;
        }
        
    }
}
