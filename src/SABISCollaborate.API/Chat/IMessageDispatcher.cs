using SABISCollaborate.API.Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Chat
{
    public interface IMessageDispatcher
    {
        void RegisterConnection(string username, int userId, string connectionId);

        void UnregisterConnection(string connectionId);

        void SendAsync(ClientMessage message);

        void Ack(AckMessage ack);
    }
}
