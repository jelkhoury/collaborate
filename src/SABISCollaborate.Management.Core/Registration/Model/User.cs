using SABISCollaborate.Management.Core.Registration.Interfaces;

namespace SABISCollaborate.Management.Core.Registration.Model
{
    public class User : Entity
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string IdentifierEmail { get; private set; }
        public UserProfile Profile { get; private set; }
        public string PasswordHash { get; private set; }

        private User()
        {
        }

        public User(string username, string password, string email, UserProfile profile)
        {
            this.Username = username;
            this.IdentifierEmail = email;
            this.Profile = profile;
            this.PasswordHash = this.ComputePasswordHash(password);
        }

        private string ComputePasswordHash(string password)
        {
            return password + "123";
        }
    }
}
