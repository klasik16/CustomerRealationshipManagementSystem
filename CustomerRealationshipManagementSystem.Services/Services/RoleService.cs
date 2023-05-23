using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerRealationshipManagementSystem.DataBase.Model;
using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<IEnumerable<Role>> GetAllRoles()
    {
        return await _roleRepository.GetAllRoles();
    }

    public async Task<Role> GetRoleById(int roleId)
    {
        return await _roleRepository.GetRoleById(roleId);
    }

    public async Task<Role> GetRoleByName(string roleName)
    {
        return await _roleRepository.GetRoleByName(roleName);
    }

    public async Task CreateRole(Role role)
    {
        await _roleRepository.CreateRole(role);
    }

    public async Task UpdateRole(Role role)
    {
        await _roleRepository.UpdateRole(role);
    }

    public async Task DeleteRole(Role role)
    {
        await _roleRepository.DeleteRole(role);
    }

    public Task UpdateRole(int id, Role role)
    {
        throw new NotImplementedException();
    }

    public object GetRoles()
    {
        throw new NotImplementedException();
    }

    public bool DeleteRole(int id)
    {
        throw new NotImplementedException();
    }
}
