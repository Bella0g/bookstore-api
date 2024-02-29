using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace book_store.Migrations
{
    /// <inheritdoc />
    public partial class AddedModelsToCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Product",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Cart",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Cart",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CartId",
                table: "Product",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Cart_CartId",
                table: "Product",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Cart_CartId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CartId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Cart");
        }
    }
}
