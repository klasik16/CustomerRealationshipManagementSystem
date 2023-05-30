using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerRealationshipManagementSystem.DataBase.Model;
using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using Microsoft.EntityFrameworkCore;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Role GetRoleById(Guid id)
    {
        return _roleRepository.GetRoleById(id);
    }

    public async Task<Role> CreateRoleAsync(Role role)
    {
        return await _roleRepository.CreateRole(role);
    }

    public void UpdateRole(Role role)
    {
        _roleRepository.UpdateRole(role);
    }

    public async Task<List<Role>>  GetAllRoles()
    {
        return (List<Role>)await _roleRepository.GetAllRoles();
    }

    public object UpdateRole(Guid id, Role role)
    {
        throw new NotImplementedException();
    }

    public object GetRoles()
    {
        throw new NotImplementedException();
    }

    public object GetRoleById(int id)
    {
        throw new NotImplementedException();
    }

    public bool DeleteRole(int id)
    {
        throw new NotImplementedException();
    }

    public object CreateRole(Role role)
    {
        throw new NotImplementedException();
    }
}
