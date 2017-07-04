using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.System.Core.Model;
using SABISCollaborate.System.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SABISCollaborate_SPA.Controllers
{
    [Route("api/system")]
    public class SystemController : Controller
    {
        private IGroupRepository _departmentRepository;

        public SystemController(IGroupRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        [HttpGet("departments")]
        public IActionResult Departments()
        {
            List<Department> departments = this._departmentRepository.GetAll().ToList();

            return Ok(departments);
        }

        [HttpPost("department")]
        public IActionResult AddDepartment(string departmentName)
        {
            Department department = new Department(departmentName);
            this._departmentRepository.Add(department);
            this._departmentRepository.Save();

            return Ok(department);
        }
    }
}