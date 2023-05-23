using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public ActionResult<LoginResponseDTO> Login(LoginRequestDTO loginRequest)
    {
        var loginResponse = _authService.Login(loginRequest);
        if (!loginResponse.IsSuccess)
            return Unauthorized(loginResponse.Message);

        return Ok(loginResponse);
    }
}
