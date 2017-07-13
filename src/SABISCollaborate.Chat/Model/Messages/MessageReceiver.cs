using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Chat.Core.Model.Messages
{
    public class MessageReceiver : ValueObject
    {
        public int MessageId { get; set; }

        public int UserId { get; set; }

        public bool IsRead { get; set; }
    }
}
