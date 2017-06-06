using Microsoft.AspNetCore.Mvc;
using SABISCollaborate.Registration.Core.CRUD.Model;
using SABISCollaborate.Registration.Core.CRUD.Repositories;
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

        [Route("departments")]
        public IActionResult Departments()
        {
            List<Department> department = this._departmentRepository.GetAll();

            return Ok(department);
        }
    }
}