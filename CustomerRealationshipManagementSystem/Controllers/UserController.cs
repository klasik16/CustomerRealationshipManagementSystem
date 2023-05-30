using Azure;
using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using CustomerRealationshipManagementSystem.DataBase.Model.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Data;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromForm] UserSignupDTO userSignupDto)
    {
        if (string.IsNullOrWhiteSpace(userSignupDto.Username) ||
        string.IsNullOrWhiteSpace(userSignupDto.Password) ||
        string.IsNullOrWhiteSpace(userSignupDto.FirstName) ||
        string.IsNullOrWhiteSpace(userSignupDto.LastName) ||
        string.IsNullOrWhiteSpace(userSignupDto.PersonalIdentificationNumber) ||
        string.IsNullOrWhiteSpace(userSignupDto.Email) ||
        string.IsNullOrWhiteSpace(userSignupDto.PhoneNumber) ||
        userSignupDto.Address == null ||
        string.IsNullOrWhiteSpace(userSignupDto.Address.City) ||
        string.IsNullOrWhiteSpace(userSignupDto.Address.Street) ||
        string.IsNullOrWhiteSpace(userSignupDto.Address.BuildingNumber) ||
        string.IsNullOrWhiteSpace(userSignupDto.Address.ApartmentNumber) ||
        userSignupDto.ProfilePicture == null)
        {
            return BadRequest("One or more required fields are missing or empty.");
        }

        var user = new User
        {
            // Populate user properties from userSignupDto
            Username = userSignupDto.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(userSignupDto.Password),
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
            },
            UserRoles = new Role
            {
                UserRole = "User"
            },
            ProfilePicture = new ProfilePicture
            {
                ImageData = await _userService.ConvertToByteArrayAsync(userSignupDto.ProfilePicture)
            }
        };

        await _userService.CreateUserAsync(user);
        return Ok();
    }

    [Authorize(Policy = "User")]
    [HttpPut("{userId}/username")]
    public async Task<IActionResult> UpdateUserName(Guid userId, [FromBody] string username)
    {
        // Get the authenticated user's claims
        var currentUserClaims = HttpContext.User.Claims;
        var currentUserRole = currentUserClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        var currentUserId = currentUserClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        // Check if the current user is authorized to update the username
        if (currentUserRole == "User" && currentUserId != userId.ToString())
        {
            // User can only update their own username
            return Forbid();
        }

        if (string.IsNullOrWhiteSpace(username))
        {
            return BadRequest("Username cannot be null or empty.");
        }

        bool updated = await _userService.UpdateUserName(userId, username);
        if (!updated)
            return NotFound();

        return Ok();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    [HttpPut("{userId}/password")]
    public async Task<IActionResult> UpdatePassword(Guid userId, [FromBody] string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            return BadRequest("Password cannot be null or empty.");
        }
        bool updated = await _userService.UpdatePassword(userId, password);
        if (!updated)
            return NotFound();

        return Ok();
    }
    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    [HttpPut("{userId}/firstname")]
    public async Task<IActionResult> UpdateFirstName(Guid userId, [FromBody] string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return BadRequest("First name cannot be null or empty.");
        }

        bool updated = await _userService.UpdateFirstName(userId, firstName);
        if (!updated)
            return NotFound();

        return Ok();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    [HttpPut("{userId}/lastname")]
    public async Task<IActionResult> UpdateLastName(Guid userId, [FromBody] string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            return BadRequest("Last name cannot be null or empty.");
        }

        bool updated = await _userService.UpdateLastName(userId, lastName);
        if (!updated)
            return NotFound();

        return Ok();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    [HttpPut("{userId}/personalidentificationnumber")]
    public async Task<IActionResult> UpdatePersonalIdentificationNumber(Guid userId, [FromBody] string personalIdentificationNumber)
    {
        if (string.IsNullOrWhiteSpace(personalIdentificationNumber))
        {
            return BadRequest("Personal identification number cannot be null or empty.");
        }

        bool updated = await _userService.UpdatePersonalIdentificationNumber(userId, personalIdentificationNumber);
        if (!updated)
            return NotFound();

        return Ok();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    [HttpPut("{userId}/email")]
    public async Task<IActionResult> UpdateEmail(Guid userId, [FromBody] string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return BadRequest("Email cannot be null or empty.");
        }

        bool updated = await _userService.UpdateEmail(userId, email);
        if (!updated)
            return NotFound();

        return Ok();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    [HttpPut("{userId}/phoneNumber")]
    public async Task<IActionResult> UpdatePhoneNumber(Guid userId, [FromBody] string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            return BadRequest("Phone number cannot be null or empty.");
        }

        bool updated = await _userService.UpdatePhoneNumber(userId, phoneNumber);
        if (!updated)
            return NotFound();

        return Ok();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    [HttpPut("address/{addressId}/city")]
    public async Task<IActionResult> UpdateCity(Guid addressId, [FromBody] string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            return BadRequest("City cannot be null or empty.");
        }

        bool updated = await _userService.UpdateCity(addressId, city);
        if (!updated)
            return NotFound();

        return Ok();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    [HttpPut("address/{addressId}/street")]
    public async Task<IActionResult> UpdateUserStreet(Guid addressId, [FromBody] string street)
    {
        if (string.IsNullOrWhiteSpace(street))
        {
            return BadRequest("Street cannot be null or empty.");
        }

        bool updated = await _userService.UpdateUserStreet(addressId, street);
        if (!updated)
            return NotFound();

        return Ok();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    [HttpPut("addresses/{addressId}/buildingNumber")]
    public async Task<IActionResult> UpdateBuildingNumber(Guid addressId, [FromBody] string buildingNumber)
    {
        if (string.IsNullOrWhiteSpace(buildingNumber))
        {
            return BadRequest("Building number cannot be null or empty.");
        }

        bool updated = await _userService.UpdateBuildingNumber(addressId, buildingNumber);
        if (!updated)
            return NotFound();

        return Ok();
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "User")]
    [HttpPut("addresses/{addressId}/apartmentNumber")]
    public async Task<IActionResult> UpdateApartmentNumber(Guid addressId, [FromBody] string apartmentNumber)
    {
        if (string.IsNullOrWhiteSpace(apartmentNumber))
        {
            return BadRequest("Apartment number cannot be null or empty.");
        }

        bool updated = await _userService.UpdateApartmentNumber(addressId, apartmentNumber);
        if (!updated)
            return NotFound();

        return Ok();
    }

}



