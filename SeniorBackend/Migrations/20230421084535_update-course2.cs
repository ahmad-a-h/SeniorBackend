using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class updatecourse2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "building_nb",
                table: "Classes");

            migrationBuilder.AddColumn<string>(
                name: "building",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "building",
                table: "Classes");

            migrationBuilder.AddColumn<int>(
                name: "building_nb",
                table: "Classes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
