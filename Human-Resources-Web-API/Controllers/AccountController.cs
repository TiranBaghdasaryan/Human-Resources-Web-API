using Human_Resources_Web_API.Authentication;
using Human_Resources_Web_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Human_Resources_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login([FromForm] AuthenticationRequest authenticationRequest)
        {
            var jwtAuthenticationManager = new JwtAuthenticationManager();
            var authResult =
                jwtAuthenticationManager.Authenticate(authenticationRequest.UserName, authenticationRequest.Password);
            if (authResult == null)
                return Unauthorized();
            else
                return Ok(authResult);
        }
    }
}