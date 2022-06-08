namespace Human_Resources_Web_API.Models
{
    public class JwtAuthResponse
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public int ExpiresIn { get; set; }
    }
}