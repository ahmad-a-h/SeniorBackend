using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class addedmanytomanyclassCourseStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Classes_Classid",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Classid",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Courses_Classid",
                table: "Courses",
                column: "Classid");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Classes_Classid",
                table: "Courses",
                column: "Classid",
                principalTable: "Classes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
