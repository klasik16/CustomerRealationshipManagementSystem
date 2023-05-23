using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;

public interface IUserService
{
    User GetUserById(int id);
    IEnumerable<User> GetUsers();
    User CreateUser(User user);
    User UpdateUser(int id, User user);
    bool DeleteUser(int id);
    User GetUserByUsername(string username);
}