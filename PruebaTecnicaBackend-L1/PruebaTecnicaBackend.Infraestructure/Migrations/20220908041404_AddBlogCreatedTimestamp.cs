﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnicaBackend.Infraestructure.Migrations
{
    public partial class AddBlogCreatedTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classroom",
                columns: table => new
                {
                    ClassroomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classroom", x => x.ClassroomId);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    States = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Turn = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    DateCrete = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    DateDelete = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Matter = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfessorId);
                    table.ForeignKey(
                        name: "FK__Professor__Class__4D94879B",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "ClassroomId");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK__Student__Classro__398D8EEE",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "ClassroomId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professor_ClassroomId",
                table: "Professor",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassroomId",
                table: "Student",
                column: "ClassroomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Classroom");
        }
    }
}
