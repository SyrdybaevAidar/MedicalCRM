using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    public partial class changeMedicalCardForeignKey1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_medical_card_id",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_medical_card_id",
                table: "AspNetUsers",
                column: "medical_card_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_medical_card_id",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_medical_card_id",
                table: "AspNetUsers",
                column: "medical_card_id",
                unique: true);
        }
    }
}
