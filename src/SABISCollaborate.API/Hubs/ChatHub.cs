using Microsoft.AspNetCore.SignalR;
using SABISCollaborate.API.Chat;
using SABISCollaborate.API.Chat.Models;
using SABISCollaborate.Chat.Core.Model;
using SABISCollaborate.Chat.Core.Repositories;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Hubs
{
    [Authorize]
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

        public void Register()
        {
            string username = (this.Context.User.Identity as ClaimsPrincipal).FindFirst("preferred_username").Value;
            int userId = int.Parse((this.Context.User.Identity as ClaimsPrincipal).FindFirst("id").Value);

            this._messageDispatcher.RegisterConnection(username, userId, this.Context.ConnectionId);
        }

        public void AckMessage(AckMessage ackMessage)
        {
            ackMessage.ConnectionId = this.Context.ConnectionId;
            this._messageDispatcher.Ack(ackMessage);
        }

        public void SendMessage(ClientMessage message)
        {
            // add message to destination history
            Group destination = this._groupRepository.GetSingle(message.DestinationId);
            TextMessage textMessage = message.CreateTextMessage(message.UserId, destination.Members);
            this._messageRepository.Add(textMessage);

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
