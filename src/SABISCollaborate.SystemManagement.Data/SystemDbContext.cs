using Microsoft.EntityFrameworkCore;
using SABISCollaborate.System.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.System.Data
{
    public class SystemDbContext : DbContext
    {
        public DbSet<Department> Department { get; set; }
        public DbSet<Position> Position { get; set; }

        public SystemDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
