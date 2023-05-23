using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;

public interface IJwtService
{
    string GenerateToken(User user);
}