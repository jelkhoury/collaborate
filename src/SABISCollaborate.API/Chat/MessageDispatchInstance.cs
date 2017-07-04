using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Chat
{
    public class MessageDispatchInstance
    {
        public string ConnectionId { get; set; }

        public DateTime SentDate { get; set; }

        private MessageDispatchInstance()
        {

        }

        public MessageDispatchInstance(string connectionId) : this()
        {
            this.ConnectionId = connectionId;
            this.SentDate = DateTime.Now;
        }
    }
}
