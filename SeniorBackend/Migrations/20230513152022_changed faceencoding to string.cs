using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeniorBackend.Migrations
{
    public partial class changedfaceencodingtostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Face_faceID",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Face",
                table: "Face");

            migrationBuilder.RenameTable(
                name: "Face",
                newName: "FaceEncoding");

            migrationBuilder.AlterColumn<string>(
                name: "FaceEncoding",
                table: "FaceEncoding",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FaceEncoding",
                table: "FaceEncoding",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_FaceEncoding_faceID",
                table: "Students",
                column: "faceID",
                principalTable: "FaceEncoding",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_FaceEncoding_faceID",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FaceEncoding",
                table: "FaceEncoding");

            migrationBuilder.RenameTable(
                name: "FaceEncoding",
                newName: "Face");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FaceEncoding",
                table: "Face",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Face",
                table: "Face",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Face_faceID",
                table: "Students",
                column: "faceID",
                principalTable: "Face",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
