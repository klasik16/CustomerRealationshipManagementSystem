using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerRealationshipManagementSystem.DataBase.Model;
using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllRoles();
    Task<Role> GetRoleById(int roleId);
    Task<Role> GetRoleByName(string roleName);
    Task CreateRole(Role role);
    Task UpdateRole(Role role);
    Task DeleteRole(Role role);
}
