using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using CustomerRealationshipManagementSystem.DataBase.Model.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;
    private readonly IRoleService _jroleService;
    public AuthService(IUserService userService, IJwtService jwtService, IRoleService roleService)
    {
        _userService = userService;
        _jwtService = jwtService;
        _jroleService = roleService;
    }

    public async Task<string> AuthenticateUser(string username, string password)
    {
        // Authenticate the user credentials
        User user = await _userService.GetUserByUsernameAndPassword(username, password);
        if (user == null)
        {
            throw new Exception("Invalid username or password");
        }

        // Generate a JWT token
        string token = _jwtService.GenerateJwtToken(user);
        return token;
    }
}
