using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SABIS.Collaborate.Web.Controllers
{
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}