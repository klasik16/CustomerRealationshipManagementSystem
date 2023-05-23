using CustomerRealationshipManagementSystem.DataBase.Model.DTO;

public interface IAuthService
{
    bool Authenticate(string username, string password);
    LoginResponseDTO Login(string username, string password);
}