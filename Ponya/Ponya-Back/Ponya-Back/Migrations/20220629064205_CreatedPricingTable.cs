using Microsoft.EntityFrameworkCore.Migrations;

namespace Ponya_Back.Migrations
{
    public partial class CreatedPricingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    CostPrice = table.Column<double>(nullable: false),
                    SellPrice = table.Column<double>(nullable: false),
                    DiscountPrice = table.Column<double>(nullable: true),
                    StockCount = table.Column<int>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pricings");
        }
    }
}
