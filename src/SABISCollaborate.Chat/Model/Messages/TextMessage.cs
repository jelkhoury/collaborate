using SABISCollaborate.Chat.Core.Model.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SABISCollaborate.Chat.Core.Model
{
    public class TextMessage : Message
    {
        public string Text { get; set; }

        private TextMessage()
        {

        }

        public TextMessage(int senderUserId, string text, DateTime senderDate, List<int> receivers, int destinationId, DestinationType destinationType)
        {
            this.SenderUserId = senderUserId;
            this.Text = text;
            this.SenderDate = senderDate;
            this.DestinationId = destinationId;
            this.DestinationType = destinationType;
            this.MessageReceivers = receivers.Select(r => new MessageReceiver(this.Id, r)).ToList();
            this.ReadReceipts = new List<ReadReceipt>();
            this.DeliveryReceipts = new List<DeliveryReceipt>();
        }
    }
}
