using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class RenameStudentRegistrationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudetnRegistrations",
                table: "StudetnRegistrations");

            migrationBuilder.RenameTable(
                name: "StudetnRegistrations",
                newName: "StudentRegistrations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentRegistrations",
                table: "StudentRegistrations",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentRegistrations",
                table: "StudentRegistrations");

            migrationBuilder.RenameTable(
                name: "StudentRegistrations",
                newName: "StudetnRegistrations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudetnRegistrations",
                table: "StudetnRegistrations",
                column: "Id");
        }
    }
}
