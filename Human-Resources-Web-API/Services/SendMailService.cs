using System;
using System.Linq;
using System.Threading.Tasks;
using Human_Resources_Web_API.Models;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Response = Human_Resources_Web_API.Models.Response;

namespace Human_Resources_Web_API.Services
{
    public class SendMailService : ISendMailService
    {
        public SendMailService(IConfiguration configuration, IEmployeeRepository employeeRepository)
        {
            _configuration = configuration;
            _employeeRepository = employeeRepository;  
        }

        private readonly IConfiguration _configuration;
        private readonly IEmployeeRepository _employeeRepository;

        public async Task<Response> SendEmailAsync(Mail model)
        {
    
            Response res = new Response()
            {
                Message = "",
                Code = 200
            };
            
            var apiKey = _configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("tirbaghdasaryan0808@gmail.com", "Test");

            for (int i = 0; i < model.Mails.Count; i++)
            {
                if (!IsEmailExists(model.Mails[i]))
                {
                    res.Message += $"{model.Mails[i]} ";
                    continue;
                }
                
                var to = new EmailAddress(model.Mails[i]);
                var msg = MailHelper.CreateSingleEmail(from, to, model.Subject, model.Content, model.Content);
                var response = await client.SendEmailAsync(msg);
            }

            return res;
        }

        private bool IsEmailExists(string value)
        {
            if (_employeeRepository.GetEmails().Contains(value))
                return true;
            return false;
        }
    }
}