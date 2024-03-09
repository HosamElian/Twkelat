using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Twkelat.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstNameAndLastNameToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "0d25e566-fe4a-41f2-b521-51b8efb24f39");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "3482558a-3c88-4637-bef9-9ff622747d4b");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "77149e0b-cd96-4665-9d20-d6c74ec131c1", "9eb86e19-98f1-4fbc-9e1b-494f58bfc474", "Admin", "ADMIN" },
            //        { "bbdab84d-68eb-4c99-bd96-cb9bbb7beb19", "29d3b874-678c-4a82-828b-64ca3304915a", "User", "USER" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77149e0b-cd96-4665-9d20-d6c74ec131c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbdab84d-68eb-4c99-bd96-cb9bbb7beb19");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "0d25e566-fe4a-41f2-b521-51b8efb24f39", "a82cac99-c92e-4df5-babe-c304185c4d57", "User", "USER" },
            //        { "3482558a-3c88-4637-bef9-9ff622747d4b", "5ac886d6-3ced-462a-8c69-4517cfba91bf", "Admin", "ADMIN" }
            //    });
        }
    }
}
