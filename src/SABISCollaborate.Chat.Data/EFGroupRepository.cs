using SABISCollaborate.SharedKernel;
using SABISCollaborate.System.Core.Model.Chat;
using SABISCollaborate.System.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using SABISCollaborate.SharedKernel.Interfaces;
using SABISCollaborate.System.Core.Model;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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
