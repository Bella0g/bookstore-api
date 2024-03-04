using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace book_store.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCartTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "CartItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CartItems",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CartItems");
        }
    }
}
