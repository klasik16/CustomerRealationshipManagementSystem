using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerRealationshipManagementSystem.DataBase.Model.DTO;

namespace CustomerRealationshipManagementSystem.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(UserLoginDTO loginRequest)
        {
            var loginResponse = await _authService.Login(loginRequest.Username, loginRequest.Password);
            if (loginResponse == null)
            {
                return Unauthorized();
            }

            return Ok(loginResponse);
        }
    }
}
