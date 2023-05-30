using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerRealationshipManagementSystem.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "ProfilePictures");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "ProfilePictures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
