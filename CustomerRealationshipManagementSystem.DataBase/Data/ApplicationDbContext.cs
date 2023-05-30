using Microsoft.EntityFrameworkCore;
using CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels;

namespace CustomerRealationshipManagementSystem.DataBase
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserRoles)
                .WithOne()
                .HasForeignKey<Role>(r => r.Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(u => u.ProfilePicture)
                .WithOne(a => a.User)
                .HasForeignKey<ProfilePicture>(p => p.Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.Id)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
