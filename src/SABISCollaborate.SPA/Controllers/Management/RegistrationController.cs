using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.Registration.Core.Model;
using SABISCollaborate.Registration.Core.Services;
using SABISCollaborate.SharedKernel.Enums;
using SABISCollaborate.SharedKernel.Exceptions;
using SABISCollaborate.SystemManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using S = SABISCollaborate.SystemManagement.Core;

namespace SABISCollaborate_SPA.Controllers
{
    [Route("api/management")]
    public class RegistrationController : Controller
    {
        private IDepartmentRepository _departmentRepository;
        private IUserManagementService _userService;

        public RegistrationController(IUserManagementService userService, IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
            this._userService = userService;
        }

        [Route("users")]
        public IActionResult Users()
        {
            // get all users
            List<User> users = this._userService.GetAll();

            return Ok(users);
        }

        [Route("registration")]
        public IActionResult GetRegistrationModel(int? userId)
        {
            RegistrationModel result = new RegistrationModel
            {
                Departments = this._departmentRepository.GetAll()
            };

            return Ok(result);
        }

        [HttpPost]
        [Route("registration")]
        public IActionResult Regiter([FromBody] RegisterUserModel user)
        {
            try
            {
                UserProfile profile = new UserProfile(user.FirstName, user.FirstName, user.LastName, user.BirthDate);
                profile.Gender = user.Gender;

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
    }
}

public class RegisterUserModel
{
    public string Username { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Gender Gender { get; set; }

    public DateTime BirthDate { get; set; }

    public List<int> DepartmentsIds { get; set; }
}

public class RegistrationModel
{
    public List<S.Model.Department> Departments { get; set; }
}