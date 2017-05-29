using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.Management.Core.Registration.Interfaces;
using SABISCollaborate.Management.Core.Registration.Model;

namespace SABISCollaborate_SPA.Controllers
{
    [Route("api/management")]
    public class ManagementController : Controller
    {
        private IUserRepository _userRepository;
        private IDepartmentRepository _departmentRepository;

        public ManagementController(IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            this._userRepository = userRepository;
            this._departmentRepository = departmentRepository;
        }

        [Route("users")]
        public IActionResult Users()
        {
            // get all users
            List<User> users = this._userRepository.GetAll();

            return Ok(users);
        }

        [Route("departments")]
        public IActionResult Departments()
        {
            List<Department> department = this._departmentRepository.GetAll();
            return Ok(department);
        }

        [HttpPost]
        public IActionResult Regiter(User user)
        {

            return Ok();
        }
    }
}
