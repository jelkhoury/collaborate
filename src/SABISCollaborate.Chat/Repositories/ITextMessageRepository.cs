using SABISCollaborate.Chat.Core.Model;
using SABISCollaborate.SharedKernel.Interfaces;
using System.Collections.Generic;

namespace SABISCollaborate.Chat.Core.Repositories
{
    public interface ITextMessageRepository : IGenericRepository<TextMessage>
    {
        //List<TextMessage> GetUnread(int userId);

        List<TextMessage> GetUnreadByGroup(int userId, List<int> groupsIds);
    }
}
