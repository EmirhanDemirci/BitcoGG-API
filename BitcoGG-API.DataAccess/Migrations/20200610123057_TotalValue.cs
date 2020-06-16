using Microsoft.EntityFrameworkCore.Migrations;

namespace BitcoGG_API.DataAccess.Migrations
{
    public partial class TotalValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalValue",
                table: "PurchasedCoin",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "PurchasedCoin");
        }
    }
}
