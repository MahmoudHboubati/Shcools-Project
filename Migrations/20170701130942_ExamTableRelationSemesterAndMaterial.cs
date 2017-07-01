using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class ExamTableRelationSemesterAndMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Exams_MaterialId",
                table: "Exams",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SemesterId",
                table: "Exams",
                column: "SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Materials_MaterialId",
                table: "Exams",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Semesters_SemesterId",
                table: "Exams",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Materials_MaterialId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Semesters_SemesterId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_MaterialId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_SemesterId",
                table: "Exams");
        }
    }
}
