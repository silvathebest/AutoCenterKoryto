using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoCenterKorytoDatabaseImplement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIO = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Company = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrePurchaseWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DeadlineDate = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrePurchaseWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrePurchaseWorks_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateDelivery = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Complectations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    WorkerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complectations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complectations_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    WorkerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientWishes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    PrePurchaseWorksId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientWishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientWishes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientWishes_PrePurchaseWorks_PrePurchaseWorksId",
                        column: x => x.PrePurchaseWorksId,
                        principalTable: "PrePurchaseWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_PrePurchaseWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(nullable: false),
                    PrePurchaseWorksId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_PrePurchaseWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_PrePurchaseWorks_PrePurchaseWorks_PrePurchaseWorksId",
                        column: x => x.PrePurchaseWorksId,
                        principalTable: "PrePurchaseWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_PrePurchaseWorks_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrePurchaseWorks_Complectations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrePurchaseWorksId = table.Column<int>(nullable: false),
                    ComplectationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrePurchaseWorks_Complectations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrePurchaseWorks_Complectations_Complectations_ComplectationId",
                        column: x => x.ComplectationId,
                        principalTable: "Complectations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrePurchaseWorks_Complectations_PrePurchaseWorks_PrePurchaseWorksId",
                        column: x => x.PrePurchaseWorksId,
                        principalTable: "PrePurchaseWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    YearCreation = table.Column<int>(nullable: false),
                    WorkerId = table.Column<int>(nullable: false),
                    FeauturesId = table.Column<int>(nullable: false),
                    FeaturesId = table.Column<int>(nullable: true),
                    ColorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Complectation_Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplectationId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complectation_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complectation_Cars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Complectation_Cars_Complectations_ComplectationId",
                        column: x => x.ComplectationId,
                        principalTable: "Complectations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Cars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_Cars_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FeaturesId",
                table: "Cars",
                column: "FeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_WorkerId",
                table: "Cars",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientWishes_ClientId",
                table: "ClientWishes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientWishes_PrePurchaseWorksId",
                table: "ClientWishes",
                column: "PrePurchaseWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_Complectation_Cars_CarId",
                table: "Complectation_Cars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Complectation_Cars_ComplectationId",
                table: "Complectation_Cars",
                column: "ComplectationId");

            migrationBuilder.CreateIndex(
                name: "IX_Complectations_WorkerId",
                table: "Complectations",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_WorkerId",
                table: "Features",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_PrePurchaseWorks_ClientId",
                table: "PrePurchaseWorks",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PrePurchaseWorks_Complectations_ComplectationId",
                table: "PrePurchaseWorks_Complectations",
                column: "ComplectationId");

            migrationBuilder.CreateIndex(
                name: "IX_PrePurchaseWorks_Complectations_PrePurchaseWorksId",
                table: "PrePurchaseWorks_Complectations",
                column: "PrePurchaseWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Cars_CarId",
                table: "Purchase_Cars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Cars_PurchaseId",
                table: "Purchase_Cars",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PrePurchaseWorks_PrePurchaseWorksId",
                table: "Purchase_PrePurchaseWorks",
                column: "PrePurchaseWorksId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_PrePurchaseWorks_PurchaseId",
                table: "Purchase_PrePurchaseWorks",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ClientId",
                table: "Purchases",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientWishes");

            migrationBuilder.DropTable(
                name: "Complectation_Cars");

            migrationBuilder.DropTable(
                name: "PrePurchaseWorks_Complectations");

            migrationBuilder.DropTable(
                name: "Purchase_Cars");

            migrationBuilder.DropTable(
                name: "Purchase_PrePurchaseWorks");

            migrationBuilder.DropTable(
                name: "Complectations");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "PrePurchaseWorks");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
