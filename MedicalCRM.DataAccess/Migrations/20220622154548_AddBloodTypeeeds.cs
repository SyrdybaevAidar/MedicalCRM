using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    public partial class AddBloodTypeeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "blood_type",
                columns: new[] { "id", "rhesus_factore", "type" },
                values: new object[,]
                {
                    { 1, 0, 1 },
                    { 2, 0, 2 },
                    { 3, 0, 3 },
                    { 4, 0, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "blood_type",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "blood_type",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "blood_type",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "blood_type",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
