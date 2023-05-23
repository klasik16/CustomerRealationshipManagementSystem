﻿using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly UserDbContext _dbContext;

    public UserService(IDbContext dbContext)
    {
        _dbContext = (UserDbContext?)dbContext;
    }

    public IEnumerable<User> GetUsers()
    {
        return _dbContext.Users.Include(u => u.Address).Include(u => u.ProfilePicture).ToList();
    }

    public User GetUserById(int id)
    {
        return _dbContext.Users.Include(u => u.Address).Include(u => u.ProfilePicture).FirstOrDefault(u => u.UserId == id);
    }

    public User CreateUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        return user;
    }

    public User UpdateUser(int id, User user)
    {
        var existingUser = _dbContext.Users.FirstOrDefault(u => u.UserId == id);
        if (existingUser != null)
        {
            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.PersonalIdentificationNumber = user.PersonalIdentificationNumber;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;

            existingUser.Address.City = user.Address.City;
            existingUser.Address.Street = user.Address.Street;
            existingUser.Address.BuildingNumber = user.Address.BuildingNumber;
            existingUser.Address.ApartmentNumber = user.Address.ApartmentNumber;

            _dbContext.SaveChanges();
            return existingUser;
        }

        return null;
    }

    public bool DeleteUser(int id)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.UserId == id);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return true;
        }

        return false;
    }
}