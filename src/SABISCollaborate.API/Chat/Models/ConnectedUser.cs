﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Chat.Models
{
    public class ConnectedUser
    {
        public string ConnectionId { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }
    }
}
