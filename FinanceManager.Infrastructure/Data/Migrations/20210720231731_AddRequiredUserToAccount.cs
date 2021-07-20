using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceManager.WebApp.Migrations
{
    public partial class AddRequiredUserToAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyAccount_AspNetUsers_UserId",
                table: "MoneyAccount");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MoneyAccount",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyAccount_AspNetUsers_UserId",
                table: "MoneyAccount",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoneyAccount_AspNetUsers_UserId",
                table: "MoneyAccount");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MoneyAccount",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyAccount_AspNetUsers_UserId",
                table: "MoneyAccount",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
