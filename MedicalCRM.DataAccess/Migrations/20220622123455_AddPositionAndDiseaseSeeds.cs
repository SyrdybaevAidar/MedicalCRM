using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    public partial class AddPositionAndDiseaseSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "int", "name" },
                values: new object[,]
                {
                    { 1, "Врач терапевт" },
                    { 2, "Хирург" }
                });

            migrationBuilder.InsertData(
                table: "disease",
                columns: new[] { "int", "name" },
                values: new object[,]
                {
                    { 1, "Гайморит" },
                    { 2, "Ангина" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "disease",
                keyColumn: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "disease",
                keyColumn: "int",
                keyValue: 2);
        }
    }
}
