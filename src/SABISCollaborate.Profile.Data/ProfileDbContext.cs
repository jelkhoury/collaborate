using Microsoft.EntityFrameworkCore;
using SABISCollaborate.Profile.Core.Model;

namespace SABISCollaborate.Profile.Data
{
    public class ProfileDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
        {
        }
    }
}
