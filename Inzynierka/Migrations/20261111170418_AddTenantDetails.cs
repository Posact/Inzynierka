using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inzynierka.Migrations
{
    /// <inheritdoc />
    public partial class AddTenantDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Tenants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsForeigner",
                table: "Tenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Pesel",
                table: "Tenants",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "IsForeigner",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Pesel",
                table: "Tenants");
        }
    }
}
