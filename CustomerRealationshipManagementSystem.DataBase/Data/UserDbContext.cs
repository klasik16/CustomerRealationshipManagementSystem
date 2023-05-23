using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<ProfilePicture> ProfilePictures { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserRoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
        .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
       
        modelBuilder.Entity<Address>()
            .HasOne(a => a.User)
            .WithOne(u => u.Address)
            .HasForeignKey<Address>(a => a.UserId);

        modelBuilder.Entity<ProfilePicture>()
            .HasOne(pp => pp.User)
            .WithOne(u => u.ProfilePicture)
            .HasForeignKey<ProfilePicture>(pp => pp.UserId);
    }
}