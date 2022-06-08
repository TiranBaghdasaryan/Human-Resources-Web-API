using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Human_Resources_Web_API.Context;
using Human_Resources_Web_API.Entities;
using Human_Resources_Web_API.Models;
using Human_Resources_Web_API.Models.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace Human_Resources_Web_API.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }

        private readonly ApplicationContext _context;

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

        public Task<Response> RemoveEmployeeHardByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response> RemoveEmployeeToBackupByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response> UpdateEmployeeByIdAsync(int id, EmployeeRequest requestModel, Employee employee)
        {
            employee.UpdateEmployee
            (
                requestModel.FirstName,
                requestModel.LastName,
                requestModel.BirthDate,
                requestModel.Gender,
                requestModel.ContactNumber,
                requestModel.Email
            );

            employee.UpdateHumanResourceData
            (
                requestModel.PayrollInformation,
                requestModel.SocialSecurityNumber,
                requestModel.Salary
            );

            await _context.SaveChangesAsync();

            return new Response()
            {
                Message = "Operation done successful",
                Code = 200
            };
        }

        public IEnumerable<EmployeeViewModel> GetAllEmployeesAsync() =>
            _context.Employees.Include(e => e.HumanResourceData).Select(e => new EmployeeViewModel()
                .Update
                (
                    e.FirstName,
                    e.LastName,
                    e.BirthDate,
                    e.Gender,
                    e.ContactNumber,
                    e.Email,
                    e.HumanResourceData.PayrollInformation,
                    e.HumanResourceData.SocialSecurityNumber,
                    e.HumanResourceData.Salary
                ));
    }
}