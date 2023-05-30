using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using System.Security.Claims;

public interface IJwtService
{
    string GenerateJwtToken(User user);
    ClaimsPrincipal ValidateJwtToken(string token);
}