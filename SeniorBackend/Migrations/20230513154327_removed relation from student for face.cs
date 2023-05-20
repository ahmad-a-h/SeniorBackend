using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class removedrelationfromstudentforface : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_FaceEncoding_faceID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_faceID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "faceID",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "faceID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_faceID",
                table: "Students",
                column: "faceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_FaceEncoding_faceID",
                table: "Students",
                column: "faceID",
                principalTable: "FaceEncoding",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
