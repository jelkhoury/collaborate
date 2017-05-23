using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.Management.Core.Registration.Interfaces;
using SABISCollaborate.Management.Core.Registration.Model;
using System.Collections.Generic;

namespace SABIS.Collaborate.Web.Controllers
{
    public class ManagementController : Controller
    {
        private IUserRepository _userRepository;

        public ManagementController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public IActionResult Users()
        {
            // get all users
            List<User> users = this._userRepository.GetAll();

            return View(users);
        }
    }
}