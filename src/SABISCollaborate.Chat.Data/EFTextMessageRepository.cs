using Microsoft.EntityFrameworkCore;
using SABISCollaborate.Chat.Core.Model;
using SABISCollaborate.Chat.Core.Repositories;
using SABISCollaborate.Chat.Data;
using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;

namespace SABISCollaborate.System.Data
{
    public class EFTextMessageRepository : GenericRepository<TextMessage>, ITextMessageRepository
    {
        public EFTextMessageRepository(ChatDbContext context) : base(context)
        {
        }

        public List<TextMessage> GetUnread(int userId)
        {
            throw new NotImplementedException();
        }

        public List<TextMessage> GetUnreadByGroup(int userId, List<int> groupsIds)
        {
            throw new NotImplementedException();
        }
    }
}
