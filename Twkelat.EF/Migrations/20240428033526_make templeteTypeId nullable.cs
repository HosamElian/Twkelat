﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Twkelat.EF.Migrations
{
    /// <inheritdoc />
    public partial class maketempleteTypeIdnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_Templetes_TempleteId",
                table: "Blocks");


            migrationBuilder.AlterColumn<int>(
                name: "TempleteId",
                table: "Blocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");


            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_Templetes_TempleteId",
                table: "Blocks",
                column: "TempleteId",
                principalTable: "Templetes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_Templetes_TempleteId",
                table: "Blocks");



            migrationBuilder.AlterColumn<int>(
                name: "TempleteId",
                table: "Blocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

          

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_Templetes_TempleteId",
                table: "Blocks",
                column: "TempleteId",
                principalTable: "Templetes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
