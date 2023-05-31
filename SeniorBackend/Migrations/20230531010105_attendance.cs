using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class attendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Session_Sessionid",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_Sessionid",
                table: "Attendance");

            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "Attendance",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "timeAttended",
                table: "Attendance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "studentId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "timeAttended",
                table: "Attendance");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Sessionid",
                table: "Attendance",
                column: "Sessionid");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Session_Sessionid",
                table: "Attendance",
                column: "Sessionid",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
