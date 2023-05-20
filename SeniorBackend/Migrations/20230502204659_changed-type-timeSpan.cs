using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class changedtypetimeSpan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeSpan",
                table: "Session");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Session",
                newName: "startDateTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "endDateTime",
                table: "Session",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endDateTime",
                table: "Session");

            migrationBuilder.RenameColumn(
                name: "startDateTime",
                table: "Session",
                newName: "DateTime");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeSpan",
                table: "Session",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
