using CustomerRealationshipManagementSystem.DataBase.Model.DTO;

public interface IAuthService
{
    Task<string> AuthenticateUser(string username, string password);
}