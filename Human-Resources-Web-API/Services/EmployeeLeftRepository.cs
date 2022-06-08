using System.Collections.Generic;
using Human_Resources_Web_API.Context;
using Human_Resources_Web_API.Entities;

namespace Human_Resources_Web_API.Services
{
    public class EmployeeLeftRepository : IEmployeeLeftRepository
    {
        public EmployeeLeftRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        private readonly ApplicationContext _context;

        public IEnumerable<EmployeeLeft> GetAllEmployees()
        {
            return _context.EmployeesLeft;
        }
    }
}