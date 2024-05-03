using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Twkelat.EF.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFirstnametonamelastnametoemailinApplicationuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Name");

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "960bae76-dadc-4cda-b277-3a6f9e59e651", "e3185bc9-fa71-459c-b9a6-9374f66543d2", "User", "USER" },
                    { "df7eafe7-3280-4630-b128-f5db58e609a1", "f7d4450c-89be-44f2-892e-d2d294062bab", "Admin", "ADMIN" }
                });
        }
    }
}
