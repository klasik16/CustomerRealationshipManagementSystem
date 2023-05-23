using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerRealationshipManagementSystem.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Street = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    BuildingNumber = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    ApartmentNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCredential",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(128)", unicode: false, maxLength: 128, nullable: false),
                    //PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCredential", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    CustomerSurname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IDCardNumber = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetail", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddress");

            migrationBuilder.DropTable(
                name: "CustomerCredential");

            migrationBuilder.DropTable(
                name: "CustomerDetail");
        }
    }
}
