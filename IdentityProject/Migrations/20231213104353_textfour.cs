using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProject.Migrations
{
    public partial class textfour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityProjectCustomers",
                table: "IdentityProjectCustomers");

            migrationBuilder.RenameTable(
                name: "IdentityProjectCustomers",
                newName: "IdentityProjectCustomer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityProjectCustomer",
                table: "IdentityProjectCustomer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ItemPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ItemPerUnit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ItemTaxable = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ItemQnty = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Createdat = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Createdby = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Updatedat = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Updatedby = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityProjectCustomer",
                table: "IdentityProjectCustomer");

            migrationBuilder.RenameTable(
                name: "IdentityProjectCustomer",
                newName: "IdentityProjectCustomers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityProjectCustomers",
                table: "IdentityProjectCustomers",
                column: "Id");
        }
    }
}
