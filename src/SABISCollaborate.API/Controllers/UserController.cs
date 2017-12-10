using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.Profile.Core.Services;
using SABISCollaborate.Profile.Core.Model;
using SABISCollaborate.Profile.Core.Repositories;

namespace SABISCollaborate.API.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public UserController(IProfileService profileService)
        {
            this._profileService = profileService;
        }

        [HttpGet("")]
        public IActionResult GetCurrentUserProfile()
        {
            User user = this._profileService.GetUsersByIds(new List<int> { base.CurrentUser.UserId }).FirstOrDefault();

            return Ok(user.Profile);
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserProfile(int userId)
        {
            var user = this._profileService.GetUserById(userId);

            return Ok(user.Profile);
        }
    }
}