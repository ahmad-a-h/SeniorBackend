using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class updatecourse3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Classes_class_Id",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_class_Id",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "class_Id",
                table: "Courses",
                newName: "class_id");

            migrationBuilder.RenameColumn(
                name: "course_Id",
                table: "Courses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "class_Id",
                table: "Classes",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "Classid",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Classid",
                table: "Courses",
                column: "Classid");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Classes_Classid",
                table: "Courses",
                column: "Classid",
                principalTable: "Classes",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Classes_Classid",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_Classid",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Classid",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "class_id",
                table: "Courses",
                newName: "class_Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Courses",
                newName: "course_Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Classes",
                newName: "class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_class_Id",
                table: "Courses",
                column: "class_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Classes_class_Id",
                table: "Courses",
                column: "class_Id",
                principalTable: "Classes",
                principalColumn: "class_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
