using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRoleService
{
    // Role operations
    public Role GetRoleById(Guid id);
    public Task<Role> CreateRoleAsync(Role role);
    object UpdateRole(Guid id, Role role);
    object GetRoles();
    bool DeleteRole(int id);
    object CreateRole(Role role);
}