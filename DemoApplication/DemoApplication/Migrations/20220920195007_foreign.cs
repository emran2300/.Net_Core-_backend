using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApplication.Migrations
{
    public partial class foreign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryCatId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryCatId",
                table: "Products",
                newName: "CatId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryCatId",
                table: "Products",
                newName: "IX_Products_CatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CatId",
                table: "Products",
                column: "CatId",
                principalTable: "Categories",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CatId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CatId",
                table: "Products",
                newName: "CategoryCatId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CatId",
                table: "Products",
                newName: "IX_Products_CategoryCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryCatId",
                table: "Products",
                column: "CategoryCatId",
                principalTable: "Categories",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
