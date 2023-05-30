using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerRealationshipManagementSystem.DataBase.Model.DTO;
using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;

namespace CustomerRealationshipManagementSystem.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;

        public AuthController(IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin loginDto)
        {
            try
            {
                string token = await _authService.AuthenticateUser(loginDto.Username, loginDto.Password);
                
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
