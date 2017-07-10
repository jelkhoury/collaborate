using System;

namespace SABISCollaborate.API.Chat.Models
{
    public class ClientMessage
    {
        public int Id { get; set; }

        public int DestinationId { get; set; }

        public string Body { get; set; }

        public string SenderConnectionId { get; set; }

        /// <summary>
        /// Delete later (get the user id from his claims)
        /// </summary>
        public int UserId { get; internal set; }

        /// <summary>
        /// Gets or sets the sender username
        /// </summary>
        public string Sender { get; internal set; }

        public DateTime ClientSentDate { get; set; }
    }
}
