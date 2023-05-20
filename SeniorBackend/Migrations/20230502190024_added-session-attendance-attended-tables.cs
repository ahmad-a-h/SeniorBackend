using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class addedsessionattendanceattendedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "faceID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Attendanded",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendanded", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendanded_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Face",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaceEncoding = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Face", x => x.id);
                    table.ForeignKey(
                        name: "FK_Face_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeSpan = table.Column<TimeSpan>(type: "time", nullable: false),
                    Coursesid = table.Column<int>(type: "int", nullable: false),
                    Classesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_Classes_Classesid",
                        column: x => x.Classesid,
                        principalTable: "Classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Session_Courses_Coursesid",
                        column: x => x.Coursesid,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sessionid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendance_Session_Sessionid",
                        column: x => x.Sessionid,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Sessionid",
                table: "Attendance",
                column: "Sessionid");

            migrationBuilder.CreateIndex(
                name: "IX_Attendanded_StudentId",
                table: "Attendanded",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Face_StudentsId",
                table: "Face",
                column: "StudentsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Session_Classesid",
                table: "Session",
                column: "Classesid");

            migrationBuilder.CreateIndex(
                name: "IX_Session_Coursesid",
                table: "Session",
                column: "Coursesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "Attendanded");

            migrationBuilder.DropTable(
                name: "Face");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropColumn(
                name: "faceID",
                table: "Students");
        }
    }
}
