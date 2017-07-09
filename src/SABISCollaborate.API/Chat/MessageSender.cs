using Microsoft.AspNetCore.SignalR;
using SABISCollaborate.API.Chat.Models;
using SABISCollaborate.Chat.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SABISCollaborate.API.Chat
{
    public class MessageSender : IDisposable
    {
        #region Fields
        private readonly CancellationTokenSource _cancellableToken;
        private readonly List<MessageQueueItem> _pendingMessages;
        private List<ConnectedUser> _connectedUsers;
        private readonly Group _group;
        private readonly IHubContext _chatHub;
        #endregion

        #region Properties
        public int DestinationId { get; private set; }
        #endregion

        #region Constructors
        public MessageSender(int destinationId, List<ConnectedUser> connectedUsers, IHubContext chatHub)
        {
            this.DestinationId = destinationId;
            this._cancellableToken = new CancellationTokenSource();
            this._pendingMessages = new List<MessageQueueItem>();
            this._connectedUsers = connectedUsers;
            this._chatHub = chatHub;

            //IGroupRepository groupRepository = new InMemoryGroupRepository();
            //this._group = groupRepository.GetById(this.DestinationId);

            ThreadPool.QueueUserWorkItem(new WaitCallback(this.SendPendingMessages), this._cancellableToken.Token);
        }
        #endregion

        #region Methods
        public void SendAsync(ClientMessage message)
        {
            // get connected members
            List<string> connectedReceivers = this._connectedUsers
                    .FindAll(u => this._group.Members.Contains(u.UserId))
                    .Select(cu => cu.ConnectionId)
                    .ToList();
            connectedReceivers.Remove(message.SenderConnectionId);

            // create message queue item
            //MessageQueueItem queueItem = new MessageQueueItem(this._group.Members, connectedReceivers, message);
            MessageQueueItem queueItem = new MessageQueueItem(connectedReceivers, message);

            lock (this._pendingMessages)
            {
                if (this._pendingMessages.FirstOrDefault(m => m.Message.Id == message.Id) == null)
                {
                    this._pendingMessages.Add(queueItem);
                }
            }
        }

        public void Ack(AckMessage ackMessage)
        {
            // get message from queue
            MessageQueueItem message = this._pendingMessages.FirstOrDefault(qm => qm.Message.Id == ackMessage.MessageId);

            if (message != null)
            {
                // add acknowledged receiver
                message.AcknowledgedConnections.Add(ackMessage.ConnectionId);

                // remove message from queue if needed (>= in case 2 ack were received from the same connection)
                if (message.AcknowledgedConnections.Count >= message.ConnectionsToPush.Count)
                {
                    lock (this._pendingMessages)
                    {
                        this._pendingMessages.Remove(message);
                    }
                }
            }
        }

        private void SendPendingMessages(object state)
        {
            CancellationToken token = (CancellationToken)state;

            while (token.IsCancellationRequested == false)
            {
                Thread.Sleep(20);
                lock (this._pendingMessages)
                {
                    // loop on messages
                    this._pendingMessages.ForEach(m =>
                    {
                        // loop on pending receivers
                        List<string> pendingConnections = m.GetPendingConnections();
                        pendingConnections.ForEach(c =>
                        {
                            ConnectedUser connection = this._connectedUsers.FirstOrDefault(u => u.ConnectionId == c);
                            if (connection != null)
                            {
                                this._chatHub.Clients.Client(connection.ConnectionId).messageReceived(m.Message);
                                m.DispatchedInstances.Add(new MessageDispatchInstance(c));
                            }
                            else
                            {
                                m.ConnectionsToPush.Remove(c);
                            }
                        });
                    });
                }
            }
        }

        public void Dispose()
        {
            this._cancellableToken.Cancel();
        }
        #endregion
    }
}
