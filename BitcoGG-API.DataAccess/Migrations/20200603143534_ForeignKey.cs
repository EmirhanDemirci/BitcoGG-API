using Microsoft.EntityFrameworkCore.Migrations;

namespace BitcoGG_API.DataAccess.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalValue",
                table: "Wallet",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Wallet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Wallet",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Wallet",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Wallet");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Wallet");

            migrationBuilder.AlterColumn<string>(
                name: "TotalValue",
                table: "Wallet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
