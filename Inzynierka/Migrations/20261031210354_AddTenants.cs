using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inzynierka.Migrations
{
    /// <inheritdoc />
    public partial class AddTenants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantName",
                table: "Leases");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Leases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leases_TenantId",
                table: "Leases",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leases_Tenants_TenantId",
                table: "Leases",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leases_Tenants_TenantId",
                table: "Leases");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Leases_TenantId",
                table: "Leases");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Leases");

            migrationBuilder.AddColumn<string>(
                name: "TenantName",
                table: "Leases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
