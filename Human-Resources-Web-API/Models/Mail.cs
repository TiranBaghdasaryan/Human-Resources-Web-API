using System.Collections.Generic;

namespace Human_Resources_Web_API.Models
{
    public class Mail
    {
        public List<string> Mails { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
    }
}