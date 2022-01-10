using Microsoft.EntityFrameworkCore.Migrations;

namespace Product.Infrastructure.Migrations
{
    public partial class CreateDateBaseProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CopmanyEntities",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopmanyEntities", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "MarketEntities",
                columns: table => new
                {
                    MarketID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MarketName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketEntities", x => x.MarketID);
                });

            migrationBuilder.CreateTable(
                name: "PraceEntities",
                columns: table => new
                {
                    PriceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false),
                    MarketID = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PraceEntities", x => x.PriceID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CopmanyEntities");

            migrationBuilder.DropTable(
                name: "MarketEntities");

            migrationBuilder.DropTable(
                name: "PraceEntities");
        }
    }
}
