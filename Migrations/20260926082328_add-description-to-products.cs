using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductProjectCRUD.Migrations
{
    /// <inheritdoc />
    public partial class adddescriptiontoproducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Product",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "Product");
        }
    }
}
