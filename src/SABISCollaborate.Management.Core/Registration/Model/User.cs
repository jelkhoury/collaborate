using SABISCollaborate.Management.Core.Registration.Interfaces;

namespace SABISCollaborate.Management.Core.Registration.Model
{
    public class User : Entity
    {
        public int Id { get; private set; }
        public string Username { get; set; }
        public string IdentifierEmail { get; set; }
        public UserProfile Profile { get; private set; }
        public string PasswordHash { get; private set; }

        private User()
        {
        }

        public User(string username, string passwordHash, string email, UserProfile profile) 
            : this(0, username, passwordHash, email, profile)
        {

        }

        public User(int id, string username, string passwordHash, string email, UserProfile profile)
        {
            this.Id = id;
            this.Username = username;
            this.IdentifierEmail = email;
            this.Profile = profile;
            this.PasswordHash = passwordHash;
        }
    }
}
