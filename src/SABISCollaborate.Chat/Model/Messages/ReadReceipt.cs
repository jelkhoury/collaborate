using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Chat.Core.Model.Messages
{
    public class ReadReceipt
    {
        public int Id { get; set; }

        public int TextMessageId { get; set; }

        public int UserId { get; set; }

        public DateTime ReadDate { get; set; }

        private ReadReceipt()
        {

        }

        public ReadReceipt(int messageId, int userId) : this()
        {
            this.TextMessageId = messageId;
            this.UserId = userId;
            this.ReadDate = DateTime.Now;
        }
    }
}
