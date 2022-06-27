using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    public partial class refactorPatientAndDeleteMedicalCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_medical_card_medical_card_id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_AspNetUsers_PatientId",
                table: "Consultation");

            migrationBuilder.DropTable(
                name: "medical_card");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_medical_card_id",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "medical_card_id",
                table: "AspNetUsers",
                newName: "doctor_id");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Consultation",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "AspNetUsers",
                type: "varchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "blood_type_id",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_blood_type_id",
                table: "AspNetUsers",
                column: "blood_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_doctor_id",
                table: "AspNetUsers",
                column: "doctor_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_doctor_id",
                table: "AspNetUsers",
                column: "doctor_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_blood_type_blood_type_id",
                table: "AspNetUsers",
                column: "blood_type_id",
                principalTable: "blood_type",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_AspNetUsers_PatientId",
                table: "Consultation",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_doctor_id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_blood_type_blood_type_id",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_AspNetUsers_PatientId",
                table: "Consultation");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_blood_type_id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_doctor_id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "blood_type_id",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "doctor_id",
                table: "AspNetUsers",
                newName: "medical_card_id");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Consultation",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "medical_card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    blood_type_id = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "varchar(700)", nullable: false),
                    family_doctor_name = table.Column<string>(type: "varchar(700)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medical_card_blood_type_blood_type_id",
                        column: x => x.blood_type_id,
                        principalTable: "blood_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_medical_card_id",
                table: "AspNetUsers",
                column: "medical_card_id");

            migrationBuilder.CreateIndex(
                name: "IX_medical_card_blood_type_id",
                table: "medical_card",
                column: "blood_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_medical_card_medical_card_id",
                table: "AspNetUsers",
                column: "medical_card_id",
                principalTable: "medical_card",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_AspNetUsers_PatientId",
                table: "Consultation",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
