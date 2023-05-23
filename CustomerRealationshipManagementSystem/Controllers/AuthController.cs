using Microsoft.AspNetCore.Mvc;
using CustomerRealationshipManagementSystem.DataBase.Model.DTO;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    public ActionResult Login([FromBody] UserLoginDTO loginRequest)
    {
        var loginResponse = _authService.Login(loginRequest.Username,loginRequest.Password);
        if (!loginResponse.IsSuccess)
            return Unauthorized(loginResponse.Message);

        return Ok(loginResponse);
    }
}
