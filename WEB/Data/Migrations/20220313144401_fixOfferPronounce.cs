using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEB.Data.Migrations
{
    public partial class fixOfferPronounce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartOferAt",
                table: "Products",
                newName: "StartOfferAt");

            migrationBuilder.RenameColumn(
                name: "EndtOferAt",
                table: "Products",
                newName: "EndOfferAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartOfferAt",
                table: "Products",
                newName: "StartOferAt");

            migrationBuilder.RenameColumn(
                name: "EndOfferAt",
                table: "Products",
                newName: "EndtOferAt");
        }
    }
}
