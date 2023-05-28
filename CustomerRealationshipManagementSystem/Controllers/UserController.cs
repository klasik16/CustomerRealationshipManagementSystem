using Azure;
using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using CustomerRealationshipManagementSystem.DataBase.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        var users = _userService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost("upload-image")]
    public IActionResult UploadImage(IFormFile imageFile)
    {
        // Handle the image upload logic here
        // Save the image and associate it with the user

        // Return appropriate response
        return Ok("Image uploaded successfully");
    }

    public ActionResult<User> CreateUser(UserSignupDTO userSignupDto)
    {
        var user = new User
        {
            Username = userSignupDto.Username,
            Password = userSignupDto.Password,
            FirstName = userSignupDto.FirstName,
            LastName = userSignupDto.LastName,
            PersonalIdentificationNumber = userSignupDto.PersonalIdentificationNumber,
            Email = userSignupDto.Email,
            PhoneNumber = userSignupDto.PhoneNumber,
            Address = new Address
            {
                City = userSignupDto.Address.City,
                Street = userSignupDto.Address.Street,
                BuildingNumber = userSignupDto.Address.BuildingNumber,
                ApartmentNumber = userSignupDto.Address.ApartmentNumber
            }
        };

        var createdUser = _userService.CreateUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        var updatedUser = _userService.UpdateUser(id, user);
        if (updatedUser == null)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var deletedUser = _userService.DeleteUser(id);
        if (!deletedUser)
            return NotFound();

        return NoContent();
    }
}