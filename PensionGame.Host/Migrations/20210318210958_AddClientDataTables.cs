using Microsoft.EntityFrameworkCore.Migrations;

namespace PensionGame.Host.Migrations
{
    public partial class AddClientDataTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientHoldings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientHoldings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientHoldings_ClientData_ClientDataId",
                        column: x => x.ClientDataId,
                        principalTable: "ClientData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientDataId = table.Column<int>(type: "int", nullable: false),
                    LifeExpenses = table.Column<int>(type: "int", nullable: false),
                    LoanExpenses = table.Column<int>(type: "int", nullable: false),
                    Rent = table.Column<int>(type: "int", nullable: false),
                    ChildrenExpenses = table.Column<int>(type: "int", nullable: false),
                    ExtraExpenses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseData_ClientData_ClientDataId",
                        column: x => x.ClientDataId,
                        principalTable: "ClientData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientDataId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    BondInterest = table.Column<int>(type: "int", nullable: false),
                    SavingsAccountInterest = table.Column<int>(type: "int", nullable: false),
                    ExtraIncome = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeData_ClientData_ClientDataId",
                        column: x => x.ClientDataId,
                        principalTable: "ClientData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientHoldings_ClientDataId",
                table: "ClientHoldings",
                column: "ClientDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseData_ClientDataId",
                table: "ExpenseData",
                column: "ClientDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncomeData_ClientDataId",
                table: "IncomeData",
                column: "ClientDataId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientHoldings");

            migrationBuilder.DropTable(
                name: "ExpenseData");

            migrationBuilder.DropTable(
                name: "IncomeData");
        }
    }
}
