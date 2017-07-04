using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Hubs
{
    public class ChatHub : Hub
    {
        #region Fields
        private readonly IMessageDispatcher _messageDispatcher;
        private readonly ITextMessageRepository _messageRepository;
        private readonly IGroupRepository _groupRepository;
        #endregion

        #region Constructors
        public ChatHub(IMessageDispatcher messageDispatcher, ITextMessageRepository messageRepository, IGroupRepository groupRepository)
        {
            this._messageDispatcher = messageDispatcher;
            this._messageRepository = messageRepository;
            this._groupRepository = groupRepository;
        }
        #endregion

        public void Register(string username, int userId)
        {
            this._messageDispatcher.RegisterConnection(username, userId, this.Context.ConnectionId);
        }

        public void AckMessage(AckMessage ackMessage)
        {
            ackMessage.ConnectionId = this.Context.ConnectionId;
            this._messageDispatcher.Ack(ackMessage);
        }

        public void SendMessage(ChatMessage message)
        {
            // add message to destination history
            //Group destination = this._groupRepository.GetById(message.DestinationId);
            //TextMessage textMessage = message.CreateTextMessage(message.UserId, destination.Members);
            //this._messageRepository.Add(textMessage);

            message.SenderConnectionId = this.Context.ConnectionId;
            // dispatch message to connected users
            this._messageDispatcher.SendAsync(message);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            this._messageDispatcher.UnregisterConnection(this.Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }
}
