using CustomerRealationshipManagementSystem.DataBase.Model.DTO;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;

    public AuthService(IUserService userService, IJwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }

    public string Authenticate(string username, string password)
    {
        // Authenticate the user based on the provided username and password
        var user = _userService.GetUserByUsername(username);
        if (user == null || user.Password != password)
        {
            return null; // Authentication failed
        }

        // Generate JWT token
        var token = _jwtService.GenerateToken(user);

        return token; // Return the generated token
    }

    public LoginResponseDTO Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    bool IAuthService.Authenticate(string username, string password)
    {
        throw new NotImplementedException();
    }
}
