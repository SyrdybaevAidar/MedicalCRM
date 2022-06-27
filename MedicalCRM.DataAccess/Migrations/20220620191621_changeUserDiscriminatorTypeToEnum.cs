using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    public partial class changeUserDiscriminatorTypeToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserType",
                table: "AspNetUsers",
                newName: "user_type");

            migrationBuilder.AlterColumn<string>(
                name: "user_type",
                table: "AspNetUsers",
                type: "varchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_type",
                table: "AspNetUsers",
                newName: "UserType");

            migrationBuilder.AlterColumn<string>(
                name: "UserType",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)");
        }
    }
}
