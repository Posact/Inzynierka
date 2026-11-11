using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inzynierka.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Area",
                table: "Properties",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasBalcony",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RoomCount",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "HasBalcony",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "RoomCount",
                table: "Properties");
        }
    }
}
