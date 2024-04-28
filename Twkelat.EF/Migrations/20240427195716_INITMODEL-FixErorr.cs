using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Twkelat.EF.Migrations
{
    /// <inheritdoc />
    public partial class INITMODELFixErorr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_AspNetUsers_CreatedById",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_AspNetUsers_CreatedForId",
                table: "Blocks");

            migrationBuilder.DropIndex(
                name: "IX_Blocks_CreatedById",
                table: "Blocks");

            migrationBuilder.DropIndex(
                name: "IX_Blocks_CreatedForId",
                table: "Blocks");


            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "CreatedForId",
                table: "Blocks");

            migrationBuilder.AlterColumn<string>(
                name: "CreateForId",
                table: "Blocks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreateById",
                table: "Blocks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

           

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_CreateById",
                table: "Blocks",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_CreateForId",
                table: "Blocks",
                column: "CreateForId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_AspNetUsers_CreateById",
                table: "Blocks",
                column: "CreateById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_AspNetUsers_CreateForId",
                table: "Blocks",
                column: "CreateForId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_AspNetUsers_CreateById",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_AspNetUsers_CreateForId",
                table: "Blocks");

            migrationBuilder.DropIndex(
                name: "IX_Blocks_CreateById",
                table: "Blocks");

            migrationBuilder.DropIndex(
                name: "IX_Blocks_CreateForId",
                table: "Blocks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18b234f7-6c99-4c3d-81d9-7e982abb165a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4cd07a4-eb1d-4ba5-8ac4-80029b80f1e2");

            migrationBuilder.AlterColumn<string>(
                name: "CreateForId",
                table: "Blocks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CreateById",
                table: "Blocks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Blocks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedForId",
                table: "Blocks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f22fda0-31cd-479e-b291-a6fda6f9f88f", "ab6c7929-7f32-4787-b2a4-971a68b11937", "Admin", "ADMIN" },
                    { "fb496a34-6aac-421a-a1fd-ce07a66381ce", "3aa79902-31e0-45e1-8b83-1f8406127996", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_CreatedById",
                table: "Blocks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_CreatedForId",
                table: "Blocks",
                column: "CreatedForId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_AspNetUsers_CreatedById",
                table: "Blocks",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_AspNetUsers_CreatedForId",
                table: "Blocks",
                column: "CreatedForId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
