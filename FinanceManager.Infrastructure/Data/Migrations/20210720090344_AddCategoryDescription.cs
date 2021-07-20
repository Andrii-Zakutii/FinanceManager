using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceManager.WebApp.Migrations
{
    public partial class AddCategoryDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "IncomeCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ExpenseCategory",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "IncomeCategory");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ExpenseCategory");
        }
    }
}
