using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceManager.WebApp.Migrations
{
    public partial class AddAccountName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Account_AccountId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_Account_AccountId",
                table: "Income");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Income",
                newName: "MoneyAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Income_AccountId",
                table: "Income",
                newName: "IX_Income_MoneyAccountId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Expense",
                newName: "MoneyAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_AccountId",
                table: "Expense",
                newName: "IX_Expense_MoneyAccountId");

            migrationBuilder.CreateTable(
                name: "MoneyAccount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoneyAccount_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoneyAccount_UserId",
                table: "MoneyAccount",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_MoneyAccount_MoneyAccountId",
                table: "Expense",
                column: "MoneyAccountId",
                principalTable: "MoneyAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_MoneyAccount_MoneyAccountId",
                table: "Income",
                column: "MoneyAccountId",
                principalTable: "MoneyAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_MoneyAccount_MoneyAccountId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_MoneyAccount_MoneyAccountId",
                table: "Income");

            migrationBuilder.DropTable(
                name: "MoneyAccount");

            migrationBuilder.RenameColumn(
                name: "MoneyAccountId",
                table: "Income",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Income_MoneyAccountId",
                table: "Income",
                newName: "IX_Income_AccountId");

            migrationBuilder.RenameColumn(
                name: "MoneyAccountId",
                table: "Expense",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_MoneyAccountId",
                table: "Expense",
                newName: "IX_Expense_AccountId");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_UserId",
                table: "Account",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Account_AccountId",
                table: "Expense",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Account_AccountId",
                table: "Income",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
