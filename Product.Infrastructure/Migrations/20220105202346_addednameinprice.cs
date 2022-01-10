using Microsoft.EntityFrameworkCore.Migrations;

namespace Product.Infrastructure.Migrations
{
    public partial class addednameinprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MarketName",
                table: "PraceEntities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "PraceEntities",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarketName",
                table: "PraceEntities");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "PraceEntities");
        }
    }
}
