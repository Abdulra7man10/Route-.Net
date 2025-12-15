using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S3.Migrations
{
    /// <inheritdoc />
    public partial class _1ToMEmpAirline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Airlines_AirlineId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AirlineId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Assis_Pilot",
                table: "Aircrafts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CrewMaj_Pilot",
                table: "Aircrafts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Crew_Host1",
                table: "Aircrafts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Crew_Host2",
                table: "Aircrafts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AL_Id",
                table: "Employees",
                column: "AL_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Airlines_AL_Id",
                table: "Employees",
                column: "AL_Id",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Airlines_AL_Id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AL_Id",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Assis_Pilot",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "CrewMaj_Pilot",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "Crew_Host1",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "Crew_Host2",
                table: "Aircrafts");

            migrationBuilder.AddColumn<int>(
                name: "AirlineId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    AircraftId = table.Column<int>(type: "int", nullable: false),
                    Assis_Pilot = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Host1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Host2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Maj_Pilot = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.AircraftId);
                    table.ForeignKey(
                        name: "FK_Crews_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AirlineId",
                table: "Employees",
                column: "AirlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Airlines_AirlineId",
                table: "Employees",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
