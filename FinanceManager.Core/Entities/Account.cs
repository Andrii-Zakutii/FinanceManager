using FinanceManager.Core.Entities.Base;
using System.Collections.Generic;

namespace FinanceManager.Core.Entities
{
    public class Account : Entity
    {
        public IEnumerable<Income> Incomes { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
    }
}
