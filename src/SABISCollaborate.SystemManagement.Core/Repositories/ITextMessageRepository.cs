using SABISCollaborate.SharedKernel.Interfaces;
using SABISCollaborate.System.Core.Model.Chat;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.System.Core.Repositories
{
    public interface ITextMessageRepository : IGenericRepository<TextMessage>
    {
        List<TextMessage> GetUnread(int userId);

        List<TextMessage> GetUnreadByGroup(int userId, List<int> groupsIds);
    }
}
