using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDatabase.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalTotal",
                table: "Rentals");

            migrationBuilder.AddColumn<int>(
                name: "RentalTotal",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalTotal",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "RentalTotal",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
