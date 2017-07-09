using SABISCollaborate.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SABISCollaborate.Chat.Core.Model
{
    public class GroupMember : ValueObject
    {
        public int UserId { get; set; }

        public int GroupId { get; set; }
    }
}
