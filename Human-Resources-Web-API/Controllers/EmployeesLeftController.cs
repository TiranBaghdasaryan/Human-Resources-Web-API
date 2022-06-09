using System.Collections.Generic;
using Human_Resources_Web_API.Entities;
using Human_Resources_Web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Human_Resources_Web_API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesLeftController : ControllerBase
    {
        public EmployeesLeftController(IEmployeeLeftRepository employeeLeftRepository)
        {
            _employeeLeftRepository = employeeLeftRepository;
        }

        private readonly IEmployeeLeftRepository _employeeLeftRepository;

        [HttpGet("get-employees")]
        public IActionResult GetEmployees()
        {
            IEnumerable<EmployeeLeft> employees = _employeeLeftRepository.GetAllEmployees();
            return Ok(employees);
        }
    }
}