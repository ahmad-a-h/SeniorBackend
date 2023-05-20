using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class addedsessionttileforsession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Session",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Session");
        }
    }
}
