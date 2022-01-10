using Microsoft.EntityFrameworkCore.Migrations;

namespace Product.Infrastructure.Migrations
{
    public partial class updatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarketName",
                table: "PraceEntities");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "PraceEntities");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "PraceEntities",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "PraceEntities",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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
    }
}
