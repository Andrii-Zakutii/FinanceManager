using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceManager.WebApp.Migrations
{
    public partial class RenameMoneyAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_MoneyAccount_MoneyAccountId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_MoneyAccount_MoneyAccountId",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyAccount_AspNetUsers_UserId",
                table: "MoneyAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoneyAccount",
                table: "MoneyAccount");

            migrationBuilder.RenameTable(
                name: "MoneyAccount",
                newName: "MoneyAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_MoneyAccount_UserId",
                table: "MoneyAccounts",
                newName: "IX_MoneyAccounts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoneyAccounts",
                table: "MoneyAccounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_MoneyAccounts_MoneyAccountId",
                table: "Expense",
                column: "MoneyAccountId",
                principalTable: "MoneyAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_MoneyAccounts_MoneyAccountId",
                table: "Income",
                column: "MoneyAccountId",
                principalTable: "MoneyAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyAccounts_AspNetUsers_UserId",
                table: "MoneyAccounts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_MoneyAccounts_MoneyAccountId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_MoneyAccounts_MoneyAccountId",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyAccounts_AspNetUsers_UserId",
                table: "MoneyAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoneyAccounts",
                table: "MoneyAccounts");

            migrationBuilder.RenameTable(
                name: "MoneyAccounts",
                newName: "MoneyAccount");

            migrationBuilder.RenameIndex(
                name: "IX_MoneyAccounts_UserId",
                table: "MoneyAccount",
                newName: "IX_MoneyAccount_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoneyAccount",
                table: "MoneyAccount",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyAccount_AspNetUsers_UserId",
                table: "MoneyAccount",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
