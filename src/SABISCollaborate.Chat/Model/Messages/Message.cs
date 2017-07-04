using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.System.Core.Model.Chat
{
    public class Message
    {
        public int Id { get; set; }

        public int SenderUserId { get; set; }

        public DateTime SenderDate { get; set; }

        public MessageDestination Destination { get; set; }

        public List<int> Receivers { get; set; }

        public List<int> Readers { get; set; }
    }
}
