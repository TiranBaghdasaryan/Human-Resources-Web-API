using System.Threading.Tasks;
using Human_Resources_Web_API.Models;
using Human_Resources_Web_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Human_Resources_Web_API.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        private readonly IEmployeeRepository _employeeRepository;

        [HttpPost("add-employee")]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest employee)
        {
            Response response = null;
            if (!ModelState.IsValid)
            {
                response = new Response()
                {
                    Message = $"error",
                    Code = 400
                };
                return BadRequest(response);
            }

            response = await _employeeRepository.AddEmployeeAsync(employee);
            return Ok(response);
        }
    }
}