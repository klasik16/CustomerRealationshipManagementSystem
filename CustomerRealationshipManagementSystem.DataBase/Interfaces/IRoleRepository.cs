using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerRealationshipManagementSystem.DataBase.Model;
using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;

public interface IRoleRepository
{
    Task<Role> CreateRole(Role role);
    public Task<IEnumerable<Role>> GetAllRoles();
    public Role GetRoleById(Guid id);

    // public Task<Role> GetRoleById(Guid roleId);
    //public Task<Role> CreateRole(Role role);
    public Task UpdateRole(Role role);
    //public Task DeleteRole(Role role);
    //void DeleteRole(Guid id);
}
