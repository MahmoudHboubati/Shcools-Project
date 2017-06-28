using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class AddRelationStudentClassTableToBothStudentTableAndClassTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_ClassId",
                table: "StudentClasses",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_StudentId",
                table: "StudentClasses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Classes_ClassId",
                table: "StudentClasses",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Students_StudentId",
                table: "StudentClasses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Classes_ClassId",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Students_StudentId",
                table: "StudentClasses");

            migrationBuilder.DropIndex(
                name: "IX_StudentClasses_ClassId",
                table: "StudentClasses");

            migrationBuilder.DropIndex(
                name: "IX_StudentClasses_StudentId",
                table: "StudentClasses");
        }
    }
}
