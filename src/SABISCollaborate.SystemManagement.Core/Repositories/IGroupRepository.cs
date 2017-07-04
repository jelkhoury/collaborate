using SABISCollaborate.SharedKernel.Interfaces;
using SABISCollaborate.System.Core.Model.Chat;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.System.Core.Repositories
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        List<Group> GetUserGroups(int userId);
    }
}
