using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using SABISCollaborate.API.Chat.Models;
using SABISCollaborate.API.Hubs;
using SABISCollaborate.Chat.Core.Model;
using SABISCollaborate.Chat.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Chat
{
    public class MessageDispatcher : IMessageDispatcher
    {
        private IConnectionManager _connectionManager;
        private IHubContext _chatHub;
        private List<ConnectedUser> _connectedUsers = new List<ConnectedUser>();
        private List<MessageSender> _messageSenders;
        private IGroupRepository _groupRepository;

        public MessageDispatcher(IConnectionManager connectionManager, IGroupRepository groupRepository)
        {
            this._connectionManager = connectionManager;
            this._chatHub = this._connectionManager.GetHubContext<ChatHub>();
            this._messageSenders = new List<MessageSender>();
            this._groupRepository = groupRepository;
        }

        public void RegisterConnection(string username, int userId, string connectionId)
        {
            this._connectedUsers.RemoveAll(u => u.ConnectionId == connectionId);

            this._connectedUsers.Add(new ConnectedUser
            {
                ConnectionId = connectionId,
                UserId = userId,
                Username = username
            });
        }

        public void UnregisterConnection(string connectionId)
        {
            this._connectedUsers.RemoveAll(u => u.ConnectionId == connectionId);
        }

        public void SendAsync(ClientMessage message)
        {
            // set sender username (will be pushed to the destination users)
            ConnectedUser sender = this._connectedUsers.FirstOrDefault(u => u.UserId == message.UserId);
            if (sender != null)
            {
                message.Sender = sender.Username;
            }
            this.EnsureSender(message.DestinationId).SendAsync(message);
        }

        public void Ack(AckMessage ackMessage)
        {
            this.EnsureSender(ackMessage.DestinationId).Ack(ackMessage);
        }

        private MessageSender EnsureSender(int destinationId)
        {
            MessageSender result = this._messageSenders.FirstOrDefault(s => s.DestinationId == destinationId);
            if (result == null)
            {
                Group destination = this._groupRepository.GetSingle(destinationId);
                result = new MessageSender(destination, this._connectedUsers, this._chatHub);
                this._messageSenders.Add(result);
            }

            return result;
        }
    }
}
