using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class addedmanytomanyclassCourseStudent1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CourseStudent",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_Coursesid",
                table: "CourseStudent",
                column: "Coursesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudent_Coursesid",
                table: "CourseStudent");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseStudent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudent",
                table: "CourseStudent",
                columns: new[] { "Coursesid", "StudentsId" });
        }
    }
}
