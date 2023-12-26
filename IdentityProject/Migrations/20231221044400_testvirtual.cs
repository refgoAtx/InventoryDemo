using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityProject.Migrations
{
    public partial class testvirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CustomerID",
                table: "Inventory",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Customers_CustomerID",
                table: "Inventory",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Customers_CustomerID",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_CustomerID",
                table: "Inventory");
        }
    }
}
