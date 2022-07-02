using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    public partial class changeReceptConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recept_by_medicament_recept_Id",
                table: "recept_by_medicament");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "recept_by_medicament",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_recept_by_medicament_recept_ReceptId",
                table: "recept_by_medicament",
                column: "ReceptId",
                principalTable: "recept",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recept_by_medicament_recept_ReceptId",
                table: "recept_by_medicament");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "recept_by_medicament",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_recept_by_medicament_recept_Id",
                table: "recept_by_medicament",
                column: "Id",
                principalTable: "recept",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
