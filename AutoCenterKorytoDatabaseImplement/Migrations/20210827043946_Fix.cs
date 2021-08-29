using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoCenterKorytoDatabaseImplement.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Colors_ColorId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Features_FeaturesId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ColorId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_FeaturesId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FeaturesId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FeauturesId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Features",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ColorName",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_CarId",
                table: "Features",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Cars_CarId",
                table: "Features",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Cars_CarId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_CarId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "ColorName",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeaturesId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeauturesId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FeaturesId",
                table: "Cars",
                column: "FeaturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Colors_ColorId",
                table: "Cars",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Features_FeaturesId",
                table: "Cars",
                column: "FeaturesId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
