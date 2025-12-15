using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S3.Migrations
{
    /// <inheritdoc />
    public partial class _1ToMCraftAirlineWithAPIandFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircrafts_Airlines_AirlineId",
                table: "Aircrafts");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Airlines_AL_Id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Aircrafts_AirlineId",
                table: "Aircrafts");

            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "Aircrafts");

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_AL_Id",
                table: "Aircrafts",
                column: "AL_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aircrafts_Airlines_AL_Id",
                table: "Aircrafts",
                column: "AL_Id",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Airlines_AL_Id",
                table: "Employees",
                column: "AL_Id",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircrafts_Airlines_AL_Id",
                table: "Aircrafts");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Airlines_AL_Id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Aircrafts_AL_Id",
                table: "Aircrafts");

            migrationBuilder.AddColumn<int>(
                name: "AirlineId",
                table: "Aircrafts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Aircrafts_AirlineId",
                table: "Aircrafts",
                column: "AirlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aircrafts_Airlines_AirlineId",
                table: "Aircrafts",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Airlines_AL_Id",
                table: "Employees",
                column: "AL_Id",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
