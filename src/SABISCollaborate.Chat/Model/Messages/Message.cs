using SABISCollaborate.Chat.Core.Model.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Chat.Core.Model
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderUserId { get; set; }

        public DateTime SenderDate { get; set; }

        public int DestinationId { get; set; }

        public DestinationType DestinationType { get; set; }

        public virtual ICollection<MessageReceiver> MessageReceivers { get; set; }

        public virtual ICollection<ReadReceipt> ReadReceipts { get; set; }

        public virtual ICollection<DeliveryReceipt> DeliveryReceipts { get; set; }
    }
}
