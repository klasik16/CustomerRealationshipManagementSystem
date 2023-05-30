using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserRepository
{
    Task<User> GetUserById(int userId);
    Task<User> GetUserByUsername(string username);
    Task<IEnumerable<User>> GetAllUsers();
    Task CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(User user);
    User GetUser(string username);
}