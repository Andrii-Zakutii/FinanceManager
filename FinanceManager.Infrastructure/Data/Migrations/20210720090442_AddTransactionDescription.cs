using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceManager.WebApp.Migrations
{
    public partial class AddTransactionDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Income",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Expense",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Income");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Expense");
        }
    }
}
