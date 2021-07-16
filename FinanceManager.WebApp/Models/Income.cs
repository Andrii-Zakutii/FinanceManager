namespace FinanceManager.WebApp.Models
{
    public class Income : Transaction
    {
        public IncomeCategory Category { get; set; }
    }
}
