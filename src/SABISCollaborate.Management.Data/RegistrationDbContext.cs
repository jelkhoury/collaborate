using Microsoft.EntityFrameworkCore;
using SABISCollaborate.Registration.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Registration.Data
{
    public class RegistrationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
