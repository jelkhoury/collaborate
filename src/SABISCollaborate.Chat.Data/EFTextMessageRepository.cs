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
    public class EFTextMessageRepository : GenericRepository<TextMessage>, ITextMessageRepository
    {
        public ChatDbContext Context
        {
            get
            {
                return this.DbContext as ChatDbContext;
            }
        }

        public EFTextMessageRepository(ChatDbContext context) : base(context)
        {
        }

        public List<TextMessage> GetUnread(int userId)
        {
            List<TextMessage> result = this.Context.TextMessage
                .Include(tm => tm.MessageReceivers)
                .Where(tm => tm.MessageReceivers.FirstOrDefault(mr => mr.UserId == userId && mr.IsRead == false) != null)
                .ToList();

            return result;
        }

        public List<TextMessage> GetUnreadByGroup(int userId, List<int> groupsIds)
        {
            List<TextMessage> result = this.FindBy(m => groupsIds.Contains(m.DestinationId))
                .Where(m => m.ReadReceipts.Where(rr => rr.UserId == userId) == null)
                .ToList();

            return result;
        }
    }
}
