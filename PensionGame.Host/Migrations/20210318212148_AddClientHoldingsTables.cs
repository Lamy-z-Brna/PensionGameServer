using Microsoft.EntityFrameworkCore.Migrations;

namespace PensionGame.Host.Migrations
{
    public partial class AddClientHoldingsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BondHoldings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientHoldingId = table.Column<int>(type: "int", nullable: false),
                    YearlyPayment = table.Column<int>(type: "int", nullable: false),
                    YearsToExpiration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BondHoldings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BondHoldings_ClientHoldings_ClientHoldingId",
                        column: x => x.ClientHoldingId,
                        principalTable: "ClientHoldings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanHoldings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientHoldingId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanHoldings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanHoldings_ClientHoldings_ClientHoldingId",
                        column: x => x.ClientHoldingId,
                        principalTable: "ClientHoldings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SavingsAccountHoldings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientHoldingId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingsAccountHoldings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingsAccountHoldings_ClientHoldings_ClientHoldingId",
                        column: x => x.ClientHoldingId,
                        principalTable: "ClientHoldings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StocksHoldings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientHoldingId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    UnitsHeld = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StocksHoldings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StocksHoldings_ClientHoldings_ClientHoldingId",
                        column: x => x.ClientHoldingId,
                        principalTable: "ClientHoldings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BondHoldings_ClientHoldingId",
                table: "BondHoldings",
                column: "ClientHoldingId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanHoldings_ClientHoldingId",
                table: "LoanHoldings",
                column: "ClientHoldingId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingsAccountHoldings_ClientHoldingId",
                table: "SavingsAccountHoldings",
                column: "ClientHoldingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StocksHoldings_ClientHoldingId",
                table: "StocksHoldings",
                column: "ClientHoldingId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BondHoldings");

            migrationBuilder.DropTable(
                name: "LoanHoldings");

            migrationBuilder.DropTable(
                name: "SavingsAccountHoldings");

            migrationBuilder.DropTable(
                name: "StocksHoldings");
        }
    }
}
