using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.Registration.Core.Model;
using SABISCollaborate.Registration.Core.Services;
using SABISCollaborate.SharedKernel.Enums;
using SABISCollaborate.SharedKernel.Exceptions;
using SABISCollaborate.SPA.Models;
using SABISCollaborate.SystemManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using S = SABISCollaborate.SystemManagement.Core;

namespace SABISCollaborate_SPA.Controllers
{
    [Route("api/management")]
    public class RegistrationController : Controller
    {
        #region Fields
        private readonly IRegistrationService _userService;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IPositionRepository _positionRepository;
        #endregion

        public RegistrationController(IRegistrationService userService, IDepartmentRepository departmentRepository, IPositionRepository positionRepository)
        {
            this._userService = userService;
            this._departmentRepository = departmentRepository;
            this._positionRepository = positionRepository;
        }

        [Route("users")]
        public IActionResult Users()
        {
            // get all users
            List<User> users = this._userService.GetAllUser();

            return Ok(users);
        }

        [Route("registration")]
        public IActionResult GetInitRegistrationModel(int? userId)
        {
            InitRegistrationModel result = new InitRegistrationModel
            {
                Departments = this._departmentRepository.GetAll(),
                Positions = this._positionRepository.GetAll()
            };

            return Ok(result);
        }

        [HttpPost("registration")]
        public IActionResult Regiter([FromBody] RegisterUserModel user)
        {
            try
            {
                EmploymentInfo employmentInfo = new EmploymentInfo(user.DepartmentsIds, user.PositionId, user.EmploymentDate);

                UserProfile profile = new UserProfile(user.Nickname, user.FirstName, user.LastName, user.BirthDate);
                profile.Gender = user.Gender;
                profile.MaritalStatus = user.MaritalStatus;
                profile.EmploymentInfo = employmentInfo;
                profile.PictureId = user.TempPictureId;
                
                User result = this._userService.Register(user.Username, user.Password, user.Email, profile);

                return Ok(result);
            }
            catch (ValidationException vex)
            {
                return BadRequest(vex.Code);
            }
            catch
            {
                return BadRequest("");
            }
        }

        [HttpPost("profile/picture/temp")]
        public async Task<IActionResult> UploadProfilePicture(IFormFile file)
        {
            Guid fileId = Guid.NewGuid();

            if (file.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    this._userService.SaveTempProfilePicture(fileId.ToString(), stream.ToArray());
                }
            }

            return Ok(fileId);
        }

        [HttpGet("profile/picture/temp")]
        public IActionResult GetTempProfileImage(Guid fileId)
        {
            byte[] imageBytes = this._userService.GetTempProfilePicture(fileId.ToString());
            if(imageBytes != null)
            {
                return File(imageBytes, "image/jpeg");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("profile/picture")]
        public IActionResult GetProfileImage(Guid fileId)
        {
            byte[] imageBytes = this._userService.GetProfilePicture(fileId.ToString());
            if (imageBytes != null)
            {
                return File(imageBytes, "image/jpeg");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("username/available")]
        public IActionResult IsUsernameAvailable(string username)
        {
            bool isInUse = this._userService.IsUsernameAvailable(username);

            return Ok(isInUse);
        }
    }
}

public class RegisterUserModel
{
    public string Username { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string Nickname { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public MaritalStatus MaritalStatus { get; set; }

    public Gender Gender { get; set; }

    public DateTime BirthDate { get; set; }

    public List<int> DepartmentsIds { get; set; }

    public int PositionId { get; set; }

    public DateTime EmploymentDate { get; set; }

    public string TempPictureId { get; set; }
}