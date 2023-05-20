using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Classes_Classid",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "class_id",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "Classid",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Classes_Classid",
                table: "Courses",
                column: "Classid",
                principalTable: "Classes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Classes_Classid",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "Classid",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "class_id",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Classes_Classid",
                table: "Courses",
                column: "Classid",
                principalTable: "Classes",
                principalColumn: "id");
        }
    }
}
