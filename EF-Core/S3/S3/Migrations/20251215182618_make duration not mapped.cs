using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S3.Migrations
{
    /// <inheritdoc />
    public partial class makedurationnotmapped : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationMinutes",
                table: "FlightAssignments");

            migrationBuilder.AlterColumn<int>(
                name: "Num_Of_Passengers",
                table: "FlightAssignments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Num_Of_Passengers",
                table: "FlightAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DurationMinutes",
                table: "FlightAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
