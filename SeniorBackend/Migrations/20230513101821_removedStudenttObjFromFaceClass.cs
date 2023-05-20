using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class removedStudenttObjFromFaceClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Face_Students_StudentsId",
                table: "Face");

            migrationBuilder.DropIndex(
                name: "IX_Face_StudentsId",
                table: "Face");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Face");

            migrationBuilder.CreateIndex(
                name: "IX_Students_faceID",
                table: "Students",
                column: "faceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Face_faceID",
                table: "Students",
                column: "faceID",
                principalTable: "Face",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Face_faceID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_faceID",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Face",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Face_StudentsId",
                table: "Face",
                column: "StudentsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Face_Students_StudentsId",
                table: "Face",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
