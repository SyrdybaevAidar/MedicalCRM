using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    public partial class consultationdisease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_AspNetUsers_DoctorId",
                table: "Consultation");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_AspNetUsers_PatientId",
                table: "Consultation");

            migrationBuilder.DropTable(
                name: "consultation_by_disaeses");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Consultation",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Consultation",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Consultation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ConsultationDisease",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConsultationId = table.Column<int>(type: "integer", nullable: false),
                    DiseaseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationDisease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultationDisease_Consultation_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultationDisease_disease_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "disease",
                        principalColumn: "int",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationDisease_ConsultationId",
                table: "ConsultationDisease",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationDisease_DiseaseId",
                table: "ConsultationDisease",
                column: "DiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_AspNetUsers_DoctorId",
                table: "Consultation",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_AspNetUsers_PatientId",
                table: "Consultation",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_AspNetUsers_DoctorId",
                table: "Consultation");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_AspNetUsers_PatientId",
                table: "Consultation");

            migrationBuilder.DropTable(
                name: "ConsultationDisease");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Consultation");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Consultation",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Consultation",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "consultation_by_disaeses",
                columns: table => new
                {
                    ChronicalDiseasesId = table.Column<int>(type: "integer", nullable: false),
                    ConsultationsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultation_by_disaeses", x => new { x.ChronicalDiseasesId, x.ConsultationsId });
                    table.ForeignKey(
                        name: "FK_consultation_by_disaeses_Consultation_ConsultationsId",
                        column: x => x.ConsultationsId,
                        principalTable: "Consultation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_consultation_by_disaeses_disease_ChronicalDiseasesId",
                        column: x => x.ChronicalDiseasesId,
                        principalTable: "disease",
                        principalColumn: "int",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_consultation_by_disaeses_ConsultationsId",
                table: "consultation_by_disaeses",
                column: "ConsultationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_AspNetUsers_DoctorId",
                table: "Consultation",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_AspNetUsers_PatientId",
                table: "Consultation",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
