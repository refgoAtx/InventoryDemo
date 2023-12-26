using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProject.Migrations
{
    public partial class inventoryadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InventoryID",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_InventoryID",
                table: "Projects",
                column: "InventoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Inventory_InventoryID",
                table: "Projects",
                column: "InventoryID",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Inventory_InventoryID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_InventoryID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "InventoryID",
                table: "Projects");
        }
    }
}
