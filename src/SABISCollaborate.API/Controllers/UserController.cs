using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.Profile.Core.Services;
using SABISCollaborate.Profile.Core.Model;
using SABISCollaborate.Profile.Core.Repositories;
using SABISCollaborate.API.Models.UserViewModels;

namespace SABISCollaborate.API.Controllers
{
    /// <summary>
    /// Gives access to all users(+ profiles) and accounts
    /// </summary>
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        #region Fields
        private readonly IUserProfileService _profileService;
        #endregion

        #region Constructors
        public UserController(IUserProfileService profileService)
        {
            this._profileService = profileService;
        }
        #endregion

        #region UserProfile
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
        #endregion

        #region Accounts
        [HttpPut("current/password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordViewModel viewModel)
        {
            bool result = true;

            return Ok(result);
        }
        #endregion
    }
}