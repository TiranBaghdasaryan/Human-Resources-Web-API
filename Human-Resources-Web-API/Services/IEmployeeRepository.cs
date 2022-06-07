using System.Threading.Tasks;
using Human_Resources_Web_API.Models;

namespace Human_Resources_Web_API.Services
{
    public interface IEmployeeRepository
    {
        public Task<Response> AddEmployeeAsync(AddEmployeeRequest requestModel);
        public Task<Response> RemoveEmployeeHardByIdAsync(int id);
        public Task<Response> RemoveEmployeeToBackupByIdAsync(int id);
        public Task<Response> UpdateEmployeeByIdAsync(int id);
        
    }
}