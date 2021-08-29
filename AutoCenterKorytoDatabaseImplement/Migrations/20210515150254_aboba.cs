using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoCenterKorytoDatabaseImplement.Migrations
{
    public partial class aboba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "DeadlineDate",
                table: "PrePurchaseWorks",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Complectations",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "FIO",
                table: "Clients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FIO",
                table: "Clients");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeadlineDate",
                table: "PrePurchaseWorks",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Complectations",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
