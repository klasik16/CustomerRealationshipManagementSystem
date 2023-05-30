using CustomerRealationshipManagementSystem.DataBase;
using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<byte[]> ConvertToByteArrayAsync(IFormFile profilePicture)
    {
        using (var memoryStream = new MemoryStream())
        {
            await profilePicture.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }

    public async Task<bool> UpdateUserName(Guid userId, string username)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user == null)
            return false;

        user.Username = username;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdatePassword(Guid userId, string password)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user == null)
            return false;

        user.Password = password;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateFirstName(Guid userId, string firstName)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user == null)
            return false;

        user.FirstName = firstName;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateLastName(Guid userId, string lastName)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user == null)
            return false;

        user.LastName = lastName;
        await _dbContext.SaveChangesAsync();
        return true;
    }


    public async Task<bool> UpdatePersonalIdentificationNumber(Guid userId, string personalIdentificationNumber)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user == null)
            return false;

        user.PersonalIdentificationNumber = personalIdentificationNumber;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateEmail(Guid userId, string email)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user == null)
            return false;

        user.Email = email;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdatePhoneNumber(Guid userId, string phoneNumber)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user == null)
            return false;

        user.PhoneNumber = phoneNumber;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateCity(Guid addressId, string city)
    {
        var address = await _dbContext.Addresses.FindAsync(addressId);
        if (address == null)
            return false;

        address.City = city;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateUserStreet(Guid addressId, string street)
    {
        var address = await _dbContext.Addresses.FindAsync(addressId);
        if (address == null)
            return false;

        address.Street = street;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateBuildingNumber(Guid addressId, string buildingNumber)
    {
        var address = await _dbContext.Addresses.FindAsync(addressId);
        if (address == null)
            return false;

        address.BuildingNumber = buildingNumber;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateApartmentNumber(Guid addressId, string apartmentNumber)
    {
        var address = await _dbContext.Addresses.FindAsync(addressId);
        if (address == null)
            return false;

        address.ApartmentNumber = apartmentNumber;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public User GetUserByUsername(string username)
    {
        throw new NotImplementedException();
    }
    public async Task<User> GetUserByUsernameAndPassword(string username, string password)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

        // Verify the password
        if (user != null && VerifyPassword(password, user.Password))
        {
            return user;
        }

        return null;
    }

    private bool VerifyPassword(string password, string hashedPassword)
    {
        // Verify the password using bcrypt's Verify method
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}

