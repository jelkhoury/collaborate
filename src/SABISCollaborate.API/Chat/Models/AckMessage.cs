using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Chat.Models
{
    public class AckMessage
    {
        public string ConnectionId { get; set; }

        public int DestinationId { get; set; }

        public int MessageId { get; set; }
    }
}
