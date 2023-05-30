using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerRealationshipManagementSystem.DataBase.Model;
using CustomerRealationshipManagementSystem.DataBase;
using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;

public class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _dbContext;

    public RoleRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Role>> GetAllRoles()
    {
        return await _dbContext.Roles.ToListAsync();
    }

    public async Task<Role> GetRoleByName(string roleName)
    {
        return await _dbContext.Roles.FirstOrDefaultAsync(r => r.UserRole == roleName);
    }

    public async Task CreateRole(Role role)
    {
        _dbContext.Roles.Add(role);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateRole(Role role)
    {
        _dbContext.Entry(role).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteRole(Role role)
    {
        _dbContext.Roles.Remove(role);
        await _dbContext.SaveChangesAsync();
    }

    Task<Role> IRoleRepository.CreateRole(Role role)
    {
        throw new NotImplementedException();
    }

    public void DeleteRole(Guid id)
    {
        throw new NotImplementedException();
    }

    public Role GetRoleById(Guid id)
    {
            var role = _dbContext.Roles.FirstOrDefault(r => r.Id == id);
        return role;
    }
}
