using SABISCollaborate.API.Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Chat
{
    public class MessageQueueItem
    {
        /// <summary>
        /// Connections to whom the message should be pushed
        /// </summary>
        public List<string> ConnectionsToPush { get; set; }
        
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
            TimeSpan ellapsed = new TimeSpan(0, 0, 5);

            // not ack and (not dispatched or dispatched but not longer than 5 sec)
            List<string> result = this.ConnectionsToPush.FindAll(c => 
                // not dispatched or dispatched but still valid
                this.DispatchedInstances.FirstOrDefault(di => di.ConnectionId == c && (DateTime.Now - di.SentDate <= ellapsed)) == null);

            return result;
        }

        public MessageQueueItem()
        {
            this.DispatchedInstances = new List<MessageDispatchInstance>();
        }

        public MessageQueueItem(List<string> connectionsToPush, ClientMessage chatMessage) : this()
        {
            this.ConnectionsToPush = connectionsToPush;
            this.Message = chatMessage;
        }
    }
}
