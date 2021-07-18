using FinanceManager.WebApp.Models.Base;
using System.Collections.Generic;

namespace FinanceManager.WebApp.Models
{
    public class Account : Entity
    {
        public IEnumerable<Income> Incomes { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
    }
}
