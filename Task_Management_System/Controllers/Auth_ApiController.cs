using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Task_Management_System.Entities.Authentication;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Auth_ApiController : ControllerBase
    {
        private readonly Jwt_Service _jwtService;

        public Auth_ApiController(Jwt_Service jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login_Request request)
        {
            // Giả lập kiểm tra tài khoản (có thể thay bằng database)
            if (request.User_Name == "admin" && request.Password == "123456")
            {
                var token = _jwtService.Generate_Token("1", "Admin");
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
