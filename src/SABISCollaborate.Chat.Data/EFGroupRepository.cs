using Microsoft.EntityFrameworkCore;
using SABISCollaborate.Chat.Core.Model;
using SABISCollaborate.Chat.Core.Repositories;
using SABISCollaborate.Chat.Data;
using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SABISCollaborate.System.Data
{
    public class EFGroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public EFGroupRepository(ChatDbContext context) : base(context)
        {
        }

        public override Group GetSingle(int id)
        {
            Group entity = this.DbContext.Set<Group>().Include(g => g.GroupMembers).FirstOrDefault(g => g.Id == id);
            return entity;
        }

        public List<Group> GetUserGroups(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
