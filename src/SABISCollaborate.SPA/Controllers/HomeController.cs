using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.Registration.Data;

namespace SABISCollaborate_SPA.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(RegistrationDbContext rdb)
        {
            var users = rdb.User.ToList();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
