using System.Collections.Generic;
using Human_Resources_Web_API.Entities;

namespace Human_Resources_Web_API.Services
{
    public interface IEmployeeLeftRepository
    {
        public IEnumerable<EmployeeLeft> GetAllEmployees();
    }
}