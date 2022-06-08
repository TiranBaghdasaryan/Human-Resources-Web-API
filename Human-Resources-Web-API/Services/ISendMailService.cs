using System.Threading.Tasks;
using Human_Resources_Web_API.Models;

namespace Human_Resources_Web_API.Services
{
    public interface ISendMailService
    {
        Task<Response> SendEmailAsync(Mail model);
    }
}