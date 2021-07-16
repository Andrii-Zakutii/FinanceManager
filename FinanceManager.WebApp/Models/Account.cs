using System.Collections.Generic;

namespace FinanceManager.WebApp.Models
{
    public class Account
    {
        public decimal Sum { get; set; }
        public IEnumerable<Income> Incomes { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
    }
}
