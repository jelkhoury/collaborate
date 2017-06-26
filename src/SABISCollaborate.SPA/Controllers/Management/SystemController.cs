using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.System.Core.Model;
using SABISCollaborate.System.Core.Repositories;
using System;
using System.Collections.Generic;

namespace SABISCollaborate_SPA.Controllers
{
    [Route("api/system")]
    public class SystemController : Controller
    {
        private IDepartmentRepository _departmentRepository;

        public SystemController(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        [HttpGet("departments")]
        public IActionResult Departments()
        {
            List<Department> department = this._departmentRepository.GetAll();

            return Ok(department);
        }

        [HttpPost("department")]
        public IActionResult AddDepartment(string departmentName)
        {
            Department department = this._departmentRepository.AddDepartment(departmentName);

            return Ok(department);
        }
    }
}