﻿// <auto-generated />
using System;
using CustomerRealationshipManagementSystem.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerRealationshipManagementSystem.DataBase.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApartmentNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("BuildingNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.ProfilePicture", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("ProfilePictures");
                });

            modelBuilder.Entity("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PersonalIdentificationNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.Address", b =>
                {
                    b.HasOne("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.Address", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.ProfilePicture", b =>
                {
                    b.HasOne("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.User", "User")
                        .WithOne("ProfilePicture")
                        .HasForeignKey("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.ProfilePicture", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.Role", b =>
                {
                    b.HasOne("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.User", null)
                        .WithOne("UserRoles")
                        .HasForeignKey("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.Role", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerRealationshipManagementSystem.DataBase.Model.DatabaseModels.User", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("ProfilePicture")
                        .IsRequired();

                    b.Navigation("UserRoles")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
