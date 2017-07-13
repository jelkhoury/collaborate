using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Models
{
    public class DestinationSummary
    {
        public int DestinationId { get; set; }

        public string DestinationName { get; set; }

        public int UnreadMessagesCount { get; set; }
    }
}
