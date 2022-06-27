using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    public partial class changeAddress1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FamilyDoctorName",
                table: "medical_card",
                newName: "family_doctor_name");

            migrationBuilder.AlterColumn<string>(
                name: "family_doctor_name",
                table: "medical_card",
                type: "varchar(700)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "family_doctor_name",
                table: "medical_card",
                newName: "FamilyDoctorName");

            migrationBuilder.AlterColumn<string>(
                name: "FamilyDoctorName",
                table: "medical_card",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(700)");
        }
    }
}
