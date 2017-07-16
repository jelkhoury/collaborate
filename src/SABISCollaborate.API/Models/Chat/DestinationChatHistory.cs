using SABISCollaborate.Chat.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Models.Chat
{
    public class DestinationChatHistory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<string> Members { get; set; }

        public List<TextMessageHistory> Messages { get; set; }

        public DestinationChatHistory(Group group, List<string> members)
        {
            this.Id = group.Id;
            this.Name = group.Name;
            this.Members = members;
            this.Messages = new List<TextMessageHistory>();
        }
    }
}
