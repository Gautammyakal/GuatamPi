using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AjaxDemoASPMVC.Migrations
{
    /// <inheritdoc />
    public partial class gautam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments1",
                columns: table => new
                {
                    Department1Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(name: "Dept_Name", type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments1", x => x.Department1Id);
                });

            migrationBuilder.CreateTable(
                name: "designations1",
                columns: table => new
                {
                    Designation1Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(name: "Designation_Name", type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designations1", x => x.Designation1Id);
                });

            migrationBuilder.CreateTable(
                name: "genders1",
                columns: table => new
                {
                    Gender1Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(name: "Gender_Name", type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genders1", x => x.Gender1Id);
                });

            migrationBuilder.CreateTable(
                name: "skills1",
                columns: table => new
                {
                    Skill1Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(name: "Skill_Name", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills1", x => x.Skill1Id);
                });

            migrationBuilder.CreateTable(
                name: "employees1",
                columns: table => new
                {
                    Employee1Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Gender1Id = table.Column<int>(type: "int", nullable: false),
                    depaartment1Department1Id = table.Column<int>(type: "int", nullable: false),
                    Designation1Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees1", x => x.Employee1Id);
                    table.ForeignKey(
                        name: "FK_employees1_departments1_depaartment1Department1Id",
                        column: x => x.depaartment1Department1Id,
                        principalTable: "departments1",
                        principalColumn: "Department1Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees1_designations1_Designation1Id",
                        column: x => x.Designation1Id,
                        principalTable: "designations1",
                        principalColumn: "Designation1Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees1_genders1_Gender1Id",
                        column: x => x.Gender1Id,
                        principalTable: "genders1",
                        principalColumn: "Gender1Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employeeskills1",
                columns: table => new
                {
                    Empid = table.Column<int>(type: "int", nullable: false),
                    Skillid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeskills1", x => new { x.Empid, x.Skillid });
                    table.ForeignKey(
                        name: "FK_employeeskills1_employees1_Empid",
                        column: x => x.Empid,
                        principalTable: "employees1",
                        principalColumn: "Employee1Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeeskills1_skills1_Skillid",
                        column: x => x.Skillid,
                        principalTable: "skills1",
                        principalColumn: "Skill1Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departments1_Dept_Name",
                table: "departments1",
                column: "Dept_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_designations1_Designation_Name",
                table: "designations1",
                column: "Designation_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees1_depaartment1Department1Id",
                table: "employees1",
                column: "depaartment1Department1Id");

            migrationBuilder.CreateIndex(
                name: "IX_employees1_Designation1Id",
                table: "employees1",
                column: "Designation1Id");

            migrationBuilder.CreateIndex(
                name: "IX_employees1_Gender1Id",
                table: "employees1",
                column: "Gender1Id");

            migrationBuilder.CreateIndex(
                name: "IX_employeeskills1_Skillid",
                table: "employeeskills1",
                column: "Skillid");

            migrationBuilder.CreateIndex(
                name: "IX_genders1_Gender_Name",
                table: "genders1",
                column: "Gender_Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeeskills1");

            migrationBuilder.DropTable(
                name: "employees1");

            migrationBuilder.DropTable(
                name: "skills1");

            migrationBuilder.DropTable(
                name: "departments1");

            migrationBuilder.DropTable(
                name: "designations1");

            migrationBuilder.DropTable(
                name: "genders1");
        }
    }
}
