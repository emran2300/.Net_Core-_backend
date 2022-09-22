using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApplication.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryCatId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryCatId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryCatId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "CatName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CatName",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CatId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryCatId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryCatId",
                table: "Products",
                column: "CategoryCatId");

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
