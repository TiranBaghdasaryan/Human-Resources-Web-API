using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Human_Resources_Web_API.Context;
using Human_Resources_Web_API.Entities;
using Human_Resources_Web_API.Models;
using Human_Resources_Web_API.Models.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace Human_Resources_Web_API.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public async Task<Response> AddEmployeeAsync(EmployeeRequest requestModel)
        {
            Employee employee = new Employee()
            {
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                BirthDate = requestModel.BirthDate.Date,
                Gender = requestModel.Gender,
                ContactNumber = requestModel.ContactNumber,
                Email = requestModel.Email,
            };

            await _context.Employees.AddAsync(employee);

            await _context.SaveChangesAsync();

            await _context.HumanResourcesData.AddAsync(new HumanResourceData()
            {
                EmployeeId = employee.Id,
                PayrollInformation = requestModel.PayrollInformation,
                SocialSecurityNumber = requestModel.SocialSecurityNumber,
                Salary = requestModel.Salary,
            });

            await _context.SaveChangesAsync();

            return new Response()
            {
                Message = "Operation done successful",
                Code = 200
            };
        }

        public Response RemoveEmployeeHardByIdAsync(int id, Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return new Response()
            {
                Message = "Operation done successful",
                Code = 200
            };
        }

        public async Task<Response> RemoveEmployeeSoftByIdAsync(int id, Employee employee)
        {
            await _context.EmployeesLeft.AddAsync(new EmployeeLeft(
                employee.FirstName,
                employee.LastName,
                employee.BirthDate,
                employee.Gender,
                employee.ContactNumber,
                employee.Email,
                employee.HumanResourceData.PayrollInformation,
                employee.HumanResourceData.SocialSecurityNumber,
                employee.HumanResourceData.Salary
            ));

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return new Response()
            {
                Message = "Operation done successful",
                Code = 200
            };
        }

        public async Task<Response> UpdateEmployeeByIdAsync(int id, EmployeeRequest requestModel, Employee employee)
        {
            // employee.UpdateEmployee
            // (
            //     requestModel.FirstName,
            //     requestModel.LastName,
            //     requestModel.BirthDate,
            //     requestModel.Gender,
            //     requestModel.ContactNumber,
            //     requestModel.Email
            // );
            //
            // employee.UpdateHumanResourceData
            // (
            //     requestModel.PayrollInformation,
            //     requestModel.SocialSecurityNumber,
            //     requestModel.Salary
            // );

           // employee = _mapper.Map<Employee>(requestModel);

            await _context.SaveChangesAsync();

            return new Response()
            {
                Message = "Operation done successful",
                Code = 200
            };
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployees() =>
            _context.Employees.Include(e => e.HumanResourceData).Select(e =>
                _mapper.Map<EmployeeViewModel>(e)
            );

        public IEnumerable<string> GetEmails() => _context.Employees.Select(e => e.Email);


        public string GetEmailById(int id) =>
            _context.Employees.FirstOrDefault(e => e.Id == id)?.Email;
    }
}