using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.Management.Core.CRUD.Repositories;
using SABISCollaborate.Management.Core.Registration.Model;
using SABISCollaborate.Management.Core.Registration.Services;
using SABISCollaborate.SharedKernel.Enums;
using SABISCollaborate.SharedKernel.Exceptions;
using System;
using System.Collections.Generic;

namespace SABISCollaborate_SPA.Controllers
{
    [Route("api/management")]
    public class ManagementController : Controller
    {
        private IDepartmentRepository _departmentRepository;
        private IUserManagementService _userService;

        public ManagementController(IUserManagementService userService, IDepartmentRepository departmentRepository)
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

        [Route("departments")]
        public IActionResult Departments()
        {
            List<SABISCollaborate.Management.Core.CRUD.Model.Department> department = this._departmentRepository.GetAll();

            return Ok(department);
        }

        [HttpPost]
        [Route("registration")]
        public IActionResult Regiter([FromBody] RegisterUserModel user)
        {
            try
            {
                UserProfile profile = new UserProfile
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    BirthDate = user.BirthDate,
                    Gender = user.Gender,

                };

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
}