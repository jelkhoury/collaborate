using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.API.Chat;
using SABISCollaborate.API.Models;
using SABISCollaborate.API.Models.Chat;
using SABISCollaborate.Chat.Core.Model;
using SABISCollaborate.Chat.Core.Model.Messages;
using SABISCollaborate.Chat.Core.Repositories;
using SABISCollaborate.Profile.Core.Model;
using SABISCollaborate.Profile.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SABISCollaborate.API.Controllers
{
    [Authorize]
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        private readonly ITextMessageRepository _messageRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IProfileService _profileService;

        public ChatController(ITextMessageRepository messageRepository, IGroupRepository groupRepository, IProfileService profileService)
        {
            this._messageRepository = messageRepository;
            this._groupRepository = groupRepository;
            this._profileService = profileService;
        }

        /// <summary>
        /// Get groups of the current user with the number of unread messages in each group
        /// </summary>
        /// <returns>List of groups summary</returns>
        [HttpGet("groups/summary")]
        public IActionResult GetGroupsWithSummary()
        {
            List<DestinationSummary> result = new List<DestinationSummary>();
            int userId = base.CurrentUser.UserId;

            // get unread messages
            List<TextMessage> unreadMessages = this._messageRepository.GetUnread(userId);
            List<Group> groups = this._groupRepository.GetUserGroups(userId);
            groups.ForEach(g =>
            {
                result.Add(new DestinationSummary
                {
                    DestinationId = g.Id,
                    DestinationName = g.Name,
                    UnreadMessagesCount = unreadMessages.Count(m => m.DestinationId == g.Id)
                });
            });
            return Ok(result);
        }

        [HttpGet("group/history")]
        public IActionResult GetGroupHistory(int groupId)
        {
            Group group = this._groupRepository.GetSingle(groupId);
            List<User> members = this._profileService.GetByIds(group.GroupMembers.Select(gm => gm.UserId).ToList());
            // last 30 message + read receipts
            List<TextMessage> messages = this._messageRepository.FindBy(m => m.DestinationId == groupId && m.MessageReceivers.FirstOrDefault(mr => mr.UserId == this.CurrentUser.UserId) != null, m => m.MessageReceivers, m => m.ReadReceipts)
                .OrderByDescending(m => m.SenderDate)
                .Take(30)
                .ToList();

            // senders info
            List<User> senders = this._profileService.GetByIds(messages.Select(m => m.SenderUserId).ToList());

            DestinationChatHistory result = new DestinationChatHistory(group, members.Select(m => m.Profile.Nickname).ToList());
            messages.ForEach(m =>
            {
                ReadReceipt readReceipt = m.ReadReceipts.FirstOrDefault(r => r.UserId == this.CurrentUser.UserId);
                User sender = senders.FirstOrDefault(s => s.Id == m.SenderUserId);
                TextMessageHistory history = new TextMessageHistory
                {
                    Id = m.Id,
                    Text = m.Text,
                    DateReceived = readReceipt != null ? readReceipt.ReadDate : DateTime.Now,
                    DateSent = m.SenderDate,
                    SenderUserId = m.SenderUserId,
                    Sender = sender?.Profile?.Nickname,
                    IsRead = readReceipt != null
                };
                result.Messages.Add(history);
            });

            result.Messages = result.Messages.OrderBy(m => m.DateSent).ToList();

            return Ok(result);
        }

        [HttpPost("message/read")]
        public IActionResult ReadMessage(int messageId)
        {
            TextMessage message = this._messageRepository.FindBy(m => m.Id == messageId, m => m.ReadReceipts, m => m.MessageReceivers).FirstOrDefault();
            if (message == null)
            {
                return BadRequest("Message not found");
            }

            if (!message.ReadReceipts.Contains(this.CurrentUser.UserId))
            {
                message.ReadByReceiver(this.CurrentUser.UserId);
                this._messageRepository.Edit(message);
                this._messageRepository.Save();
            }

            return Ok(message.Id);
        }

        [HttpPost("messages/read")]
        public IActionResult ReadMessages([FromBody] List<int> messagesId)
        {
            List<TextMessage> messages = this._messageRepository.FindBy(m => messagesId.Contains(m.Id), m => m.ReadReceipts, m => m.MessageReceivers).ToList();
            if (messages.Count == 0)
            {
                return BadRequest("No message found");
            }

            messages.ForEach(message =>
            {
                if (!message.ReadReceipts.Contains(this.CurrentUser.UserId))
                {
                    message.ReadByReceiver(this.CurrentUser.UserId);
                    this._messageRepository.Edit(message);
                }
            });
            this._messageRepository.Save();

            return Ok(messagesId);
        }

        [Route("unread")]
        public IActionResult GetUnreadMessages(int userId)
        {
            List<DestinationSummary> result = new List<DestinationSummary>();

            List<Group> groups = this._groupRepository.GetAll().ToList();//.GetUserGroups(userId);
            List<TextMessage> unreadMessages = this._messageRepository.GetUnreadByGroup(userId, groups.Select(g => g.Id).ToList());
            groups.ForEach(g =>
            {
                result.Add(new DestinationSummary
                {
                    DestinationId = g.Id,
                    DestinationName = g.Name,
                    UnreadMessagesCount = unreadMessages.Count(m => m.DestinationId == g.Id)
                });
            });

            return Ok(result);
        }
    }
}