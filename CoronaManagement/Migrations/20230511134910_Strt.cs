using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoronaManagement.Migrations
{
    /// <inheritdoc />
    public partial class Strt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CellphoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVaccinated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfPositiveTest = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecoveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VaccinationDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfFirstVaccination = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfSecondtVaccination = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfThirdVaccination = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfFourthVaccination = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CoronaDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationDates_Vaccinations_CoronaDetailsId",
                        column: x => x.CoronaDetailsId,
                        principalTable: "Vaccinations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VaccinationInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerOfFirstVaccination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerOfSecondtVaccination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerOfThirdVaccination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerOfFourthVaccination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoronaDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccinationInfo_Vaccinations_CoronaDetailsId",
                        column: x => x.CoronaDetailsId,
                        principalTable: "Vaccinations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDates_CoronaDetailsId",
                table: "VaccinationDates",
                column: "CoronaDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationInfo_CoronaDetailsId",
                table: "VaccinationInfo",
                column: "CoronaDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_PatientId",
                table: "Vaccinations",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationDates");

            migrationBuilder.DropTable(
                name: "VaccinationInfo");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
