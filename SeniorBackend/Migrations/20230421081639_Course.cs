using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class Course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "class_Id",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    class_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    building_nb = table.Column<int>(type: "int", nullable: false),
                    floor_nb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    class_nb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.class_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_class_Id",
                table: "Courses",
                column: "class_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Class_class_Id",
                table: "Courses",
                column: "class_Id",
                principalTable: "Class",
                principalColumn: "class_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Class_class_Id",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropIndex(
                name: "IX_Courses_class_Id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "class_Id",
                table: "Courses");
        }
    }
}
