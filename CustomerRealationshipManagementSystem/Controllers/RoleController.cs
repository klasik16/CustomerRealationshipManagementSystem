using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Role>> GetRoles()
    {
        var roles = _roleService.GetRoles();
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public ActionResult<Role> GetRoleById(int id)
    {
        var role = _roleService.GetRoleById(id);
        if (role == null)
            return NotFound();

        return Ok(role);
    }

    [HttpPost]
    public ActionResult<Role> CreateRole(Role role)
    {
        var createdRole = _roleService.CreateRole(role);
        return CreatedAtAction(nameof(GetRoleById), new { id = 5 }, createdRole);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRole(int id, Role role)
    {
        var updatedRole = _roleService.UpdateRole(id, role);
        if (updatedRole == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRole(int id)
    {
        var deletedRole = _roleService.DeleteRole(id);
        if (!deletedRole)
            return NotFound();

        return NoContent();
    }
}