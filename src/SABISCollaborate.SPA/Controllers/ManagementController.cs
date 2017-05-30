using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.Management.Core.Registration.Interfaces;
using SABISCollaborate.Management.Core.Registration.Model;
using SABISCollaborate.Management.Core.Registration.Services;
using SABISCollaborate.SharedKernel.Exceptions;
using SABISCollaborate.SharedKernel.Enums;

namespace SABISCollaborate_SPA.Controllers
{
    [Route("api/management")]
    public class ManagementController : Controller
    {
        private IUserRepository _userRepository;
        private IDepartmentRepository _departmentRepository;
        private IUserManagementService _userService;

        public ManagementController(IUserManagementService userService)
        public ManagementController(IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            this._userRepository = userRepository;
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
            List<Department> department = this._departmentRepository.GetAll();
            return Ok(department);
        }

        [HttpPost]
        [Route("registration")]
        public IActionResult Regiter([FromBody] RegisterUserModel user)
        {
            try
            {
                User result = this._userService.Register(
                    user.Username,
                    user.Password,
                    user.Email,
                    user.FirstName,
                    user.LastName,
                    user.Gender,
                    user.BirthDate);

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