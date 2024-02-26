using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace book_store.Migrations
{
    /// <inheritdoc />
    public partial class deletetimageproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Product");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
