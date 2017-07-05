using SABISCollaborate.Chat.Core.Model;
using SABISCollaborate.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace SABISCollaborate.Chat.Core.Repositories
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        List<Group> GetUserGroups(int userId);
    }
}
