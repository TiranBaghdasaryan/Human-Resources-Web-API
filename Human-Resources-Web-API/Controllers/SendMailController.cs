using System.Threading.Tasks;
using Human_Resources_Web_API.Models;
using Human_Resources_Web_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Human_Resources_Web_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        public SendMailController(ISendMailService sendMailService)
        {
            _sendMailService = sendMailService;
        }

        private readonly ISendMailService _sendMailService;


        [HttpPost("send-mail")]
        public async Task<IActionResult> SendMail([FromBody] Mail mailModel)
        {
            Response response = await _sendMailService.SendEmailAsync(mailModel);
            return Ok(response);
        }
    }
}