using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRoleService
{
    Task<IEnumerable<Role>> GetAllRoles();
    Task<Role> GetRoleById(int roleId);
    Task<Role> GetRoleByName(string roleName);
    Task CreateRole(Role role);
    Task UpdateRole(int id, Role role);
    Task DeleteRole(Role role);
    object GetRoles();
    bool DeleteRole(int id);
}