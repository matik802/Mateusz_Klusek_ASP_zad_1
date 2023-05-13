using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FizzBuzzWeb.Migrations
{
    public partial class edit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Created",
                table: "Form",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Form",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Form");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Form");
        }
    }
}
