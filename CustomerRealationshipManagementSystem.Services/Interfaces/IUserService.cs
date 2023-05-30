using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using Microsoft.AspNetCore.Http;

public interface IUserService
{
    // User operations
    //User GetUserById(int id);
    Task<User> CreateUserAsync(User user);
    Task<byte[]> ConvertToByteArrayAsync(IFormFile profilePicture);
    //void UpdateUser(User user);
    //bool DeleteUser(int id);
    //List<User> GetAllUsers();
    // User GetUserByUsername(string username);
    //User GetUserById(Guid id);
    //User GetUserByUsername(string username);

    // Address operations
    //Address GetAddressById(int id);
    //Address CreateAddress(Address address);
    //void UpdateAddress(Address address);
    //void DeleteAddress(int id);
    //List<Address> GetAllAddresses();

    // Profile Picture operations
    //ProfilePicture GetProfilePictureById(int id);
    //ProfilePicture CreateProfilePicture(ProfilePicture picture);
    //void UpdateProfilePicture(ProfilePicture picture);
    //void DeleteProfilePicture(int id);
    //List<ProfilePicture> GetAllProfilePictures();

    //Additional User-related operations
    Task<bool> UpdateUserName(Guid userId, string username);
    Task<bool> UpdatePassword(Guid userId, string password);
    Task<bool> UpdateFirstName(Guid userId, string firstName);
    Task<bool> UpdateLastName(Guid userId, string lastName);
    Task<bool> UpdatePersonalIdentificationNumber(Guid userId, string personalIdentificationNumber);
    Task<bool> UpdateEmail(Guid userId, string email);
    Task<bool> UpdatePhoneNumber(Guid userId, string phoneNumber);
    Task<bool> UpdateCity(Guid addressId, string city);
    Task<bool> UpdateUserStreet(Guid addressId, string street);
    Task<bool> UpdateBuildingNumber(Guid addressId, string buildingNumber);
    Task<bool> UpdateApartmentNumber(Guid addressId, string apartmentNumber);
    Task<User> GetUserByUsernameAndPassword(string username, string password);
}