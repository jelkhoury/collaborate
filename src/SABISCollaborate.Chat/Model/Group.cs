using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Chat.Core.Model
{
    public class Group
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public List<int> Members { get; set; }

        public int CreatedByUserId { get; set; }

        public int CurrentOwnerUserId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
