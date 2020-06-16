using Microsoft.EntityFrameworkCore.Migrations;

namespace BitcoGG_API.DataAccess.Migrations
{
    public partial class PurchaseCoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "TotalValue",
                table: "Wallet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Wallet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Wallet",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TotalValue",
                table: "Wallet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
