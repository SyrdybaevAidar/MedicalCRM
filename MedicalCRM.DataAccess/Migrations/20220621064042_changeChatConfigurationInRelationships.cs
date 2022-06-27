using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    public partial class changeChatConfigurationInRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chat_AspNetUsers_doctor_id",
                table: "chat");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_AspNetUsers_patient_id",
                table: "chat");

            migrationBuilder.AddForeignKey(
                name: "FK_chat_AspNetUsers_doctor_id",
                table: "chat",
                column: "doctor_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_AspNetUsers_patient_id",
                table: "chat",
                column: "patient_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chat_AspNetUsers_doctor_id",
                table: "chat");

            migrationBuilder.DropForeignKey(
                name: "FK_chat_AspNetUsers_patient_id",
                table: "chat");

            migrationBuilder.AddForeignKey(
                name: "FK_chat_AspNetUsers_doctor_id",
                table: "chat",
                column: "doctor_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_chat_AspNetUsers_patient_id",
                table: "chat",
                column: "patient_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
