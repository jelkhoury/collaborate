﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.Chat.Core.Repositories;
using SABISCollaborate.Chat.Core.Model;
using SABISCollaborate.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace SABISCollaborate.API.Controllers
{
    [Authorize]
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
            return this.GetUnreadMessages(0);
        }

        [Route("read")]
        public IActionResult ReadMessage(int messageId, int userId)
        {
            TextMessage message = this._messageRepository.GetSingle(messageId);
            //if (message == null)
            //{
            //    return BadRequest("Message not found");
            //}

            //if (!message.Readers.Contains(userId))
            //{
            //    message.Readers.Add(userId);
            //    this._messageRepository.Update(message);
            //}

            return Ok(message.Id);
        }

        //[Route("unreadSummary")]
        //public IActionResult GetUnreadMessagesSummary(int userId)
        //{
        //    List<DestinationSummary> result = new List<DestinationSummary>();
        //    this._messageRepository.GetUnread(userId)
        //        .GroupBy(m => m.Destination.DestinationId)
        //        .ToList()
        //        .ForEach(g =>
        //        {
        //            result.Add(new DestinationSummary
        //            {
        //                DestinationId = g.First().Destination.DestinationId,
        //                DestinationName = g.First().Destination.DestinationId.ToString(),
        //                UnreadMessagesCount = g.Count()
        //            });
        //        });

        //    return Ok(result);
        //}

        [Route("unread")]
        public IActionResult GetUnreadMessages(int userId)
        {
            List<DestinationUnreadSummary> result = new List<DestinationUnreadSummary>();

            List<Group> groups = this._groupRepository.GetAll().ToList();//.GetUserGroups(userId);
            List<TextMessage> unreadMessages = this._messageRepository.GetUnreadByGroup(userId, groups.Select(g => g.Id).ToList());
            groups.ForEach(g =>
            {
                result.Add(new DestinationUnreadSummary
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