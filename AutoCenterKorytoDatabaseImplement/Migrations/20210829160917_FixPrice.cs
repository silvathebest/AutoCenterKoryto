using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoCenterKorytoDatabaseImplement.Migrations
{
    public partial class FixPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ClientWishes");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "PrePurchaseWorks",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "PrePurchaseWorks");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ClientWishes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
