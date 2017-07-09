using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.Chat.Core.Repositories;

namespace SABISCollaborate.API.Controllers
{
    [Route("api/chat")]
    public class ChatController : Controller
    {
        private readonly ITextMessageRepository _messageRepository;
        private readonly IGroupRepository _groupRepository;

        public ChatController(ITextMessageRepository messageRepository, IGroupRepository groupRepository)
        {
            this._messageRepository = messageRepository;
            this._groupRepository = groupRepository;
        }

        [HttpGet("groups/summary")]
        public IActionResult GetGroupsWithSummary()
        {
            return null;
        }

        [Route("read")]
        public IActionResult ReadMessage(int messageId, int userId)
        {
            TextMessage message = this._messageRepository.GetById(messageId);
            if (message == null)
            {
                return BadRequest("Message not found");
            }

            if (!message.Readers.Contains(userId))
            {
                message.Readers.Add(userId);
                this._messageRepository.Update(message);
            }

            return Ok(message.Id);
        }

        [Route("unreadSummary")]
        public IActionResult GetUnreadMessagesSummary(int userId)
        {
            List<DestinationSummary> result = new List<DestinationSummary>();
            this._messageRepository.GetUnread(userId)
                .GroupBy(m => m.Destination.DestinationId)
                .ToList()
                .ForEach(g =>
                {
                    result.Add(new DestinationSummary
                    {
                        DestinationId = g.First().Destination.DestinationId,
                        DestinationName = g.First().Destination.DestinationId.ToString(),
                        UnreadMessagesCount = g.Count()
                    });
                });

            return Ok(result);
        }

        [Route("unread")]
        public IActionResult GetUnreadMessages(int userId)
        {
            List<DestinationSummary> result = new List<DestinationSummary>();

            List<Group> groups = this._groupRepository.GetUserGroups(userId);
            List<TextMessage> unreadMessages = this._messageRepository.GetUnreadByGroup(userId, groups.Select(g => g.Id).ToList());
            groups.ForEach(g =>
            {
                result.Add(new DestinationSummary
                {
                    DestinationId = g.Id,
                    DestinationName = g.Name,
                    UnreadMessagesCount = unreadMessages.Count(m => m.Destination.DestinationId == g.Id)
                });
            });

            return Ok(result);
        }
    }
}
