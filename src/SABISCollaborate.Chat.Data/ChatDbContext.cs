using Microsoft.EntityFrameworkCore;
using SABISCollaborate.Chat.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Chat.Data
{
    public class ChatDbContext : DbContext
    {
        public DbSet<Group> Group { get; set; }

        public DbSet<TextMessage> TextMessage { get; set; }

        public ChatDbContext(DbContextOptions options) : base(options) { }
    }
}
