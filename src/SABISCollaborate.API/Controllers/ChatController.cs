using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.Chat.Core.Repositories;
using SABISCollaborate.Chat.Core.Model;
using SABISCollaborate.API.Models;
using Microsoft.AspNetCore.Authorization;
using SABISCollaborate.API.Chat;
using SABISCollaborate.API.Models.Chat;
using SABISCollaborate.Profile.Core.Services;
using SABISCollaborate.Profile.Core.Model;

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
            DestinationChatHistory result = new DestinationChatHistory();

            Group group = this._groupRepository.GetSingle(groupId);
            List<User> members = this._profileService.GetByIds(group.GroupMembers.Select(gm => gm.UserId).ToList());
            // last 30 message
            List<TextMessage> messages = this._messageRepository.FindBy(m => m.DestinationId == groupId)
                .Where(m => m.MessageReceivers.ContainsUser(this.CurrentUser.UserId))
                .OrderByDescending(m => m.SenderDate)
                .Take(30)
                .ToList();



            return Ok(result);
        }

        [Route("read")]
        public IActionResult ReadMessage(int messageId, int userId)
        {
            TextMessage message = this._messageRepository.GetSingle(messageId);
            if (message == null)
            {
                return BadRequest("Message not found");
            }

            if (!message.ReadReceipts.Contains(userId))
            {
                message.ReadReceipts.Add(new SABISCollaborate.Chat.Core.Model.Messages.ReadReceipt
                {
                    MessageId = messageId,
                    ReadDate = DateTime.Now,
                    UserId = userId
                });
                //this._messageRepository.Update(message);
            }

            return Ok(message.Id);
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