using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipmentRental.Database.Migrations
{
    public partial class FixSportEquipmentRelationshipToRents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rents_SportEquipmentId",
                table: "Rents");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_SportEquipmentId",
                table: "Rents",
                column: "SportEquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rents_SportEquipmentId",
                table: "Rents");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_SportEquipmentId",
                table: "Rents",
                column: "SportEquipmentId",
                unique: true);
        }
    }
}
