using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    public partial class consultationdisease1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultationDisease_Consultation_ConsultationId",
                table: "ConsultationDisease");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultationDisease_disease_DiseaseId",
                table: "ConsultationDisease");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultationDisease",
                table: "ConsultationDisease");

            migrationBuilder.RenameTable(
                name: "ConsultationDisease",
                newName: "consultation_by_disaeses");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultationDisease_DiseaseId",
                table: "consultation_by_disaeses",
                newName: "IX_consultation_by_disaeses_DiseaseId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultationDisease_ConsultationId",
                table: "consultation_by_disaeses",
                newName: "IX_consultation_by_disaeses_ConsultationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_consultation_by_disaeses",
                table: "consultation_by_disaeses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_consultation_by_disaeses_Consultation_ConsultationId",
                table: "consultation_by_disaeses",
                column: "ConsultationId",
                principalTable: "Consultation",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_consultation_by_disaeses_disease_DiseaseId",
                table: "consultation_by_disaeses",
                column: "DiseaseId",
                principalTable: "disease",
                principalColumn: "int",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_consultation_by_disaeses_Consultation_ConsultationId",
                table: "consultation_by_disaeses");

            migrationBuilder.DropForeignKey(
                name: "FK_consultation_by_disaeses_disease_DiseaseId",
                table: "consultation_by_disaeses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_consultation_by_disaeses",
                table: "consultation_by_disaeses");

            migrationBuilder.RenameTable(
                name: "consultation_by_disaeses",
                newName: "ConsultationDisease");

            migrationBuilder.RenameIndex(
                name: "IX_consultation_by_disaeses_DiseaseId",
                table: "ConsultationDisease",
                newName: "IX_ConsultationDisease_DiseaseId");

            migrationBuilder.RenameIndex(
                name: "IX_consultation_by_disaeses_ConsultationId",
                table: "ConsultationDisease",
                newName: "IX_ConsultationDisease_ConsultationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultationDisease",
                table: "ConsultationDisease",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultationDisease_Consultation_ConsultationId",
                table: "ConsultationDisease",
                column: "ConsultationId",
                principalTable: "Consultation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultationDisease_disease_DiseaseId",
                table: "ConsultationDisease",
                column: "DiseaseId",
                principalTable: "disease",
                principalColumn: "int",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
