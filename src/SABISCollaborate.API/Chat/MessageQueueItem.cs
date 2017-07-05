using SABISCollaborate.API.Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Chat
{
    public class MessageQueueItem
    {
        ///// <summary>
        ///// Usernames of the receivers when the message arrived, some will not have a connection
        ///// </summary>
        //public List<int> AllReceivers { get; set; }

        /// <summary>
        /// Connections to whom the message should be pushed
        /// </summary>
        public List<string> ConnectionsToPush { get; set; }

        /// <summary>
        /// Connections that ACK the push message
        /// </summary>
        public List<string> AcknowledgedConnections { get; set; }

        /// <summary>
        /// Information about the pushed instances (message push history)
        /// </summary>
        public List<MessageDispatchInstance> DispatchedInstances { get; set; }

        public int Destination
        {
            get
            {
                return this.Message.DestinationId;
            }
        }

        public ClientMessage Message { get; set; }

        public List<string> GetPendingConnections()
        {
            TimeSpan ellapsed = new TimeSpan(0, 0, 3);

            // not ack and (not dispatched or dispatched but not longer than 3 sec)
            List<string> result = this.ConnectionsToPush.FindAll(c => !this.AcknowledgedConnections.Contains(c)
                // not dispatched or dispatched but still valid
                && this.DispatchedInstances.FirstOrDefault(di => di.ConnectionId == c && (DateTime.Now - di.SentDate <= ellapsed)) == null);

            return result;
        }

        public MessageQueueItem()
        {
            //this.AllReceivers = new List<int>();
            this.AcknowledgedConnections = new List<string>();
            this.DispatchedInstances = new List<MessageDispatchInstance>();
        }

        public MessageQueueItem(List<string> connectionsToPush, ClientMessage chatMessage) : this()
        {
            //this.AllReceivers = allReceivers;
            this.ConnectionsToPush = connectionsToPush;
            this.Message = chatMessage;
        }
    }
}
