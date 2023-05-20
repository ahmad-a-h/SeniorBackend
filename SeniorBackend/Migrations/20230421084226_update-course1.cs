using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class updatecourse1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Class_class_Id",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class",
                table: "Class");

            migrationBuilder.RenameTable(
                name: "Class",
                newName: "Classes");

            migrationBuilder.AlterColumn<int>(
                name: "floor_nb",
                table: "Classes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "class_nb",
                table: "Classes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "class_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Classes_class_Id",
                table: "Courses",
                column: "class_Id",
                principalTable: "Classes",
                principalColumn: "class_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Classes_class_Id",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "Class");

            migrationBuilder.AlterColumn<string>(
                name: "floor_nb",
                table: "Class",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "class_nb",
                table: "Class",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class",
                table: "Class",
                column: "class_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Class_class_Id",
                table: "Courses",
                column: "class_Id",
                principalTable: "Class",
                principalColumn: "class_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
