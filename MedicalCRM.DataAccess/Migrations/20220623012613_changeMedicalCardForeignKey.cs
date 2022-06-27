using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    public partial class changeMedicalCardForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_medical_card_medical_card_id",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_medical_card_medical_card_id",
                table: "AspNetUsers",
                column: "medical_card_id",
                principalTable: "medical_card",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_medical_card_medical_card_id",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_medical_card_medical_card_id",
                table: "AspNetUsers",
                column: "medical_card_id",
                principalTable: "medical_card",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
