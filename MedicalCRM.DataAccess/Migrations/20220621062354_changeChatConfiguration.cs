using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    public partial class changeChatConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_chat_doctor_id",
                table: "chat");

            migrationBuilder.DropIndex(
                name: "IX_chat_patient_id",
                table: "chat");

            migrationBuilder.CreateIndex(
                name: "IX_chat_doctor_id",
                table: "chat",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_chat_patient_id",
                table: "chat",
                column: "patient_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_chat_doctor_id",
                table: "chat");

            migrationBuilder.DropIndex(
                name: "IX_chat_patient_id",
                table: "chat");

            migrationBuilder.CreateIndex(
                name: "IX_chat_doctor_id",
                table: "chat",
                column: "doctor_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chat_patient_id",
                table: "chat",
                column: "patient_id",
                unique: true);
        }
    }
}
