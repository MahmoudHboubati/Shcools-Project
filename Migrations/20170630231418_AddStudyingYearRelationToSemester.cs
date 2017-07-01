using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class AddStudyingYearRelationToSemester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudyingYearId",
                table: "Semesters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_StudyingYearId",
                table: "Semesters",
                column: "StudyingYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Semesters_StudyingYears_StudyingYearId",
                table: "Semesters",
                column: "StudyingYearId",
                principalTable: "StudyingYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Semesters_StudyingYears_StudyingYearId",
                table: "Semesters");

            migrationBuilder.DropIndex(
                name: "IX_Semesters_StudyingYearId",
                table: "Semesters");

            migrationBuilder.DropColumn(
                name: "StudyingYearId",
                table: "Semesters");
        }
    }
}
