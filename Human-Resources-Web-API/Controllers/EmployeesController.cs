using System.Linq;
using System.Threading.Tasks;
using Human_Resources_Web_API.Context;
using Human_Resources_Web_API.Entities;
using Human_Resources_Web_API.Models;
using Human_Resources_Web_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Human_Resources_Web_API.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private Response response;

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
            response = null;
            response = await _employeeRepository.AddEmployeeAsync(employeeRequest);
            return Ok(response);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeRequest employeeRequest)
        {
            response = null;
            Employee employee = _context.Employees.Include(e=>e.HumanResourceData).FirstOrDefault(e => e.Id == id);
            if (employee == null) return BadRequest("Employee not exists");

            response = await _employeeRepository.UpdateEmployeeByIdAsync(id, employeeRequest, employee);
            return Ok(response);
        }
    }
}