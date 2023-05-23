using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using Microsoft.EntityFrameworkCore;

public interface IDbContext
{
    DbSet<User> Users { get; set; }
    // Add DbSet properties for other entities as needed

    int SaveChanges();
}