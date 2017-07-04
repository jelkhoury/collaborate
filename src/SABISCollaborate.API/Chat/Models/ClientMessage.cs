using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Chat.Models
{
    public class ClientMessage
    {
        public string Id { get; set; }

        public int DestinationId { get; set; }

        public string Body { get; set; }

        public string SenderConnectionId { get; set; }

        /// <summary>
        /// Delete later (get the user id from his claims)
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the sender username
        /// </summary>
        public string Sender { get; set; }

        public DateTime ClientSentDate { get; set; }

        public TextMessage CreateTextMessage(int senderId, List<int> receivers)
        {
            TextMessage result = new TextMessage
            {
                SenderUserId = senderId,
                Text = this.Body,
                SenderDate = this.ClientSentDate,
                Destination = new MessageDestination
                {
                    DestinationId = this.DestinationId,
                    DestinationType = 1
                }
            };

            return result;
        }
    }
}
