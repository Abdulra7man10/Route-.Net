using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S3.Migrations
{
    /// <inheritdoc />
    public partial class _1ToMTransAirlineWithAPIandFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Airlines_AirlineId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AirlineId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AL_Id",
                table: "Transactions",
                column: "AL_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Airlines_AL_Id",
                table: "Transactions",
                column: "AL_Id",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Airlines_AL_Id",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AL_Id",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "AirlineId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AirlineId",
                table: "Transactions",
                column: "AirlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Airlines_AirlineId",
                table: "Transactions",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
