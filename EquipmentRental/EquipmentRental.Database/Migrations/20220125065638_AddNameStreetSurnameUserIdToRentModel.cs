using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipmentRental.Database.Migrations
{
    public partial class AddNameStreetSurnameUserIdToRentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Rents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Rents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Rents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Rents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserId",
                table: "Rents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Users_UserId",
                table: "Rents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Users_UserId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_UserId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Rents");
        }
    }
}
