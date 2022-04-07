using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Data.Migrations
{
    public partial class add_shpping_price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Shippings",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Shippings");
        }
    }
}
