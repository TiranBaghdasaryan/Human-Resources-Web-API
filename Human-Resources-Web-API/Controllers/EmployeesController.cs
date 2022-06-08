using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Human_Resources_Web_API.Context;
using Human_Resources_Web_API.Entities;
using Human_Resources_Web_API.Models;
using Human_Resources_Web_API.Models.ViewModels;
using Human_Resources_Web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Human_Resources_Web_API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private Response response = null;

        public EmployeesController(IEmployeeRepository employeeRepository, ApplicationContext context)
        {
            _employeeRepository = employeeRepository;
            _context = context;
        }

        private readonly IEmployeeRepository _employeeRepository;
        private readonly ApplicationContext _context;


        [HttpPost("add-employee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequest employeeRequest)
        {
            response = await _employeeRepository.AddEmployeeAsync(employeeRequest);
            return Ok(response);
        }


        [HttpPut("update-employee/{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeRequest employeeRequest)
        {
            Employee employee = _context.Employees.Include(e => e.HumanResourceData).FirstOrDefault(e => e.Id == id);
            if (employee == null) return BadRequest("Employee not exists");

            response = await _employeeRepository.UpdateEmployeeByIdAsync(id, employeeRequest, employee);
            return Ok(response);
        }


        [HttpGet("get-employees")]
        public IActionResult GetEmployees()
        {
            IEnumerable<EmployeeViewModel> employees = _employeeRepository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("get-email/{id:int}")]
        public IActionResult GetEmployees(int id)
        {
            string result = _employeeRepository.GetEmailById(id);
            if (Equals(result, null))
                return BadRequest("Employee not exists");
            return Ok(result);
        }

        [HttpDelete("remove-employee-hard/{id:int}")]
        public IActionResult RemoveEmployeeHard(int id)
        {
            Employee employee = _context.Employees.Include(e => e.HumanResourceData).FirstOrDefault(e => e.Id == id);
            if (employee == null) return BadRequest("Employee not exists");

            response = _employeeRepository.RemoveEmployeeHardByIdAsync(id, employee);
            return Ok(response);
        }


        [HttpDelete("remove-employee-soft/{id:int}")]
        public async Task<IActionResult> RemoveEmployeeSoft(int id)
        {
            Employee employee = _context.Employees.Include(e => e.HumanResourceData).FirstOrDefault(e => e.Id == id);
            if (employee == null) return BadRequest("Employee not exists");

            response = await _employeeRepository.RemoveEmployeeSoftByIdAsync(id, employee);
            return Ok(response);
        }
    }
}