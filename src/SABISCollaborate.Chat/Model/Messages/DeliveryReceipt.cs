using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Chat.Core.Model.Messages
{
    public class DeliveryReceipt
    {
        public int Id { get; set; }

        public int MessageId { get; set; }

        public int UserId { get; set; }

        public DateTime DeliveryDate { get; set; }
    }
}
