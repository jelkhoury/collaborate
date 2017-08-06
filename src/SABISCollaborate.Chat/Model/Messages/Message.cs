using SABISCollaborate.Chat.Core.Model.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void ReadByReceiver(int userId)
        {
            if (userId == default(int)) throw new ArgumentOutOfRangeException(nameof(userId), $"{userId} is not a valid user id");
            MessageReceiver receiver = this.MessageReceivers.FirstOrDefault(mr => mr.UserId == userId);
            if (receiver == null) throw new ArgumentOutOfRangeException(nameof(userId), $"Message {this.Id} is not intented for receiver {userId}");

            ReadReceipt readReceipt = new ReadReceipt(this.Id, userId);
            this.ReadReceipts.Add(readReceipt);
            receiver.ReadReceipt = readReceipt;
        }
    }
}
