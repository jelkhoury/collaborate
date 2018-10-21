using Microsoft.EntityFrameworkCore;
using SABISCollaborate.Users.Core.Models;

namespace SABISCollaborate.Users.Infrastructure
{
    public class ProfileDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
        {
        }
    }
}
