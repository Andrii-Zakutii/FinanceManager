namespace FinanceManager.WebApp.Models
{
    public class Expense : Transaction
    {
        public ExpenseCategory Category { get; set; }
    }
}
