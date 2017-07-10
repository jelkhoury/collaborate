using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Chat.Core.Model.Messages
{
    public class ReadReceipt
    {
        public int Id { get; set; }

        public int MessageId { get; set; }

        public int UserId { get; set; }

        public DateTime ReadDate { get; set; }
    }
}
