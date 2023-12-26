using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProject.Migrations
{
    public partial class testfive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityProjectCustomer",
                table: "IdentityProjectCustomer");

            migrationBuilder.RenameTable(
                name: "IdentityProjectCustomer",
                newName: "IdentityProjectCustomers");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Inventory",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityProjectCustomers",
                table: "IdentityProjectCustomers",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityProjectCustomers",
                table: "IdentityProjectCustomers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Inventory");

            migrationBuilder.RenameTable(
                name: "IdentityProjectCustomers",
                newName: "IdentityProjectCustomer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityProjectCustomer",
                table: "IdentityProjectCustomer",
                column: "Id");
        }
    }
}
