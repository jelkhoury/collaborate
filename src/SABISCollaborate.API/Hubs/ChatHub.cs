using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SABISCollaborate.API.Chat;
using SABISCollaborate.API.Chat.Models;
using SABISCollaborate.API.Models;
using SABISCollaborate.Chat.Core.Model;
using SABISCollaborate.Chat.Core.Repositories;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SABISCollaborate.API.Hubs
{
    //[Microsoft.AspNetCore.SignalR.Authorize]
    public class ChatHub : Hub
    {
        #region Fields
        private readonly IMessageDispatcher _messageDispatcher;
        private readonly ITextMessageRepository _messageRepository;
        private readonly IGroupRepository _groupRepository;
        private AuthenticatedUser _user;
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
            this._user = new AuthenticatedUser(this.Context.User.Identity as ClaimsIdentity);
            this._messageDispatcher.RegisterConnection(this._user.Username, this._user.UserId, this.Context.ConnectionId);
        }

        public void AckMessage(AckMessage ackMessage)
        {
            ackMessage.ConnectionId = this.Context.ConnectionId;
            this._messageDispatcher.Ack(ackMessage);
        }

        public void SendMessage(ClientMessage message)
        {
            this._user = new AuthenticatedUser(this.Context.User.Identity as ClaimsIdentity);
            message.UserId = this._user.UserId;

            // add message to destination history
            Group destination = this._groupRepository.GetSingle(message.DestinationId);
            TextMessage textMessage = new TextMessage(message.UserId, message.Body, message.ClientSentDate, destination.GroupMembers.Select(m => m.UserId).ToList(), message.DestinationId, DestinationType.Group);
            textMessage.ReadByReceiver(this._user.UserId);

            this._messageRepository.Add(textMessage);
            this._messageRepository.Save();

            message.Id = textMessage.Id;
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
