using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Models.Chat
{
    public class TextMessageHistory
    {
        public int Id { get; set; }

        public string Sender { get; set; }

        public int SenderUserId { get; set; }

        public string Text { get; set; }

        public bool IsRead { get; set; }

        public DateTime DateSent { get; set; }

        public DateTime DateReceived { get; set; }
    }
}
