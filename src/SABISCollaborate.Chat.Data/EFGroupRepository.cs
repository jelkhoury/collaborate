using Microsoft.EntityFrameworkCore;
using SABISCollaborate.Chat.Core.Model;
using SABISCollaborate.Chat.Core.Repositories;
using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;

namespace SABISCollaborate.System.Data
{
    public class EFGroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public EFGroupRepository(DbContext context) : base(context)
        {
        }

        public List<Group> GetUserGroups(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
