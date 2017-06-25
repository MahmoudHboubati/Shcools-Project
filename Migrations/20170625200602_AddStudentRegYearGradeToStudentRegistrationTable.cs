using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class AddStudentRegYearGradeToStudentRegistrationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "StudentRegistrations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegistrationYearId",
                table: "StudentRegistrations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentRegistrations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "RegistrationYearId",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentRegistrations");
        }
    }
}
